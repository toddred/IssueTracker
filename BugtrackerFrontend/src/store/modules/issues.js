import Axios from "axios";
const BASE_URL = "https://localhost:5001/issues";

const state = {
  issues: []
};
const getters = {
  allIssues: state => state.issues
};
const actions = {
  //TODO: Handle sad path in all actions
  async getIssues({ commit }) {
    const response = await Axios.get(BASE_URL);
    if (response.status == 200){
      commit("setIssues", response.data);
    }
    else{
      // handle error
    }
  },
  async secureIssues({ commit , state}) {
    if(state.authenticated){
      const response = await Axios.get(BASE_URL + "/secure",{
        headers: {
          //"Content-Type": "application/json",
          "Authorization": "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyIn0.mLX8vO1DqwBbAST0R1Fs76u2_GdCeWto8N1QjUOhNtg"
        }
  
      });
      //if (response.status == 200){
        commit("setIssues", response.data);
      //}
      // else{
      //   // handle error
      // }
    }
  },
  async addIssue({ commit }, issue) {
    const response = await Axios.post(BASE_URL, issue, {
      headers: {
        "Content-Type": "application/json",
        "Authorization": "Bearer " + "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIyIn0.mLX8vO1DqwBbAST0R1Fs76u2_GdCeWto8N1QjUOhNtg"
      }

    });
    commit("createIssue", response.data);

  },
  async archiveIssue({ commit }, id) {
    const response = await Axios.delete(`${BASE_URL}/${id}`);
    response.statusText;
    commit("deleteIssue", id);
  },
  async editIssue({ commit }, id, issue) {
    const response = await Axios.put(`${BASE_URL}/edit/${id}`, issue);
    commit("changeIssue", response.data);
  }
};
const mutations = {
  setIssues: (state, issues) => (state.issues = issues),
  createIssue: (state, issue) => (state.issues = [...state.issues, issue]),
  deleteIssue: (state, id) =>
    (state.issues = state.issues.filter(issue => issue.id !== id)),
  changeIssue: (state, issue) => {
    const idx = state.issues.findIndex(old => old.id === issue.id);
    state.issues[idx] = issue;
  }
};

export default {
  state,
  getters,
  actions,
  mutations
};
