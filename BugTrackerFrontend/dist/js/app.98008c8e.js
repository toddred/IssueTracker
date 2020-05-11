(function(e){function t(t){for(var r,u,s=t[0],c=t[1],i=t[2],l=0,d=[];l<s.length;l++)u=s[l],Object.prototype.hasOwnProperty.call(o,u)&&o[u]&&d.push(o[u][0]),o[u]=0;for(r in c)Object.prototype.hasOwnProperty.call(c,r)&&(e[r]=c[r]);p&&p(t);while(d.length)d.shift()();return a.push.apply(a,i||[]),n()}function n(){for(var e,t=0;t<a.length;t++){for(var n=a[t],r=!0,u=1;u<n.length;u++){var c=n[u];0!==o[c]&&(r=!1)}r&&(a.splice(t--,1),e=s(s.s=n[0]))}return e}var r={},o={app:0},a=[];function u(e){return s.p+"js/"+({}[e]||e)+"."+{"chunk-0f099916":"0a5ad604","chunk-2d22d746":"d619ea40","chunk-2ee73a12":"8d105b8a","chunk-5892e54c":"69eef5a5","chunk-d5cac450":"6a883dca","chunk-d9e5f3e2":"e5c0e1df"}[e]+".js"}function s(t){if(r[t])return r[t].exports;var n=r[t]={i:t,l:!1,exports:{}};return e[t].call(n.exports,n,n.exports,s),n.l=!0,n.exports}s.e=function(e){var t=[],n=o[e];if(0!==n)if(n)t.push(n[2]);else{var r=new Promise((function(t,r){n=o[e]=[t,r]}));t.push(n[2]=r);var a,c=document.createElement("script");c.charset="utf-8",c.timeout=120,s.nc&&c.setAttribute("nonce",s.nc),c.src=u(e);var i=new Error;a=function(t){c.onerror=c.onload=null,clearTimeout(l);var n=o[e];if(0!==n){if(n){var r=t&&("load"===t.type?"missing":t.type),a=t&&t.target&&t.target.src;i.message="Loading chunk "+e+" failed.\n("+r+": "+a+")",i.name="ChunkLoadError",i.type=r,i.request=a,n[1](i)}o[e]=void 0}};var l=setTimeout((function(){a({type:"timeout",target:c})}),12e4);c.onerror=c.onload=a,document.head.appendChild(c)}return Promise.all(t)},s.m=e,s.c=r,s.d=function(e,t,n){s.o(e,t)||Object.defineProperty(e,t,{enumerable:!0,get:n})},s.r=function(e){"undefined"!==typeof Symbol&&Symbol.toStringTag&&Object.defineProperty(e,Symbol.toStringTag,{value:"Module"}),Object.defineProperty(e,"__esModule",{value:!0})},s.t=function(e,t){if(1&t&&(e=s(e)),8&t)return e;if(4&t&&"object"===typeof e&&e&&e.__esModule)return e;var n=Object.create(null);if(s.r(n),Object.defineProperty(n,"default",{enumerable:!0,value:e}),2&t&&"string"!=typeof e)for(var r in e)s.d(n,r,function(t){return e[t]}.bind(null,r));return n},s.n=function(e){var t=e&&e.__esModule?function(){return e["default"]}:function(){return e};return s.d(t,"a",t),t},s.o=function(e,t){return Object.prototype.hasOwnProperty.call(e,t)},s.p="/",s.oe=function(e){throw console.error(e),e};var c=window["webpackJsonp"]=window["webpackJsonp"]||[],i=c.push.bind(c);c.push=t,c=c.slice();for(var l=0;l<c.length;l++)t(c[l]);var p=i;a.push([0,"chunk-vendors"]),n()})({0:function(e,t,n){e.exports=n("56d7")},"56d7":function(e,t,n){"use strict";n.r(t);n("e623"),n("e379"),n("5dc8"),n("37e1");var r=n("2b0e"),o=function(){var e=this,t=e.$createElement,n=e._self._c||t;return n("div",{attrs:{id:"app"}},[n("md-app",{attrs:{"md-mode":"reveal"}},[n("md-app-toolbar",{staticClass:"md-primary"},[n("router-link",{attrs:{to:"/"}},[n("h1",[e._v("Bug Tracker")])]),n("div",{attrs:{id:"nav"}},[e.isAuthenticated?n("md-button",{on:{click:e.logout}},[e._v("Logout")]):n("router-link",{attrs:{to:"/login"}},[n("md-button",{staticClass:"md-primary"},[e._v("Login")])],1)],1)],1),n("md-app-content",[n("router-view")],1)],1)],1)},a=[],u=n("2f62"),s={name:"App",computed:Object(u["c"])(["isAuthenticated"]),methods:{logout:function(){this.$store.dispatch("logout")}}},c=s,i=n("2877"),l=Object(i["a"])(c,o,a,!1,null,null,null),p=l.exports,d=n("43f9"),f=n.n(d),h=(n("51de"),n("d3b7"),n("8c4f"));r["default"].use(h["a"]);var m=[{path:"/",name:"home",component:function(){return n.e("chunk-0f099916").then(n.bind(null,"bb51"))}},{path:"/about",name:"about",component:function(){return n.e("chunk-2d22d746").then(n.bind(null,"f820"))}},{path:"/create",name:"create",component:function(){return n.e("chunk-d9e5f3e2").then(n.bind(null,"d879"))}},{path:"/login",name:"login",component:function(){return n.e("chunk-5892e54c").then(n.bind(null,"a55b"))}},{path:"/register",name:"register",component:function(){return n.e("chunk-d5cac450").then(n.bind(null,"73cf"))}},{path:"/edit",name:"edit",component:function(){return n.e("chunk-2ee73a12").then(n.bind(null,"1071"))},props:!0}],g=new h["a"]({routes:m}),v=g,b=(n("99af"),n("4de4"),n("2909")),k=(n("96cf"),n("1da1")),w=n("bc3a"),y=n.n(w),j="https://localhost:5001/issues",T={issues:[]},O={allIssues:function(e){return e.issues}},x={getIssues:function(e){return Object(k["a"])(regeneratorRuntime.mark((function t(){var n,r;return regeneratorRuntime.wrap((function(t){while(1)switch(t.prev=t.next){case 0:return n=e.commit,t.next=3,y.a.get(j);case 3:r=t.sent,200==r.status&&n("setIssues",r.data);case 5:case"end":return t.stop()}}),t)})))()},addIssue:function(e,t){return Object(k["a"])(regeneratorRuntime.mark((function n(){var r,o,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=e.commit,o=e.rootState,n.next=3,y.a.post(j,t,{headers:{"Content-Type":"application/json",Authorization:o.auth.token}});case 3:a=n.sent,r("createIssue",a.data);case 5:case"end":return n.stop()}}),n)})))()},archiveIssue:function(e,t){return Object(k["a"])(regeneratorRuntime.mark((function n(){var r,o,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=e.commit,o=e.rootState,n.next=3,y.a.delete("".concat(j,"/").concat(t),{headers:{"Content-Type":"application/json",Authorization:o.auth.token}});case 3:a=n.sent,a.statusText,r("deleteIssue",t);case 6:case"end":return n.stop()}}),n)})))()},editIssue:function(e,t){return Object(k["a"])(regeneratorRuntime.mark((function n(){var r,o,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=e.commit,o=e.rootState,n.next=3,y.a.put(j,t,{headers:{"Content-Type":"application/json",Authorization:o.auth.token}});case 3:a=n.sent,r("changeIssue",a.data);case 5:case"end":return n.stop()}}),n)})))()}},I={setIssues:function(e,t){return e.issues=t},createIssue:function(e,t){return e.issues=[].concat(Object(b["a"])(e.issues),[t])},deleteIssue:function(e,t){return e.issues=e.issues.filter((function(e){return e.id!==t}))},changeIssue:function(e,t){var n=e.issues.filter((function(e){return e.id!==t.id}));e.issues=[].concat(Object(b["a"])(n),[t])}},R={state:T,getters:O,actions:x,mutations:I},S="https://localhost:5002/user",A="Bearer ",E={AUTHENTICATE:"/authenticate",REGISTER:"/register"},C={token:localStorage.getItem("token")},_={isAuthenticated:function(e){return!!e.token}},P={authenticateUser:function(e,t){return Object(k["a"])(regeneratorRuntime.mark((function n(){var r,o,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=e.commit,n.next=3,y.a.post(S+E.AUTHENTICATE,t,{headers:{"Content-Type":"application/json"}});case 3:o=n.sent,200==o.status&&(a=o.data.token,localStorage.setItem("token",a),r("setToken",a));case 5:case"end":return n.stop()}}),n)})))()},registerUser:function(e,t){return Object(k["a"])(regeneratorRuntime.mark((function n(){var r,o,a;return regeneratorRuntime.wrap((function(n){while(1)switch(n.prev=n.next){case 0:return r=e.commit,n.next=3,y.a.post(S+E.REGISTER,t,{headers:{"Content-Type":"application/json"}});case 3:o=n.sent,200==o.status&&(a=o.data.token,r("setToken",a));case 5:case"end":return n.stop()}}),n)})))()},logout:function(e){var t=e.commit;localStorage.removeItem("token"),t("deleteToken")}},L={setToken:function(e,t){return e.token=A+t},deleteToken:function(e){return e.token=""}},M={state:C,getters:_,actions:P,mutations:L};r["default"].use(u["a"]);var U=new u["a"].Store({modules:{issues:R,auth:M}});r["default"].use(f.a),r["default"].config.productionTip=!1,new r["default"]({router:v,store:U,render:function(e){return e(p)}}).$mount("#app")}});
//# sourceMappingURL=app.98008c8e.js.map