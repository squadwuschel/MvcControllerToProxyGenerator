var helpers = require('./helpers');
var webpackMerge = require('webpack-merge'); // used to merge webpack configs
var commonConfig = require('./webpack.common.js'); // the settings that are common to prod and dev

/**
 * Webpack Plugins
 */
var DefinePlugin = require('webpack/lib/DefinePlugin');
var LoaderOptionsPlugin = require('webpack/lib/LoaderOptionsPlugin');
var NormalModuleReplacementPlugin = require('webpack/lib/NormalModuleReplacementPlugin');
var WebpackMd5Hash = require('webpack-md5-hash');
var CleanWebpackPlugin = require('clean-webpack-plugin');
var CompressionPlugin = require("compression-webpack-plugin");

/**
 * Webpack Constants
 */
var ENV = process.env.NODE_ENV = process.env.ENV = 'production';
var HOST = process.env.HOST || 'localhost';
var PORT = process.env.PORT || 8080;
var METADATA = webpackMerge(commonConfig({ env: ENV }).metadata, {
    host: HOST,
    port: PORT,
    ENV: ENV,
    HMR: false
});

module.exports = function (env) {

    /**
         * https://github.com/webpack/webpack/issues/2254
         * Wenn man dynamische Übergabeparameter an WebPack übergeben möchte, die man z.B. vom BuildSystem aus füllt,
         * dann kann man das z.B. den Aufruf
         *    npm run build:dev -- --env.hello "hallo Welt" --env.test "blubb test"
         * erreichen, was die Ausgabe:
         * 
         *    Übergabe:
         *    { hello: 'hallo Welt', test: 'blubb test' }
         * 
         * erzeugt.
         */
    console.log("Übergabe:");
    console.log(env);

    /**
     * Npm Run bitte folgendermaßen aufrufen: 
     *      npm run build:prod -- --env.applicationname "Maschinenpark"
     */
    var uebergabe = { env: ENV, applicationname: "" };
    if (env !== undefined && env["applicationname"] !== undefined) {
        uebergabe.applicationname = env.applicationname;
    }


    return webpackMerge(commonConfig(uebergabe), {

        /**
         * Developer tool to enhance debugging
         *
         * See: http://webpack.github.io/docs/configuration.html#devtool
         * See: https://github.com/webpack/docs/wiki/build-performance#sourcemaps
         */
        devtool: 'source-map',

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
             */
            publicPath: "/wwwroot/",

            /**
             * Specifies the name of each output file on disk.
             * IMPORTANT: You must not specify an absolute path here!
             *
             * See: http://webpack.github.io/docs/configuration.html#output-filename
             */
            filename: '[name].[chunkhash].bundle.js',

            /**
             * The filename of the SourceMaps for the JavaScript files.
             * They are inside the output.path directory.
             *
             * See: http://webpack.github.io/docs/configuration.html#output-sourcemapfilename
             */
            sourceMapFilename: '[name].[chunkhash].bundle.map',

            /**
             * The filename of non-entry chunks as relative path
             * inside the output.path directory.
             *
             * See: http://webpack.github.io/docs/configuration.html#output-chunkfilename
             */
            chunkFilename: '[id].[chunkhash].chunk.js'
        },

        /**
         * Add additional plugins to the compiler.
         *
         * See: http://webpack.github.io/docs/configuration.html#plugins
         */
        plugins: [

          /**
           * Plugin: WebpackMd5Hash
           * Description: Plugin to replace a standard webpack chunkhash with md5.
           *
           * See: https://www.npmjs.com/package/webpack-md5-hash
           */
          new WebpackMd5Hash(),

          /**
           * die alten Dateien aus dem root Verzeichnis entfernen, da im Prod immer 
           * wieder neue Dateien erstellt werden mit einem anderen Hash
           * 
           * See: https://github.com/johnagan/clean-webpack-plugin
          */
          new CleanWebpackPlugin(["./../wwwroot/"]),

          /**
           * Plugin: DefinePlugin
           * Description: Define free variables.
           * Useful for having development builds with debug logging or adding global constants.
           *
           * Environment helpers
           *
           * See: https://webpack.github.io/docs/list-of-plugins.html#defineplugin
           */
          // NOTE: when adding more properties make sure you include them in custom-typings.d.ts
          new DefinePlugin({
              'ENV': JSON.stringify(METADATA.ENV),
              'HMR': METADATA.HMR,
              'process.env': {
                  'ENV': JSON.stringify(METADATA.ENV),
                  'NODE_ENV': JSON.stringify(METADATA.ENV),
                  'HMR': METADATA.HMR,
              }
          }),

          /**
           * Plugin: NormalModuleReplacementPlugin
           * Description: Replace resources that matches resourceRegExp with newResource
           *
           * See: http://webpack.github.io/docs/list-of-plugins.html#normalmodulereplacementplugin
           */
          new NormalModuleReplacementPlugin(
            /angular2-hmr/,
            helpers.root('config/empty.js')
          ),

          new NormalModuleReplacementPlugin(
            /zone\.js(\\|\/)dist(\\|\/)long-stack-trace-zone/,
            helpers.root('config/empty.js')
          ),

          /**
           * Plugin LoaderOptionsPlugin (experimental)
           *
           * See: https://gist.github.com/sokra/27b24881210b56bbaff7
           */
          new LoaderOptionsPlugin({
              minimize: true,
              debug: false,
              options: {

                  /**
                   * Html loader advanced options
                   *
                   * See: https://github.com/webpack/html-loader#advanced-options
                   */
                  // TODO: Need to workaround Angular 2's html syntax => #id [bind] (event) *ngFor
                  htmlLoader: {
                      minimize: true,
                      removeAttributeQuotes: false,
                      caseSensitive: true,
                      customAttrSurround: [
                        [/#/, /(?:)/],
                        [/\*/, /(?:)/],
                        [/\[?\(?/, /(?:)/]
                      ],
                      customAttrAssign: [/\)?\]?=/]
                  },

              }
          }),

          new CompressionPlugin({
             asset: "[path].gz[query]",
             algorithm: "gzip",
             test: /\.js$|\.html$/,
             threshold: 10240,
             minRatio: 0.8
          }),
        ],

        /*
         * Include polyfills or mocks for various node stuff
         * Description: Node configuration
         *
         * See: https://webpack.github.io/docs/configuration.html#node
         */
        node: {
            global: true,
            crypto: 'empty',
            process: false,
            module: false,
            clearImmediate: false,
            setImmediate: false
        }

    });
}
