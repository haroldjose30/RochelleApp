import LoginPage from "../views/LoginPage/LoginPage.jsx";
import Dashboard from "../views/Dashboard/Dashboard.jsx";

var loginRoutes = [
  {
    path: "/login",
    name: "login",
    icon: "nc-icon nc-bank",
    component: LoginPage
  },
  {
    path: "/dashboard",
    name: "Dashboard",
    icon: "nc-icon nc-bank",
    component: Dashboard
  },
  { redirect: true, path: "/", pathTo: "/login", name: "login" }
];
export default loginRoutes;
