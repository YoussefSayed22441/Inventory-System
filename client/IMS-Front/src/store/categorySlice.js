import { createSlice } from '@reduxjs/toolkit';

const initialCategories = [
  {
    id: 'cat-1',
    name: 'Electronics',
    code: 'CAT-ELE',
    description: 'Quantum microprocessors, sensor arrays, memory stacks, and digital circuitry.',
    status: 'Active',
    lastUpdated: '2026-06-25T14:30:00Z',
  },
  {
    id: 'cat-2',
    name: 'Chemicals',
    code: 'CAT-CHM',
    description: 'Industrial cooling agents, reactive gases, fuel isotopes, and chemical compounds.',
    status: 'Active',
    lastUpdated: '2026-06-26T09:15:00Z',
  },
  {
    id: 'cat-3',
    name: 'Hardware',
    code: 'CAT-HWR',
    description: 'Structural chassis frames, titanium alloy fasteners, brackets, and joint brackets.',
    status: 'Active',
    lastUpdated: '2026-06-24T18:00:00Z',
  },
  {
    id: 'cat-4',
    name: 'Logistics',
    code: 'CAT-LOG',
    description: 'Pallets, shipping containers, protective wraps, and terminal handling units.',
    status: 'Active',
    lastUpdated: '2026-06-26T07:45:00Z',
  },
  {
    id: 'cat-5',
    name: 'Services',
    code: 'CAT-SRV',
    description: 'Maintenance plans, consulting hours, technical support, and setup labor.',
    status: 'Inactive',
    lastUpdated: '2026-06-21T09:00:00Z',
  },
];

const initialState = {
  items: initialCategories,
  searchQuery: '',
  loading: false,
  error: null,
};

const categorySlice = createSlice({
  name: 'categories',
  initialState,
  reducers: {
    addCategory: (state, action) => {
      const newCategory = {
        ...action.payload,
        id: `cat-${Date.now()}`,
        lastUpdated: new Date().toISOString(),
      };
      state.items.unshift(newCategory);
    },
    updateCategory: (state, action) => {
      const index = state.items.findIndex((item) => item.id === action.payload.id);
      if (index !== -1) {
        state.items[index] = {
          ...action.payload,
          lastUpdated: new Date().toISOString(),
        };
      }
    },
    deleteCategory: (state, action) => {
      state.items = state.items.filter((item) => item.id !== action.payload);
    },
    setSearchQuery: (state, action) => {
      state.searchQuery = action.payload;
    },
  },
});

export const {
  addCategory,
  updateCategory,
  deleteCategory,
  setSearchQuery,
} = categorySlice.actions;

export default categorySlice.reducer;
