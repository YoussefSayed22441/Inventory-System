import { createSlice } from '@reduxjs/toolkit';

const initialState = {
  user:            JSON.parse(localStorage.getItem('user')) || null,
  token:           localStorage.getItem('token')            || null,
  refreshToken:    localStorage.getItem('refreshToken')     || null,
  isAuthenticated: !!localStorage.getItem('token'),
  loading:         false,
  error:           null,
};

const authSlice = createSlice({
  name: 'auth',
  initialState,
  reducers: {
    loginStart: (state) => {
      state.loading = true;
      state.error   = null;
    },
    loginSuccess: (state, action) => {
      const { token, refreshToken, ...user } = action.payload;
      state.loading         = false;
      state.user            = user;
      state.token           = token;
      state.refreshToken    = refreshToken || null;
      state.isAuthenticated = true;
      localStorage.setItem('user',         JSON.stringify(user));
      localStorage.setItem('token',        token);
      if (refreshToken) localStorage.setItem('refreshToken', refreshToken);
    },
    loginFailure: (state, action) => {
      state.loading = false;
      state.error   = action.payload;
    },
    logout: (state) => {
      state.user            = null;
      state.token           = null;
      state.refreshToken    = null;
      state.isAuthenticated = false;
      localStorage.removeItem('user');
      localStorage.removeItem('token');
      localStorage.removeItem('refreshToken');
    },
    updateUserData: (state, action) => {
      state.user = { ...state.user, ...action.payload };
      localStorage.setItem('user', JSON.stringify(state.user));
    },
    tokenRefreshed: (state, action) => {
      state.token        = action.payload.token;
      state.refreshToken = action.payload.refreshToken || state.refreshToken;
      localStorage.setItem('token', action.payload.token);
      if (action.payload.refreshToken) localStorage.setItem('refreshToken', action.payload.refreshToken);
    },
  },
});

export const {
  loginStart, loginSuccess, loginFailure,
  logout, updateUserData, tokenRefreshed,
} = authSlice.actions;
export default authSlice.reducer;
