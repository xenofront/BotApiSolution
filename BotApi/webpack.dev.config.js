const path = require("path");
const webpack = require("webpack");
const devFlagPlugin = new webpack.DefinePlugin({
  __DEV__: false,
  __REACT_DEVTOOLS_GLOBAL_HOOK__: "({ isDisabled: true })"
});
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const TsconfigPathsPlugin = require("tsconfig-paths-webpack-plugin");

const babelSettings = {
  cacheDirectory: true,
  plugins: [
    "@babel/plugin-transform-runtime",
    ["@babel/plugin-proposal-decorators", { legacy: true }],
    ["@babel/plugin-proposal-private-methods", { loose: true }],
    ["@babel/plugin-proposal-class-properties", { loose: true }],
    // ["@babel/plugin-proposal-private-property-in-object", { loose: true }],
    "add-module-exports",
    "react-hot-loader/babel"
  ],
  presets: [
    ["@babel/preset-env"],
    "@babel/preset-react",
    "@babel/preset-typescript"
  ]
};

module.exports = {
  mode: "development",
  devtool: "cheap-module-source-map",
  devtool: "eval",
  entry: {
    app: [
      "webpack-hot-middleware/client?path=http://localhost:3000/__webpack_hmr",
      "whatwg-fetch",
      path.join(__dirname, "wwwroot/js/app", "index.tsx")
    ]
    // bootstrapcss: [
    //   //'webpack-hot-middleware/client?path=http://localhost:3000/__webpack_hmr', //HOT RELOAD! )
    //   path.join(__dirname, "wwwroot/js/modules", "bootstrap-custom.js")
    // ]
  },
  output: {
    path: path.join(__dirname, "wwwroot/js"),
    filename: "_[name]-bundle.js",
    publicPath: "http://localhost:3000/js"
  },
  plugins: [
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NoEmitOnErrorsPlugin(),
    new ExtractTextPlugin({
      filename: "_" + "[name]-bundle.css",
      allChunks: true
    }),
    devFlagPlugin
  ],
  resolve: {
    plugins: [new TsconfigPathsPlugin()],
    extensions: [".tsx", ".ts", ".js", ".jsx", ".less", ".css"],
    unsafeCache: true
  },
  module: {
    rules: [
      {
        test: /\.js(x?)$/,
        include: path.join(__dirname, "wwwroot/js"),
        exclude: /node_modules/,
        use: {
          loader: "babel-loader"
        }
      },
      {
        include: path.join(__dirname, "wwwroot/js"),
        test: /\.ts(x?)$/,
        exclude: /node_modules/,
        use: [
          {
            loader: "babel-loader",
            options: babelSettings
          }
        ],
        include: path.join(__dirname, "wwwroot/js")
      },
      {
        test: /\.(sass|css|scss|less)$/,
        include: [
          path.join(__dirname, "wwwroot/js"),
          path.join(__dirname, "wwwroot/css"),
          path.join(__dirname, "node_modules")
        ],
        loaders: [
          "style-loader",
          "css-loader",
          "sass-loader",
          "postcss-loader",
          "less-loader"
        ]
        // use: ExtractTextPlugin.extract({
        //   fallback: "style-loader",
        //   use: [
        //     {
        //       loader: MiniCssExtractPlugin.loader,
        //       options: { sourceMap: true }
        //     },
        //     { loader: "style-loader", options: { sourceMap: true } },
        //     { loader: "sass-loader", options: { sourceMap: true } },
        //     { loader: "postcss-loader", options: { sourceMap: true } },
        //     { loader: "less-loader", options: { javascriptEnabled: true } },
        //     { loader: "postcss-loader" }
        //   ]
        // })
      },
      {
        test: /\.svg$/,
        loader:
          "url-loader?limit=65000&mimetype=image/svg+xml&name=[name].[ext]"
      }
      // {
      //   test: /\.css$/,
      //   include: [
      //     path.join(__dirname, "wwwroot/js"),
      //     path.join(__dirname, "wwwroot/css"),
      //     path.join(__dirname, "node_modules")
      //   ],
      //   // use: ExtractTextPlugin.extract({
      //   //   fallback: "style-loader",
      //   //   use: [
      //   //     { loader: "css-loader", options: { sourceMap: true } },
      //   //     { loader: "postcss-loader", options: { sourceMap: true } }
      //   //   ]
      //   // })
      //   loaders: ["style-loader", "css-loader"]
      // },
      // {
      //   test: /\.scss$/,
      //   include: [
      //     path.join(__dirname, "wwwroot/js"),
      //     path.join(__dirname, "wwwroot/css"),
      //     path.join(__dirname, "node_modules")
      //   ],
      //   loaders: ["style-loader", "css-loader", "postcss-loader", "sass-loader"]
      // },
      // {
      //   test: /\.less$/,
      //   include: [
      //     path.join(__dirname, "wwwroot/css"),
      //     path.join(__dirname, "wwwroot/js"),
      //     path.join(__dirname, "node_modules")
      //   ],
      //   use: ExtractTextPlugin.extract({
      //     fallback: "style-loader",
      //     use: [
      //       { loader: "css-loader" },
      //       { loader: "less-loader", options: { javascriptEnabled: true } }
      //     ]
      //   })
      // }
    ]
  }
};
