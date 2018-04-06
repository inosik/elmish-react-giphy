var path = require('path');
var webpack = require('webpack');
var fableUtils = require('fable-utils');

function resolve(filePath) {
  return path.join(__dirname, filePath)
}

var babelOptions = fableUtils.resolveBabelOptions({
  presets: [['env', { modules: false }]],
  plugins: ['transform-runtime']
});

module.exports = {
  devtool: 'source-map',
  entry: resolve('./src/giphy.fsproj'),
  output: {
    filename: 'bundle.js',
    path: resolve('./public/'),
  },
  resolve: {
    modules: [resolve('./node_modules/')]
  },
  devServer: {
    contentBase: resolve('./public/'),
    port: 8080,
    hot: true,
    inline: true
  },
  module: {
    rules: [
      {
        test: /\.fs(x|proj)?$/,
        use: {
          loader: 'fable-loader',
          options: {
            babel: babelOptions
          }
        }
      },
      {
        test: /\.js$/,
        exclude: /node_modules/,
        use: {
          loader: 'babel-loader',
          options: babelOptions
        }
      }
    ]
  },
  plugins: [
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NamedModulesPlugin()
  ]
};
