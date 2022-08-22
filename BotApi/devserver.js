let path = require("path");
let express = require("express");
let webpack = require("webpack");
let config = require("./webpack.dev.config.js");

let app = express();
let compiler = webpack(config);

app.use(
  require("webpack-dev-middleware")(compiler, {
    noInfo: true,
    // hot: true,
    publicPath: config.output.publicPath,
    headers: {
      "Access-Control-Allow-Origin": "*"
    }
  })
);

app.use(require("webpack-hot-middleware")(compiler));

app.use("/js", express.static("js/"));

app.get("*", function (req, res) {
  res.sendFile(path.join(__dirname, "index.html"));
});

app.listen(3000, "localhost", function (err) {
  if (err) {
    console.log(err);
    return;
  }

  console.log("Listening at http://localhost:3000");
});
