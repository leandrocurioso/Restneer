"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var $HttpService = /** @class */ (function () {
    function $HttpService(angularJs) {
        this.angularJs = angularJs;
    }
    $HttpService.prototype.load = function () {
        this.angularJs.module('IndexRestneerModule').factory('$HttpService', function ($rootScope, $http, $cookies) {
            var service = {};
            return service;
        });
    };
    return $HttpService;
}());
exports.default = $HttpService;
//# sourceMappingURL=http.service.js.map