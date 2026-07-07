import { configureStore } from "@reduxjs/toolkit";
import authReducer from "./authSlice";
import inventoryReducer from "./inventorySlice";
import categoryReducer from "./categorySlice";
import supplierReducer from "./supplierSlice";

export const store = configureStore({
  reducer: {
    auth: authReducer,
    inventory: inventoryReducer,
    categories: categoryReducer,
    suppliers: supplierReducer,
  },
});