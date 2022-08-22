const path = require("path");
const webpack = require("webpack");
const ExtractTextPlugin = require("extract-text-webpack-plugin");
const devFlagPlugin = new webpack.DefinePlugin({
  //__DEV__: JSON.stringify(JSON.parse(process.env.DEBUG || 'false'))
  __DEV__: false,
  __REACT_DEVTOOLS_GLOBAL_HOOK__: "({ isDisabled: true })"
});

const babelSettings = {
  cacheDirectory: true,
  plugins: [
    "@babel/plugin-transform-runtime",
    ["@babel/plugin-proposal-decorators", { legacy: true }],
    ["@babel/plugin-proposal-class-properties", { loose: true }],
    "babel-plugin-styled-components",
    "lodash"

    //"transform-react-remove-prop-types",

    // Does not work with current state - optimize later
    // "transform-react-constant-elements",
    //"add-module-exports"
  ],
  presets: [
    ["@babel/preset-env"],
    "@babel/preset-react",
    "@babel/preset-typescript"
  ]
};

module.exports = {
  mode: "production",
  //devtool: 'eval',
  entry: {
    hotel: [
      "babel-polyfill",
      "whatwg-fetch",
      path.join(__dirname, "wwwroot/js/modules/hotel", "index.tsx")
    ],
    bootstrapcss: [
      path.join(__dirname, "wwwroot/js/modules", "bootstrap-custom.js")
    ]
  },
  output: {
    path: path.join(__dirname, "wwwroot/build"),
    filename: "_[name]-bundle.js"
  },

  plugins: [
    new webpack.NoEmitOnErrorsPlugin(),
    new ExtractTextPlugin({
      filename: "_" + "[name]-bundle.css",
      allChunks: true
    }),
    new webpack.LoaderOptionsPlugin({
      minimize: true,
      debug: false
    }),
    new webpack.DefinePlugin({
      "process.env": { NODE_ENV: JSON.stringify("production") }
    }),
    new webpack.ContextReplacementPlugin(
      /moment[/\\]locale$/,
      /de|en|ru|el|it/
    ),
    //new webpack.optimize.AggressiveMergingPlugin({})
    devFlagPlugin
  ],

  resolve: {
    extensions: [".tsx", ".ts", ".mjs", ".js", ".jsx", ".less", ".css"],
    unsafeCache: true,
    alias: {
      //ui: path.resolve(__dirname, "wwwroot/js/modules/common/ui"),
      components: path.resolve(
        __dirname,
        "wwwroot/js/modules/common/components"
      ),
      sagas: path.resolve(__dirname, "wwwroot/js/modules/hotel/redux/modules"),
      services: path.resolve(__dirname, "wwwroot/js/modules/hotel/services")
    }
  },
  module: {
    rules: [
      {
        test: /\.ts(x?)$/,
        use: [
          {
            loader: "babel-loader",
            options: babelSettings
          }
          // Commented because there is a bug with styled-components css prop
          // {
          //   loader: "ts-loader",
          //   options: {
          //     transpileOnly: true
          //   }
          // }
        ],
        include: path.join(__dirname, "wwwroot/js")
      },
      {
        test: /\.js(x?)$/,
        include: path.join(__dirname, "wwwroot/js"),
        loader: "babel-loader?" + JSON.stringify(babelSettings)
      },
      { test: /\.png$/, loader: "url-loader?mimetype=image/png" },
      { test: /\.gif$/, loader: "url-loader?mimetype=image/png" },
      {
        test: /\.svg$/,
        loader:
          "url-loader?limit=65000&mimetype=image/svg+xml&name=[name].[ext]"
      },
      {
        test: /\.woff$/,
        loader:
          "url-loader?limit=65000&mimetype=application/font-woff&name=[name].[ext]"
      },
      {
        test: /\.woff2$/,
        loader:
          "url-loader?limit=65000&mimetype=application/font-woff2&name=[name].[ext]"
      },
      {
        test: /\.[ot]tf$/,
        loader:
          "url-loader?limit=65000&mimetype=application/octet-stream&name=[name].[ext]"
      },
      {
        test: /\.eot$/,
        loader:
          "url-loader?limit=65000&mimetype=application/vnd.ms-fontobject&name=name].[ext]"
      },
      {
        test: /\.css$/,
        use: ExtractTextPlugin.extract({
          fallback: "style-loader",
          use: [
            { loader: "css-loader", options: { sourceMap: false } },
            { loader: "postcss-loader", options: { sourceMap: false } }
          ]
        })
      },
      {
        test: /\.scss$/,
        include: [
          path.join(__dirname, "wwwroot/css"),
          path.join(__dirname, "wwwroot/js"),
          path.join(__dirname, "node_modules")
        ],
        use: ExtractTextPlugin.extract({
          fallback: "style-loader",
          use: [
            { loader: "css-loader", options: { sourceMap: false } },
            { loader: "postcss-loader", options: { sourceMap: false } },
            {
              loader: "sass-loader",
              options: {
                sourceMap: false
              }
            }
          ]
        })
      },
      {
        test: /\.less$/,
        include: [
          path.join(__dirname, "wwwroot/css"),
          path.join(__dirname, "wwwroot/js"),
          path.join(__dirname, "node_modules")
        ],
        use: ExtractTextPlugin.extract({
          fallback: "style-loader",
          use: [
            { loader: "css-loader" },
            {
              loader: "less-loader",
              options: {
                javascriptEnabled: true
              }
            }
          ]
        })
      }
    ]
  }
};
