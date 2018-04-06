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

var isProd = process.argv.indexOf('-p') >= 0;

module.exports = {
  devtool: isProd ? undefined : 'source-map',
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
            define: isProd ? [] : ["DEBUG"],
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
  plugins: isProd ? [] : [
    new webpack.HotModuleReplacementPlugin(),
    new webpack.NamedModulesPlugin()
  ]
};
