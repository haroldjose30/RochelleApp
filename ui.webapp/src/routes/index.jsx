import Dashboard from "../layouts/Dashboard/Dashboard.jsx";
import Unlogged from "../layouts/Unlogged/Unlogged.jsx";

var indexRoutes = [
                    { path: "/", name: "Login", component: Unlogged },
                    { path: "/dashboard", name: "Home", component: Dashboard },
                   
                   ];

export default indexRoutes;
