import Axios from "axios";
const BASE_URL = "https://localhost:5002/user";
const BEARER = 'Bearer ';
const state = {
  token: "",
  authenticated: false
};
const getters = {
  //allIssues: state => state.issues
  isAuthenticated : state => state.authenticated,
  getToken: state => state.token
};
const actions = {
    async authenticateUser({commit}, auth_DTO){
        const response = await Axios.post(BASE_URL+'/authenticate', auth_DTO, { headers:{"Content-Type": "application/json"}});
        if (response.status == 200){
          commit("setToken", response.data);
        }
    },
    async registerUser({commit}, register_DTO){
        const response = await Axios.post(BASE_URL+'/register', register_DTO, { headers:{"Content-Type": "application/json"}});
        if (response.status == 200){
          commit("setToken", response.data);
        }
    }
    // TODO: Logout and Refresh 
};
const mutations = {

       setToken: (state, token) => {
           state.token = BEARER + token.toString();
           state.authenticated = true; 
        },
};

export default {
  state,
  getters,
  actions,
  mutations
};