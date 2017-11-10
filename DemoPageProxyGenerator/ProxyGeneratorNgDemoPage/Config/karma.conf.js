var webpackConfig = require('./webpack.test.js');

module.exports = function (config) {
    config.set({
        basePath: '',
        frameworks: ['jasmine'],

        files: [ 'karma.entry.js' ],

        preprocessors: {
            'karma.entry.js': ['webpack', 'sourcemap']
        },
        phantomJsLauncher: {
            exitOnResourceError: false
        },
        webpack: webpackConfig,

        webpackMiddleware: {
            stats: 'errors-only'
        },

        webpackServer: {
            noInfo: true
        },

        reporters: ['progress'],
        port: 9876,
        colors: true,
        logLevel: config.LOG_INFO,
        autoWatch: true,
        browsers: ['PhantomJS'],
        singleRun: true
    });
};