var path = require('path');
var webpack = require('webpack');
var scriptsDir = path.join(__dirname, './src/Fubu3TodoApp/Content/js');
var main = path.join(scriptsDir, 'App.js');
//const styles = path.join(scriptsDir, 'styles.js');
var outputDir = '/src/Fubu3TodoApp/dist/';

module.exports = {
  entry: {
    main
  },
  output: {
    path: path.join(__dirname, outputDir),
    publicPath: '/dist/',
    filename: '[name]-bundle.js'
  },
  module: {
    preLoaders: [
      {test: /\.jsx?$/, loader: 'eslint-loader', include: scriptsDir}
    ],
    loaders: [
      {test: /\.jsx?$/, loader: 'babel-loader', exclude: /node_modules/},
      {test: /\.(png|woff|woff2|eot|ttf|svg)$/, loader: 'url-loader?limit=100000'},
      {test: /\.css$/, loader: "style!css!postcss" },
      {test: /\.less$/, loader: 'style!css!postcss!less'},
      {test: /\.json$/, loader: 'json'}
    ]
  },
};