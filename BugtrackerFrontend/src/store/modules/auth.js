import Axios from "axios";
const BASE_URL = "https://localhost:5002/user";
const BEARER = 'Bearer ';
const ROUTE = {
  AUTHENTICATE:'/authenticate',
  REGISTER: '/register',
}
const state = {
  token: "",
  authenticated: false
};
const getters = {
  //allIssues: state => state.issues
  isAuthenticated : state => state.authenticated,
  //getToken: state => state.token
};
const actions = {
    async authenticateUser({commit}, auth_DTO){
        const response = await Axios.post(BASE_URL + ROUTE.AUTHENTICATE, auth_DTO, { headers:{"Content-Type": "application/json"}});
        if (response.status == 200){
          commit("setToken", response.data.token);
        }
    },
    async registerUser({commit}, register_DTO){
        const response = await Axios.post(BASE_URL + ROUTE.REGISTER, register_DTO, { headers:{"Content-Type": "application/json"}});
        if (response.status == 200){
          commit("setToken", response.data.token);
        }
    },
    logout({commit}){
      commit('deleteToken');
    }
    // TODO: Refresh token
};
const mutations = {

       setToken: (state, token) => {
           state.token = BEARER + token;
           state.authenticated = true; 
        },
        deleteToken: (state) => {
          state.token = "";
          state.authenticated = false;
        }
};

export default {
  state,
  getters,
  actions,
  mutations
};