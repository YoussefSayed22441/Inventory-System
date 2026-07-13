import axios from 'axios';
import api from './axiosInstance';

const BASE_URL = import.meta.env.VITE_API_URL || 'http://localhost:5000/api';

/* ── Normalizer: backend UserDto → frontend user shape ───────────────────── */
const normalizeUser = (dto) => ({
  name:         dto.fullName  || dto.displayName || '',
  username:     dto.userName  || dto.username    || '',
  email:        dto.email     || '',
  // role is now returned by the server in UserDto.Role
  role:         dto.role      || 'Operator',
  token:        dto.jWTAuth?.accessToken              || '',
  // jWTAuth.refreshToken is a RefreshToken object { tokenString, expireAt },
  // so we must read .tokenString to get the plain string value.
  refreshToken: dto.jWTAuth?.refreshToken?.tokenString || '',
});

const authService = {
  /** POST /api/auth/Login  — { email, password } */
  login: async ({ email, password }) => {
    const res = await axios.post(`${BASE_URL}/auth/Login`, { email, password });
    const dto = res.data?.data;
    return normalizeUser(dto);
  },

  /**
   * POST /api/auth/Register
   * Backend expects: DisplayName, UserName, Email, PhoneNumber, Password, ConfirmPassword
   */
  register: async ({ name, username, email, phone, password, confirmPassword }) => {
    const res = await axios.post(`${BASE_URL}/auth/Register`, {
      displayName:     name,
      userName:        username || email.split('@')[0],
      email,
      phoneNumber:     phone || '',
      password,
      confirmPassword: confirmPassword || password,
    });
    const dto = res.data?.data;
    return normalizeUser(dto);
  },

  /** POST /api/auth/Logout — requires Bearer token (sent automatically by axiosInstance) */
  logout: async () => {
    try {
      const refreshToken = localStorage.getItem('refreshToken');
      // Only send the RefreshToken in the body; the server reads the AccessToken
      // from the Authorization header that axiosInstance injects automatically.
      await api.post('/auth/Logout', { refreshToken });
    } catch (_) {
      // silently ignore — clear local storage regardless
    }
    localStorage.removeItem('token');
    localStorage.removeItem('refreshToken');
    localStorage.removeItem('user');
  },

  /** POST /api/auth/RefreshToken */
  refreshToken: async () => {
    const accessToken  = localStorage.getItem('token');
    const refreshToken = localStorage.getItem('refreshToken');
    // The RefreshToken endpoint returns Result<JWTAuthResult> (flat), not a
    // UserDto — so we must NOT pipe through normalizeUser().
    const res = await axios.post(`${BASE_URL}/auth/RefreshToken`, { accessToken, refreshToken });
    const data = res.data?.data; // JWTAuthResult
    return {
      token:        data?.accessToken                    || '',
      refreshToken: data?.refreshToken?.tokenString      || '',
    };
  },

  /** PUT /api/auth/Profile — update own account */
  updateProfile: async (data) => {
    const res = await api.put('/auth/Profile', data);
    return res.data?.data;
  },

  /** DELETE /api/auth/Profile — delete own account (requires current password) */
  deleteAccount: async (password) => {
    // axios DELETE with a body requires the `data` key in the config object
    await api.delete('/auth/Profile', { data: { password } });
  },

  getCurrentUser: () => {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user) : null;
  },

  getToken: () => localStorage.getItem('token'),
};

export default authService;
