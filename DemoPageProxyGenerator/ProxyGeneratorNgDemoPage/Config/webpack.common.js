var webpack = require('webpack');
var helpers = require('./helpers');
var path = require('path');
var chalk = require('chalk');

var HtmlWebpackPlugin = require('html-webpack-plugin');
var CommonsChunkPlugin = require('webpack/lib/optimize/CommonsChunkPlugin');
var ContextReplacementPlugin = require('webpack/lib/ContextReplacementPlugin');
var ExtractTextPlugin = require('extract-text-webpack-plugin');

//Quellen:
//https://blog.madewithenvy.com/getting-started-with-webpack-2-ed2b86c68783#.7gpzskxfq


/*
 * Webpack Constants
 */
var HMR = helpers.hasProcessFlag('hot');
var METADATA = {
    baseUrl: "/",
    applicationname: "WebLogViewer",
    isDevServer: helpers.isWebpackDevServer()
};

module.exports = function (options) {
    var isProd = options.env === 'production';

    //wir können den Applicationnamen, direkt als Parameter mit übergeben, dieser wird in der 
    //webpack.prod.js ausgewertet und hier entsprechend übergeben, was für automatisierte Builds wichtig ist.
    if (options.applicationname !== undefined) {
        console.log("Anwendungsname Übergabe: " + options.applicationname);
        METADATA.applicationname = options.applicationname;
    }
    
    //die BaseUrl wird benötigt um diese in der index.html entsprechend zu setzen.
    //Im Produktionmodus muss hier der Name der Anwendung eingetragen werden, da diese bei
    //uns immer als SubAnwendung angelegt werden.
    if (isProd) {
        METADATA.baseUrl = "/" + METADATA.applicationname + "/";
    }

    return {
        entry: {
            'polyfills': './App/AppShared/Build/polyfills.ts',
            'vendors': './App/AppShared/Build/vendors.ts',
            'app': './App/AppShared/Build/boot.ts',
        },

        resolve: {
            /*
            * An array of extensions that should be used to resolve modules.
            * Wenn die Endung beim Import in den TypeScript dateien nicht angegeben wird,
            * dann wird versucht die fehlende Endung mit den Endungen hier "wiederherzustellen"
            *
            * See: http://webpack.github.io/docs/configuration.html#resolve-extensions
            */
            extensions: ['.ts', '.js', '.json', '.css', '.scss', '.less']
        },
        module: {
            rules: [
                /*
                * Typescript loader support for .ts and Angular 2 async routes via .async.ts
                * Replace templateUrl and stylesUrl with require()
                *
                * See: https://github.com/s-panferov/awesome-typescript-loader
                * See: https://github.com/TheLarkInn/angular2-template-loader
                */
                {
                    test: /\.ts$/,
                    //kümmert sich um das Erstellen von js code aus TypeScript und wandelt die passenden
                    //relativen templateUrl aufrufe in ein Konstrukt um das der html Loader versteht.
                    use: [
                        '@angularclass/hmr-loader?pretty=' + !isProd + '&prod=' + isProd, //HMR = Hot Module Replacement!
                        'awesome-typescript-loader',
                        'angular2-template-loader'
                    ],
                    //die Dateien für Unit Tests nicht mit übersetzen
                    exclude: [/\.(spec|e2e)\.ts$/]
                },

                /*
                * SASS Loader for the CONTENT FOLDER
                * Geht aktuell nur GENAU SO, FallBack muss angeben sein, sonst kommt es zu einem Fehler "unbekanntes Token ..."
                * //https://github.com/jtangelder/sass-loader/issues/287
                * Der SASS Loader geht nur wenn "loader" davor steht NICHT wenn "use" wie bei Webpack 2 vorgesehen.
                *
                */
                 {
                     test: /\.scss$/,
                     loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: ['css-loader', 'sass-loader'] }),
                     exclude: [helpers.root('App')],
                     include: [helpers.root('Content')]
                 },

                 /**
                  * LESS Loader for the CONTENT FOLDER
                  * Der Less Loader geht nur wenn "loader" davor steht NICHT wenn "use" wie bei Webpack 2 vorgesehen.
                  */
                 {
                     test: /\.less$/,
                     loader: ExtractTextPlugin.extract({ fallback: 'style-loader', use: ['css-loader', 'less-loader'] }),
                     exclude: [helpers.root('App')],
                     include: [helpers.root('Content')]
                 },

                /**
                 * SASS Loader for the APP FOLDER
                 * Der SASS Loader für die Components StyleUrls wie z.B.  styleUrls: [ './logmonitor.component.scss' ],
                 * https://github.com/webpack-contrib/extract-text-webpack-plugin/issues/263
                 */
                {
                    test: /\.scss$/,
                    loader: [
                        { loader: 'raw-loader' },
                        { loader: 'sass-loader', query: { sourceMaps: true } },
                        { loader: 'postcss-loader' }
                    ],
                    exclude: [helpers.root('Content')],
                    include: [helpers.root('App')]
                },

                 /**
                  * LESS Loader for the APP FOLDER
                  * Der Less Loader geht nur wenn "loader" davor steht NICHT wenn "use" wie bei Webpack 2 vorgesehen.
                  * LESS Loader für die Components StyleUrls wie z.B. styleUrls: [ './logmonitor.component.less' ],
                  */
                 {
                     test: /\.less$/,
                     loader: [
                        { loader: 'raw-loader' },
                        { loader: 'less-loader', query: { sourceMaps: true } },
                        { loader: 'postcss-loader' }
                     ],
                     exclude: [helpers.root('Content')],
                     include: [helpers.root('App')]
                 },

                 /**
                  * Loader für die Dateiendungen die in den CSS Dateien verwendet werden. 
                  * z.B. zum Laden der passenden Fonts für Font Awesome. Hier muss darauf geachtet werden, 
                  * das der publicPath: "/wwwroot/" entsprechend auf das ausgabeverzeichnis gesetzt ist, 
                  * dann wird dieser auch in den Styles für fontawesome gesetzt, darum kümmert sich WebPack.
                  */
                 {
                     test: /\.(woff|woff2)(\?v=\d+\.\d+\.\d+)?$/,
                     use: 'url-loader?limit=65000&mimetype=application/font-woff'
                 },
                 {
                     test: /\.ttf(\?v=\d+\.\d+\.\d+)?$/,
                     use: 'url-loader?limit=65000&mimetype=application/octet-stream'
                 },
                 {
                     test: /\.eot(\?v=\d+\.\d+\.\d+)?$/,
                     use: 'file-loader'
                 },
                 {
                     test: /\.svg(\?v=\d+\.\d+\.\d+)?$/,
                     loader: "svg-url-loader?limit=65000&mimetype=image/svg+xml"
                 },

                 /* Raw loader support for *.html
                  * Returns file content as string
                  *
                  * See: https://github.com/webpack/raw-loader
                 */
                 {
                     test: /\.html$/,
                     use: ['raw-loader'],
                     //Exclude ist Notwendig, damit die "HtmlWebpackPlugin" Templates im Dokument ersetzt werden können wie baseUrl
                     //wird Exclude NICHT gesetzt, dann wird z.B. BaseUrl nicht ersetzt vom "HtmlWebpackPlugin"
                     exclude: [helpers.root('App/index.html')]
                 },

                  /* File loader for supporting images, for example, in CSS files.
                   */
                  {
                      test: /\.(jpg|png|gif)$/,
                      use: 'file-loader'
                  }
            ]
        },

        plugins: [
                 /*
                 * Plugin: CommonsChunkPlugin
                 * Description: Shares common code between the pages.
                 * It identifies common modules and put them into a commons chunk.
                 *
                 * See: https://webpack.github.io/docs/list-of-plugins.html#commonschunkplugin
                 * See: https://github.com/webpack/docs/wiki/optimization#multi-page-app
                 */
                 new CommonsChunkPlugin({
                     name: ['polyfills', 'vendors'].reverse()
                 }),

                 /**
                 * Plugin: ContextReplacementPlugin
                 * Description: Provides context to Angular's use of System.import
                 *                 *
                 * See: https://webpack.github.io/docs/list-of-plugins.html#contextreplacementplugin
                 * Sonst kommt es immer zu einer Warnung beim Erstellen mit Webpack "systemjs...." :
                 * See: https://github.com/angular/angular/issues/11580
                 */
                 new ContextReplacementPlugin(
                    // The (\\|\/) piece accounts for path separators in *nix and Windows
                    //https://github.com/angular/angular/issues/11580#issuecomment-282705332
                     /(.+)?angular(\\|\/)core(.+)?/,
                    helpers.root('App'), // location of your src
                    {
                        // your Angular Async Route paths relative to this root directory
                    }),

                /*
                * Plugin: HtmlWebpackPlugin
                * Description: Simplifies creation of HTML files to serve your webpack bundles.
                * This is especially useful for webpack bundles that include a hash in the filename
                * which changes every compilation.
                * 
                * Setzt außerdem den BaseUrl in der Anwendung über ein einfaches "Template":
                *  <base href="<%= htmlWebpackPlugin.options.metadata.baseUrl %>">
                *
                * See: https://github.com/ampedandwired/html-webpack-plugin
                */
                new HtmlWebpackPlugin({
                    template: 'App/index.html',
                    baseUrl: METADATA.baseUrl,
                    chunksSortMode: 'dependency',
                    metadata: METADATA,
                }),

                /*
                 * Plugin kümmert sich darum, das die Styles in extra Dateien ausgelagert werden, dafür muss
                 * auch im Loader darauf zugegriffen werden.
                 * 
                 * See: https://github.com/webpack/extract-text-webpack-plugin#api
                 */
                 new ExtractTextPlugin({
                     filename: "[name].css",
                     //  disable: false,
                     //  allChunks: true
                 }),

            /**
            * Einfache PluginFunktion, die in der Console ausgibt, wann der letzte Compile Vorgang ausgeführt wurde.
            */
            function () {
                this.plugin('watch-run',
                    function (watching, callback) {
                        console.log('Compiletime at => ' + new Date());
                        callback();
                        var inter = setInterval(function () {
                            if (!watching.running) {
                                console.log(chalk.green('Compile done!'));
                                clearInterval(inter);
                            }
                        }, 100);
                    });
            }
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
            process: true,
            module: false,
            clearImmediate: false,
            setImmediate: false
        }
    };
}