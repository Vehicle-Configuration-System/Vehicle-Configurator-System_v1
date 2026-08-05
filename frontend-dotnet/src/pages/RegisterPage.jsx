import { useState } from "react";
import { Link } from "react-router-dom";
import { useNavigate } from "react-router-dom";
function RegisterPage() {
const navigate = useNavigate();
  const [user, setUser] = useState({

  companyName: "",
  companyAddress: "",
  username: "",
  email: "",
  mobile: "",
  gstNo: "",
  registrationNo: "",
  stNo: "",
  vatNo: "",
  taxNo: "",
  designation: "",
  password: "",
  confirmPassword: ""

});

  const handleChange = (e) => {

    setUser({

        ...user,

        [e.target.name]: e.target.value

    });

};

 const handleRegister = async(e) => {

    e.preventDefault();

    if(user.companyName.trim().length < 3){

        alert("Company Name must contain at least 3 characters");

        return;

    }

    if(user.companyAddress.trim().length < 10){

        alert("Please enter complete Company Address");

        return;

    }

    if(user.username.trim().length < 5){

    alert("Username must be at least 5 characters");

    return;

}

    const emailPattern=/^[^ ]+@[^ ]+\.[a-z]{2,3}$/;

    if(!emailPattern.test(user.email)){

        alert("Enter valid Email Address");

        return;

    }

    const mobilePattern=/^[6-9]\d{9}$/;

    if(!mobilePattern.test(user.mobile)){

        alert("Enter valid 10 digit Mobile Number");

        return;

    }

    if(user.gstNo.trim() === ""){

    alert("Please enter GST Number");

    return;

}

    if(user.registrationNo.trim()===""){

        alert("Enter Company Registration Number");

        return;

    }

    if(user.stNo.trim()===""){

        alert("Enter Company ST Number");

        return;

    }

    if(user.vatNo.trim()===""){

        alert("Enter Company VAT Number");

        return;

    }

    if(user.taxNo.trim()===""){

        alert("Enter Company Tax Number");

        return;

    }

    if(user.designation.trim()===""){

        alert("Enter Designation");

        return;

    }

    if(user.password.length < 8){

    alert("Password must be at least 8 characters");

    return;

}

    if(user.password!==user.confirmPassword){

        alert("Passwords do not match");

        return;

    }

try {

    const response = await fetch("http://localhost:5115/user/register", {

        method: "POST",

        headers: {
            "Content-Type": "application/json"
        },

        body: JSON.stringify(user)

    });

    const message = await response.text();

    alert(message);
    if (response.ok) {

    navigate("/login");

}

}
catch(error){

    alert("Server Error");

}
};
  return (
  <div className="container-fluid login-bg">

    <div className="row justify-content-center align-items-center py-5">

      <div className="col-lg-8 col-md-10">

        <div className="card shadow-lg border-0 rounded-4">

          <div className="card-body p-5">

            <h2 className="text-center text-success mb-4">
              Company Registration
            </h2>

            <form onSubmit={handleRegister}>

              <div className="row">

                {/* Company Name */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Company Name
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="companyName"
                    value={user.companyName}
                    onChange={handleChange}
                    placeholder="Enter Company Name"
                  />

                </div>

                {/* Username */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    User name
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="username"
                    value={user.username}
                    onChange={handleChange}
                    placeholder="Enter Username"
                  />

                </div>

                {/* Company Address */}

                <div className="col-12 mb-3">

                  <label className="form-label">
                    Company Address
                  </label>

                  <textarea
                    className="form-control"
                    rows="3"
                    name="companyAddress"
                    value={user.companyAddress}
                    onChange={handleChange}
                    placeholder="Enter Company Address"
                  ></textarea>

                </div>

                {/* Email */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Email Address
                  </label>

                  <input
                    type="email"
                    className="form-control"
                    name="email"
                    value={user.email}
                    onChange={handleChange}
                    placeholder="Enter Email Address"
                  />

                </div>

                {/* Mobile */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Mobile Number
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="mobile"
                    value={user.mobile}
                    onChange={handleChange}
                    placeholder="Enter Mobile Number"
                  />

                </div>

                {/* GST Number */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Company GST No.
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="gstNo"
                    value={user.gstNo}
                    onChange={handleChange}
                    placeholder="Enter GST Number"
                  />

                </div>

                {/* Registration Number */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Company Registration No.
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="registrationNo"
                    value={user.registrationNo}
                    onChange={handleChange}
                    placeholder="Enter Registration Number"
                  />

                </div>

                {/* ST Number */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Company ST No.
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="stNo"
                    value={user.stNo}
                    onChange={handleChange}
                    placeholder="Enter ST Number"
                  />

                </div>

                {/* VAT Number */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Company VAT No.
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="vatNo"
                    value={user.vatNo}
                    onChange={handleChange}
                    placeholder="Enter VAT Number"
                  />

                </div>

                {/* TAX Number */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Company Tax No.
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="taxNo"
                    value={user.taxNo}
                    onChange={handleChange}
                    placeholder="Enter Tax Number"
                  />

                </div>

                {/* Designation */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Designation
                  </label>

                  <input
                    type="text"
                    className="form-control"
                    name="designation"
                    value={user.designation}
                    onChange={handleChange}
                    placeholder="Enter Designation"
                  />

                </div>

                {/* Password */}

                <div className="col-md-6 mb-3">

                  <label className="form-label">
                    Password
                  </label>

                  <input
                    type="password"
                    className="form-control"
                    name="password"
                    value={user.password}
                    onChange={handleChange}
                    placeholder="Enter Password"
                  />

                </div>

                {/* Confirm Password */}

                <div className="col-md-6 mb-4">

                  <label className="form-label">
                    Confirm Password
                  </label>

                  <input
                    type="password"
                    className="form-control"
                    name="confirmPassword"
                    value={user.confirmPassword}
                    onChange={handleChange}
                    placeholder="Confirm Password"
                  />

                </div>

              </div>

              <button
                type="submit"
                className="btn btn-success w-100 py-2 fw-bold"
              >
                Register
              </button>

            </form>

            <div className="text-center mt-4">

              Already have an account?

              <Link
                to="/login"
                className="ms-2 text-decoration-none fw-bold"
              >
                Login
              </Link>

            </div>

          </div>

        </div>

      </div>

    </div>

  </div>
);
}
  export default RegisterPage;