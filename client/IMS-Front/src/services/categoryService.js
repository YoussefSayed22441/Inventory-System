import api from './axiosInstance';

/* ── Normalizer ──────────────────────────────────────────────────────────── */
const normalize = (c) => ({
  id:          c.id,
  name:        c.categoryName,
  description: c.description || '',
  // status:      'Active',              // backend Category has no status field
  // code:        `CAT-${c.categoryName?.slice(0, 3).toUpperCase()}`,
  createdAt:   c.createdAt,
  lastUpdated: c.updatedAt || c.createdAt,
});

const unwrapList = (resData) => {
  const inner = resData?.data;
  const rows  = inner?.data ?? inner ?? [];
  return Array.isArray(rows) ? rows.map(normalize) : [];
};

/* ── Service ─────────────────────────────────────────────────────────────── */
const categoryService = {
  /** GET /api/category */
  getAll: async (params = {}) => {
    const res = await api.get('/category', { params });
    return unwrapList(res.data);
  },

  /** GET /api/category/:id */
  getById: async (id) => {
    const res = await api.get(`/category/${id}`);
    return normalize(res.data.data);
  },

  /** POST /api/category */
  create: async (cat) => {
    const res = await api.post('/category', {
      categoryName: cat.name,
      description:  cat.description || '',
    });
    return normalize(res.data.data);
  },

  /** PUT /api/category */
  update: async (cat) => {
    const res = await api.put('/category', {
      id:           cat.id,
      categoryName: cat.name,
      description:  cat.description || '',
    });
    return normalize(res.data.data);
  },

  /** DELETE /api/category/:id */
  delete: async (id) => {
    await api.delete(`/category/${id}`);
    return id;
  },
};

export default categoryService;
