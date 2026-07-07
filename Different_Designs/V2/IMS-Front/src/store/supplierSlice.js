import { createSlice } from '@reduxjs/toolkit';

const initialSuppliers = [
  {
    id: 'sup-1',
    name: 'Apex Tech',
    code: 'SUP-APX',
    contactPerson: 'Sarah Connor',
    email: 'sconnor@apextech.io',
    phone: '+1 (555) 019-2831',
    status: 'Active',
    rating: 4.9,
    description: 'High-end quantum microprocessors and advanced motherboard core chipsets.',
    lastUpdated: '2026-06-25T14:30:00Z',
  },
  {
    id: 'sup-2',
    name: 'Quantum Indus',
    code: 'SUP-QTM',
    contactPerson: 'Alan Turing',
    email: 'aturing@quantumind.com',
    phone: '+1 (555) 014-9921',
    status: 'Active',
    rating: 4.7,
    description: 'Cryogenic coolants, reactor-grade plasma elements, and chemical compounds.',
    lastUpdated: '2026-06-26T09:15:00Z',
  },
  {
    id: 'sup-3',
    name: 'Titan Alloys',
    code: 'SUP-TTN',
    contactPerson: 'Arthur Dent',
    email: 'adent@titanalloys.co',
    phone: '+1 (555) 018-4422',
    status: 'Active',
    rating: 4.5,
    description: 'Titanium structures, structural framework materials, and hardware joints.',
    lastUpdated: '2026-06-24T18:00:00Z',
  },
  {
    id: 'sup-4',
    name: 'Global Logistics',
    code: 'SUP-GLB',
    contactPerson: 'John Doe',
    email: 'jdoe@globallogistics.org',
    phone: '+1 (555) 012-7844',
    status: 'Active',
    rating: 4.2,
    description: 'Shipping conveyor equipment, automated transport modules, and logistics.',
    lastUpdated: '2026-06-26T07:45:00Z',
  },
];

const initialState = {
  items: initialSuppliers,
  searchQuery: '',
  loading: false,
  error: null,
};

const supplierSlice = createSlice({
  name: 'suppliers',
  initialState,
  reducers: {
    addSupplier: (state, action) => {
      const newSupplier = {
        ...action.payload,
        id: `sup-${Date.now()}`,
        lastUpdated: new Date().toISOString(),
      };
      state.items.unshift(newSupplier);
    },
    updateSupplier: (state, action) => {
      const index = state.items.findIndex((item) => item.id === action.payload.id);
      if (index !== -1) {
        state.items[index] = {
          ...action.payload,
          lastUpdated: new Date().toISOString(),
        };
      }
    },
    deleteSupplier: (state, action) => {
      state.items = state.items.filter((item) => item.id !== action.payload);
    },
    setSearchQuery: (state, action) => {
      state.searchQuery = action.payload;
    },
  },
});

export const {
  addSupplier,
  updateSupplier,
  deleteSupplier,
  setSearchQuery,
} = supplierSlice.actions;

export default supplierSlice.reducer;
