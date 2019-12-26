import Axios from "axios";
const BASE_URL = "https://localhost:5001/issues";

const state = {
  issues: []
};
const getters = {
  allIssues: state => state.issues
  //getIssue: ({ state }, id) => state.issues.find(issue => issue.id === id)
};
const actions = {
  //TODO: Handle sad path in all actions
  async getIssues({ commit }) {
    const response = await Axios.get(BASE_URL);
    if (response.status == 200) {
      commit("setIssues", response.data);
    } else {
      // handle error
    }
  },
  async addIssue({ commit, rootState }, issue) {
    const response = await Axios.post(BASE_URL, issue, {
      headers: {
        "Content-Type": "application/json",
        Authorization: rootState.auth.token
      }
    });
    commit("createIssue", response.data);
  },
  async archiveIssue({ commit, rootState }, id) {
    const response = await Axios.delete(`${BASE_URL}/${id}`, {
      headers: {
        "Content-Type": "application/json",
        Authorization: rootState.auth.token
      }
    });
    response.statusText;
    commit("deleteIssue", id);
  },
  async editIssue({ commit, rootState }, issue) {
    const response = await Axios.put(BASE_URL, issue, {
      headers: {
        "Content-Type": "application/json",
        Authorization: rootState.auth.token
      }
    });
    commit("changeIssue", response.data);
  }
};
const mutations = {
  setIssues: (state, issues) => (state.issues = issues),
  createIssue: (state, issue) => (state.issues = [...state.issues, issue]),
  deleteIssue: (state, id) =>
    (state.issues = state.issues.filter(issue => issue.id !== id)),
  changeIssue: (state, issue) => {
    let remainingIssues = state.issues.filter(
      element => element.id !== issue.id
    );
    state.issues = [...remainingIssues, issue];
  }
};

export default {
  state,
  getters,
  actions,
  mutations
};
