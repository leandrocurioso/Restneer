require('jquery');
require('angular');
require('angular-route');
require('angular-cookies');

var IndexRestneerModule = require('./wwwroot/dist/module/index-restneer/index-restneer.module.js');

try {
    var indexRestneerModule = new IndexRestneerModule.default(window.angular);
    indexRestneerModule.load();
} catch (err) {
    throw err;
}