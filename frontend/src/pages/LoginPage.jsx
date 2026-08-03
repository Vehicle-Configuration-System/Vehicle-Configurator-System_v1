import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";

function LoginPage() {

  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = (e) => {

    e.preventDefault();

    if(email.trim() === ""){

        alert("Email is required");

        return;

    }

    const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]{2,}$/;

    if(!emailPattern.test(email)){

        alert("Please enter a valid Email Address");

        return;

    }

    if(password.trim() === ""){

        alert("Password is required");

        return;

    }

    fetch("http://localhost:8080/user/login", {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    },
    body: JSON.stringify({
        email,
        password
    })
})
.then((response) => {

    if(!response.ok){

        throw new Error("Invalid Email or Password");

    }

    return response.json();

})
.then((data) => {

    sessionStorage.setItem("token", data.token);
    sessionStorage.setItem("userId", data.userId);
    sessionStorage.setItem("username", data.username);

    alert("Login Successful");

    navigate("/vehicle-selection");

})
.catch((error) => {

    alert(error.message);

});

};

  return (
    <div className="container-fluid login-bg">

      <div className="row justify-content-center align-items-center vh-100">

        <div className="col-md-4">

          <div className="card shadow p-4">

            <h2 className="text-center mb-4 text-primary">
              Login
            </h2>

            <form onSubmit={handleLogin}>

              <div className="mb-3">
                <label>Email</label>

                <input
                       type="email"
                        className="form-control"
                         placeholder="Enter Email"
                          value={email}
                            maxLength={50}
                              onChange={(e) => setEmail(e.target.value)}
/>
              </div>

              <div className="mb-3">
                <label>Password</label>

                <input
                     type="password"
                      className="form-control"
                      placeholder="Enter Password"
                      value={password}
                       maxLength={20}
                       onChange={(e) => setPassword(e.target.value)}
/>
              </div>

              <button
                type="submit"
                className="btn btn-primary w-100"
              >
                Login
              </button>

            </form>

            <p className="text-center mt-3">
              Don't have an account?

              <Link
                to="/register"
                className="btn btn-link"
              >
                Register
              </Link>

            </p>

          </div>

        </div>

      </div>

    </div>
  );
}

export default LoginPage;