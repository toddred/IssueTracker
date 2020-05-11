import Vue from "vue";
import VueRouter from "vue-router";
Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home",
    component: () => import("../views/Home.vue")
  },
  {
    path: "/about",
    name: "about",
    // route level code-splitting
    // this generates a separate chunk (about.[hash].js) for this route
    // which is lazy-loaded when the route is visited.
    component: () => import("../views/About.vue")
  },
  {
    path: "/create",
    name: "create",
    component: () => import("../views/Create.vue")
  },
  {
    path: "/login",
    name: "login",
    component: () => import("../views/Login.vue")
  },
  {
    path: "/register",
    name: "register",
    component: () => import("../views/Register.vue")
  },
  {
    path:"/edit",
    name: "edit",
    component: () => import("../views/Edit.vue"),
    props:true
  }
];

const router = new VueRouter({
  routes
});

export default router;
