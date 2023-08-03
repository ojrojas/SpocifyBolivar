import { Fragment, useEffect } from "react"
import { useAppDispatch, useAppSelector } from "../../../hooks";
import { useNavigate, useParams } from "react-router-dom";
import { logincallback } from "../redux/login.action";
import { ILoginApplicationResponse } from "../../../core/dtos/userapplication/loginapplicationresponse";
import { updateLogged } from "../redux/login.slice";
import { RouteConstantsPages } from "../../../core/constants/route.pages.constants";
import { openSnackBarSpocify } from "../../../components/snackbar/redux/snackbarslice.slice";

export const FromLoginCallBackComponent: React.FC = () => {
    const dispatch = useAppDispatch();
    const navigateOn = useNavigate();
    const { logged } = useAppSelector(state => state.login);
    let { user } = useParams();

    useEffect(() => {
        callAuthorizetoken();
    }, [dispatch])

    useEffect(() => {
        if (logged) navigateOn(RouteConstantsPages.home);
        else dispatch(updateLogged(false));
    }, [logged])

    const callAuthorizetoken = () => {
        dispatch(logincallback({ useriddata: user! })).unwrap().then(
            async (response: ILoginApplicationResponse) => {
                if (response.access_token !== undefined) {
                    dispatch(updateLogged(true));
                    dispatch(openSnackBarSpocify({
                        message: "Loging successful",
                        severity: "success",
                        title: "Login",
                    }))
                }
                else dispatch(openSnackBarSpocify({
                    message: "Error validation integration spotify authorization",
                    severity: "warning",
                    title: "Login",
                }))
            });
    }




    return (<Fragment> </Fragment>);
}