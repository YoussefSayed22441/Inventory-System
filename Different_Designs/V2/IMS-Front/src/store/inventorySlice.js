import { createSlice } from '@reduxjs/toolkit';

const initialProducts = [
  {
    id: 'prod-1',
    name: 'Quantum CPU Core',
    sku: 'SKU-2910',
    category: 'Electronics',
    supplier: 'Apex Tech',
    warehouse: 'North Hub',
    quantity: 85,
    unitPrice: 120.0,
    lastUpdated: '2026-06-25T14:30:00Z',
  },
  {
    id: 'prod-2',
    name: 'Neon Plasma Tubing',
    sku: 'SKU-3829',
    category: 'Chemicals',
    supplier: 'Quantum Indus',
    warehouse: 'South Wing',
    quantity: 12,
    unitPrice: 45.0,
    lastUpdated: '2026-06-26T09:15:00Z',
  },
  {
    id: 'prod-3',
    name: 'Carbon Fiber Chassis',
    sku: 'SKU-1049',
    category: 'Hardware',
    supplier: 'Titan Alloys',
    warehouse: 'East Depot',
    quantity: 40,
    unitPrice: 210.0,
    lastUpdated: '2026-06-24T18:00:00Z',
  },
  {
    id: 'prod-4',
    name: 'Lithium Power Pack',
    sku: 'SKU-8840',
    category: 'Electronics',
    supplier: 'Apex Tech',
    warehouse: 'North Hub',
    quantity: 0,
    unitPrice: 95.0,
    lastUpdated: '2026-06-22T11:45:00Z',
  },
  {
    id: 'prod-5',
    name: 'Cryogenic Coolant',
    sku: 'SKU-4752',
    category: 'Chemicals',
    supplier: 'Quantum Indus',
    warehouse: 'South Wing',
    quantity: 120,
    unitPrice: 15.5,
    lastUpdated: '2026-06-26T10:30:00Z',
  },
  {
    id: 'prod-6',
    name: 'Fiber Optic Loom',
    sku: 'SKU-5521',
    category: 'Hardware',
    supplier: 'Titan Alloys',
    warehouse: 'East Depot',
    quantity: 95,
    unitPrice: 8.2,
    lastUpdated: '2026-06-25T08:20:00Z',
  },
  {
    id: 'prod-7',
    name: 'Holographic Scanner',
    sku: 'SKU-7742',
    category: 'Electronics',
    supplier: 'Apex Tech',
    warehouse: 'North Hub',
    quantity: 8,
    unitPrice: 340.0,
    lastUpdated: '2026-06-26T12:00:00Z',
  },
  {
    id: 'prod-8',
    name: 'Titan Bolting Kit',
    sku: 'SKU-9041',
    category: 'Hardware',
    supplier: 'Titan Alloys',
    warehouse: 'East Depot',
    quantity: 250,
    unitPrice: 2.5,
    lastUpdated: '2026-06-23T15:10:00Z',
  },
  {
    id: 'prod-9',
    name: 'Catalyst Gas Shield',
    sku: 'SKU-1192',
    category: 'Chemicals',
    supplier: 'Quantum Indus',
    warehouse: 'South Wing',
    quantity: 0,
    unitPrice: 88.0,
    lastUpdated: '2026-06-21T09:00:00Z',
  },
  {
    id: 'prod-10',
    name: 'Smart Conveyor Belt',
    sku: 'SKU-3304',
    category: 'Logistics',
    supplier: 'Global Logistics',
    warehouse: 'East Depot',
    quantity: 30,
    unitPrice: 550.0,
    lastUpdated: '2026-06-26T07:45:00Z',
  },
];

const initialState = {
  items: initialProducts,
  filters: {
    search: '',
    category: 'All',
    supplier: 'All',
    warehouse: 'All',
    status: 'All',
  },
  sortBy: 'name',
  sortOrder: 'asc',
  loading: false,
  error: null,
};

const inventorySlice = createSlice({
  name: 'inventory',
  initialState,
  reducers: {
    addProduct: (state, action) => {
      const newProduct = {
        ...action.payload,
        id: `prod-${Date.now()}`,
        lastUpdated: new Date().toISOString(),
      };
      state.items.unshift(newProduct);
    },
    updateProduct: (state, action) => {
      const index = state.items.findIndex((item) => item.id === action.payload.id);
      if (index !== -1) {
        state.items[index] = {
          ...action.payload,
          lastUpdated: new Date().toISOString(),
        };
      }
    },
    deleteProduct: (state, action) => {
      state.items = state.items.filter((item) => item.id !== action.payload);
    },
    setFilters: (state, action) => {
      state.filters = {
        ...state.filters,
        ...action.payload,
      };
    },
    resetFilters: (state) => {
      state.filters = initialState.filters;
    },
    setSorting: (state, action) => {
      if (state.sortBy === action.payload) {
        state.sortOrder = state.sortOrder === 'asc' ? 'desc' : 'asc';
      } else {
        state.sortBy = action.payload;
        state.sortOrder = 'asc';
      }
    },
  },
});

export const {
  addProduct,
  updateProduct,
  deleteProduct,
  setFilters,
  resetFilters,
  setSorting,
} = inventorySlice.actions;

export default inventorySlice.reducer;
