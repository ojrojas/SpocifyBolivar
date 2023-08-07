import { createBrowserRouter } from "react-router-dom";
import { RouteConstantsPages } from "../core/constants/route.pages.constants";
import DrawerComponent from '../components/layout/drawercomponent';
import DashboardPage from "../pages/dashboard/dashboard";
import { LoginPage } from "../pages/login/login";
import { CallbackLogin } from "../pages/login/loginreturn";

const router = createBrowserRouter([
    {
        path: RouteConstantsPages.root,
        element: <DrawerComponent />,
        children: [
            {
                path: RouteConstantsPages.home,
                element: <DashboardPage />
            }
        ]
    },
    {
        path: RouteConstantsPages.login,
        element: <LoginPage />
    },
    {
        path: `${RouteConstantsPages.logincallback}/:user`,
        element: <CallbackLogin />
    }
]);

export default router;