import React from "react";
import { Outlet } from "react-router-dom";
import Navbar from "./Navbar";
import { HelmetProvider } from "react-helmet-async";

const Layout = () => {
  return (
    <>
      <HelmetProvider>
        <Navbar />
        <Outlet />
      </HelmetProvider>
    </>
  );
};

export default Layout;
