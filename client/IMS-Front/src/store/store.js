import { configureStore } from '@reduxjs/toolkit';
import authReducer         from './authSlice';
import inventoryReducer    from './inventorySlice';
import categoryReducer     from './categorySlice';
import supplierReducer     from './supplierSlice';
import userReducer         from './userSlice';
import transferReducer     from './transferSlice';
import stockHistoryReducer from './stockHistorySlice';
import notificationReducer from './notificationSlice';

export const store = configureStore({
  reducer: {
    auth:         authReducer,
    inventory:    inventoryReducer,
    categories:   categoryReducer,
    suppliers:    supplierReducer,
    users:        userReducer,
    transfers:    transferReducer,       // kept for Transfers page (UI-level state)
    stockHistory: stockHistoryReducer,   // real API: IN / OUT / ADJUSTMENT history
    notifications: notificationReducer,
  },
});