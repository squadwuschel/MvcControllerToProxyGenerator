var helpers = require('./helpers');
var webpackMerge = require('webpack-merge'); // used to merge webpack configs
var commonConfig = require('./webpack.common.js'); // the settings that are common to prod and dev

/**
 * Webpack Plugins
 */
var DefinePlugin = require('webpack/lib/DefinePlugin');
var LoaderOptionsPlugin = require('webpack/lib/LoaderOptionsPlugin');
var WebpackNotifierPlugin = require('webpack-notifier');

/**
 * Webpack Constants
 */
var ENV = process.env.ENV = process.env.NODE_ENV = 'development';
var HOST = process.env.HOST || 'localhost';
var PORT = process.env.PORT || 3000;
var HMR = helpers.hasProcessFlag('hot'); //hot module Replacement Flag!
var METADATA = webpackMerge(commonConfig({ env: ENV }).metadata, {
    host: HOST,
    port: PORT,
    ENV: ENV,
    HMR: HMR
});



/**
 * Webpack configuration
 *
 * See: http://webpack.github.io/docs/configuration.html#cli
 */
module.exports = function (options) {
    //Wir fassen die allgemeine Konfiguration die für alle Builds gültig ist, mir der jeweiligen Dev oder Produktion Konfiguratiuon zusammen.
    //mit der Hilfe von webpackMerge
    return webpackMerge(commonConfig({ env: ENV }), {

        /**
         * Developer tool to enhance debugging
         *
         * See: http://webpack.github.io/docs/configuration.html#devtool
         * See: https://github.com/webpack/docs/wiki/build-performance#sourcemaps
         */
        devtool: 'cheap-module-source-map',

        /**
         * Options affecting the output of the compilation.
         *
         * See: http://webpack.github.io/docs/configuration.html#output
         */
        output: {

            /**
             * The output directory as absolute path (required).
             *
             * See: http://webpack.github.io/docs/configuration.html#output-path
             */
            path: helpers.root('wwwroot'),
            
            /**
             * Sorgt dafür, das in den Generierten Dateien für Scripts die komplette URL angeben wird.
             * 
             * Example: publicPath: "http://" + METADATA.host + ":" + METADATA.port + "/wwwroot/",
             * 
             * Wir verwenden "/wwwroot/" da wir zwar die Index Datei aus dem Verzeichnis laden, aber alle
             * HTTP Abfragen für Scripts und co auf das Root Verzeichnis gehen und wir die generierten Script
             * im wwwroot Ordner ablegen
             * 
             * Wir prüfen ob HMR verwendet werden soll und wenn ja die URL eintragen, sonst einfach nur das passende Root Vertzeichnis nehmen.
             */ 
            publicPath: "/wwwroot/",
           // publicPath: "http://" + METADATA.host + ":" + METADATA.port + "/wwwroot/",

            /**
             * Specifies the name of each output file on disk.
             * IMPORTANT: You must not specify an absolute path here!
             *
             * See: http://webpack.github.io/docs/configuration.html#output-filename
             */
            filename: '[name].bundle.js',

            /**
             * The filename of the SourceMaps for the JavaScript files.
             * They are inside the output.path directory.
             *
             * See: http://webpack.github.io/docs/configuration.html#output-sourcemapfilename
             */
            sourceMapFilename: '[name].map',

            /** The filename of non-entry chunks as relative path
             * inside the output.path directory.
             *
             * See: http://webpack.github.io/docs/configuration.html#output-chunkfilename
             */
            chunkFilename: '[id].chunk.js',
            library: 'ac_[name]',
            libraryTarget: 'var'
        },
        devtool: "source-map",
        plugins: [

          /**
           * Plugin: DefinePlugin
           * Description: Define free variables.
           * Useful for having development builds with debug logging or adding global constants.
           *
           * Environment helpers
           *
           * See: https://webpack.github.io/docs/list-of-plugins.html#defineplugin
           */
          // NOTE: when adding more properties, make sure you include them in custom-typings.d.ts
          new DefinePlugin({
              'ENV': JSON.stringify(METADATA.ENV),
              'HMR': METADATA.HMR,
              'process.env': {
                  'ENV': JSON.stringify(METADATA.ENV),
                  'NODE_ENV': JSON.stringify(METADATA.ENV),
                  'HMR': METADATA.HMR
              }
          }),

          /**
           * Plugin LoaderOptionsPlugin (experimental)
           * webpack 2 brings native support ES6 Modules. This means webpack now understands  import  and  export  without them being transformed to CommonJS:
           *
           * See: https://gist.github.com/sokra/27b24881210b56bbaff7
           */
          new LoaderOptionsPlugin({
              debug: true,
              options: { }
          }),

          /**
           * Zeigt Systemmeldungen unten rechts an wenn webpack neu compilliert hat.
           */
          new WebpackNotifierPlugin()
        ],

        /**
         * Webpack Development Server configuration
         * Description: The webpack-dev-server is a little node.js Express server.
         * The server emits information about the compilation state to the client,
         * which reacts to those events.
         *
         * See: https://webpack.github.io/docs/webpack-dev-server.html
         */
        devServer: {
            port: METADATA.port,
            host: METADATA.host,
            historyApiFallback: true,
            watchOptions: {
                aggregateTimeout: 300,
                poll: 1000
            }
        },

        /*
         * Include polyfills or mocks for various node stuff
         * Description: Node configuration
         *
         * See: https://webpack.github.io/docs/configuration.html#node
         */
        node: {
            global: true,
            crypto: 'empty',
            process: true,
            module: false,
            clearImmediate: false,
            setImmediate: false
        }

    });
}
