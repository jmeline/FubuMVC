import path from 'path';
import webpack from 'webpack';
import ExtractTextPlugin from 'extract-text-webpack-plugin';
const scriptsDir = path.join(__dirname, './src/Fubu3TodoApp/Content/js');
const main = path.join(scriptsDir, 'app.jsx');
// const styles = path.join(scriptsDir, 'styles.js');
const outputDir = './src/Fubu3TodoApp/dist/';

export default {
  entry: { main },
  output: {
    path: outputDir,
    publicPath: outputDir,
    filename: '[name]-bundle.js'
  },
  module: {
    preLoaders: [
      { test: /\.jsx?$/, loader: 'eslint-loader', include: scriptsDir }
    ],
    loaders: [
      {test: /\.jsx?$/, loader: 'babel-loader', exclude: /node_modules/ },
      {
        test: /\.(eot|svg|ttf|woff(2)?)(\?v=\d+\.\d+\.\d+)?/,
        loader: 'url'
      },
      {test: /\.css$/, loader: ExtractTextPlugin.extract('style', 'css')},
      {test: /\.less$/, loader: 'style!css!postcss!less'},
      {test: /\.json$/, loader: 'json'}
    ]
  },
  plugins: [
    new ExtractTextPlugin('bundle.css')
  ]
};

