const { createProxyMiddleWare } = require("http-proxy-middleware");

module.exports = function (app) {
  app.use(
    "/api",
    createProxyMiddleWare({
      target: "https://localhost:7014/",
      changeOrigin: true,
      // headers: {
      //   "Access-Control-Allow-Origin": "*",
      //   "Access-Control-Allow-Methods":
      //     "GET, POST, PUT, DELETE, PATCH, OPTIONS",
      //   "Access-Control-Allow-Headers":
      //     "X-Requested-With, content-type, Authorization",
      // },
    })
  );
};
