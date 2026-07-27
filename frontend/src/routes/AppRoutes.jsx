/*
=====================================
Application Routing
=====================================
*/

import React from "react";

import {

    Routes,

    Route

} from "react-router-dom";


// Pages

import Home from "../pages/Home/Home";

import Login from "../pages/Login/Login";

import Register from "../pages/Register/Register";

import About from "../pages/About/About";

import Contact from "../pages/Contact/Contact";


const AppRoutes = () => {

    return(

        <Routes>

            {/* Home */}

            <Route

                path="/"

                element={<Home/>}

            />

            {/* Login */}

            <Route

                path="/login"

                element={<Login/>}

            />

            {/* Register */}

            <Route

                path="/register"

                element={<Register/>}

            />

            {/* About */}

            <Route

                path="/about"

                element={<About/>}

            />

            {/* Contact */}

            <Route

                path="/contact"

                element={<Contact/>}

            />

        </Routes>

    );

};

export default AppRoutes;