import { Navigate } from "react-router-dom";

function ProtectedRoute({ children }) {

    const token = sessionStorage.getItem("token");

    if (token) {
        return children;
    }

    return <Navigate to="/login" replace />;
}

export default ProtectedRoute;