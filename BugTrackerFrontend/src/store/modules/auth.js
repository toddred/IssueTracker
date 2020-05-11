import Axios from "axios";
const BASE_URL = "https://localhost:5002/user";
const BEARER = "Bearer ";
const ROUTE = {
  AUTHENTICATE: "/authenticate",
  REGISTER: "/register"
};
const state = {
  token: localStorage.getItem("token")
};
const getters = {
  isAuthenticated: state => (state.token ? true : false)
};
const actions = {
  async authenticateUser({ commit }, auth_DTO) {
    const response = await Axios.post(BASE_URL + ROUTE.AUTHENTICATE, auth_DTO, {
      headers: { "Content-Type": "application/json" }
    });
    if (response.status == 200) {
      const token = response.data.token;
      localStorage.setItem("token", token);
      commit("setToken", token);
    }
  },
  async registerUser({ commit }, register_DTO) {
    const response = await Axios.post(BASE_URL + ROUTE.REGISTER, register_DTO, {
      headers: { "Content-Type": "application/json" }
    });
    if (response.status == 200) {
      const token = response.data.token;
      commit("setToken", token);
    }
  },
  logout({ commit }) {
    localStorage.removeItem("token");
    commit("deleteToken");
  }
  // TODO: Refresh token
};
const mutations = {
  setToken: (state, token) => (state.token = BEARER + token),
  deleteToken: state => (state.token = "")
};

export default {
  state,
  getters,
  actions,
  mutations
};
