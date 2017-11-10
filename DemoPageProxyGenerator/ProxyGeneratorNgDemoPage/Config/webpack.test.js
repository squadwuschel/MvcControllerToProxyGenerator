var webpack = require('webpack');
var helpers = require('./helpers');

module.exports = {
    devtool: 'inline-source-map',

    resolve: {
        extensions: ['.ts', '.js']
    },

    module: {
        rules: [
          {
              test: /\.ts$/,
              loaders: ['awesome-typescript-loader', 'angular2-template-loader']
          },
          {
              test: /\.html$/,
              loader: 'html-loader'

          },
          {
              test: /\.(png|jpe?g|gif|svg|woff|woff2|ttf|eot|ico)$/,
              loader: 'null-loader'
          },
          {
              test: /\.scss$/,
              exclude: helpers.root('App'),
              loader: 'null-loader'
          },
          {
              test: /\.scss$/,
              include: helpers.root('App'),
              loader: 'raw-loader'
          }
        ]
    },

    plugins: [
      new webpack.ContextReplacementPlugin(
        // The (\\|\/) piece accounts for path separators in *nix and Windows
        /angular(\\|\/)core(\\|\/)(esm(\\|\/)src|src)(\\|\/)linker/,
        helpers.root('./App'), // location of your src
        {} // a map of your routes
      )
    ]
}