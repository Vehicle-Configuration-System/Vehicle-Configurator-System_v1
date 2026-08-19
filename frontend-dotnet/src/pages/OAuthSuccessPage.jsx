import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

function OAuthSuccess() {

    const navigate = useNavigate();

    useEffect(() => {

        const params = new URLSearchParams(window.location.search);

        const token = params.get("token");
        const userId = params.get("userId");
        const username = params.get("username");


        if(token && userId && username){

            console.log("OAuth Data Received");

            sessionStorage.setItem("token", token);
            sessionStorage.setItem("userId", userId);
            sessionStorage.setItem("username", username);

        }


        navigate("/vehicle-selection");


    }, [navigate]);


    return (
        <h2>Google Login Successful</h2>
    );
}

export default OAuthSuccess;