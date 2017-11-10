/// <binding ProjectOpened='Watch - Development' />
// Look in ./Scripts/_config folder for dev or Production Configs
switch (process.env.NODE_ENV) {
    case 'prod':
    case 'production':
        module.exports = require('./Config/webpack.prod')({ env: 'production' });
        break;
    case 'dev':
    case 'development':
        module.exports = require('./Config/webpack.dev')({ env: 'development' });
}