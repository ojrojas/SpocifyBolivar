import { Fragment, useEffect } from "react"
import { useAppDispatch } from "../../../hooks";
import { useNavigate, useParams } from "react-router-dom";
import { logincallback } from "../redux/login.action";
import { updateLogged } from "../redux/login.slice";
import { RouteConstantsPages } from "../../../core/constants/route.pages.constants";
import { openSnackBarSpocify } from "../../../components/snackbar/redux/snackbarslice.slice";
import { ILoginApplicationResponse } from "../../../core/models/userapplication/loginapplicationresponse";

export const FromLoginCallBackComponent: React.FC = () => {
    const dispatch = useAppDispatch();
    const navigateOn = useNavigate();
    let { user } = useParams();
    
    useEffect(() => {
        dispatch(logincallback({ useriddata: user! })).unwrap().then(
            async (response: ILoginApplicationResponse) => {
                if (response.access_token !== undefined) {
                    dispatch(updateLogged(true));
                    dispatch(openSnackBarSpocify({
                        message: "Loging successful",
                        severity: "success",
                        title: "Login",
                    }));
                    navigateOn(RouteConstantsPages.home);
                }
                else {
                    dispatch(openSnackBarSpocify({
                        message: "Error validation integration spotify authorization",
                        severity: "warning",
                        title: "Login",
                    }));
                    navigateOn(RouteConstantsPages.login);
                }
            });
    })


    return (
        <Fragment> </Fragment>
    );
}