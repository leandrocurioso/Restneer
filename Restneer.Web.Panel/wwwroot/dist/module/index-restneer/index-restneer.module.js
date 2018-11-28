"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    }
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var webapp_1 = require("../webapp");
var http_service_1 = require("../../service/http.service");
var index_restneer_login_controller_1 = require("../../module/index-restneer/controller/index-restneer.login.controller");
var api_user_service_1 = require("../../service/api-user.service");
var restneer_service_1 = require("../../service/restneer.service");
var config_service_1 = require("../../service/config.service");
var IndexRestneerModule = /** @class */ (function (_super) {
    __extends(IndexRestneerModule, _super);
    function IndexRestneerModule(angularJs) {
        return _super.call(this, "IndexRestneerModule", IndexRestneerModule.dependencies, angularJs) || this;
    }
    IndexRestneerModule.prototype.load = function () {
        _super.prototype.setModule.call(this, this.config, this.run);
        this.loadServices();
        this.loadControllers();
    };
    IndexRestneerModule.prototype.loadServices = function (services) {
        if (services === void 0) { services = [
            new config_service_1.default(this.appModule),
            new http_service_1.default(this.appModule),
            new restneer_service_1.default(this.appModule),
            new api_user_service_1.default(this.appModule)
        ]; }
        services.forEach(function (service) {
            service.load();
        });
    };
    IndexRestneerModule.prototype.loadControllers = function (controllers) {
        if (controllers === void 0) { controllers = [
            new index_restneer_login_controller_1.default(this.appModule)
        ]; }
        controllers.forEach(function (controller) {
            controller.load();
        });
    };
    IndexRestneerModule.prototype.config = function ($routeProvider, $cookiesProvider) {
        $routeProvider.when('/', {
            templateUrl: 'module/index-restneer/index-restneer-login.view.html',
            controller: 'LoginController',
            controllerAs: 'vm',
            reloadOnSearch: false
        });
    };
    IndexRestneerModule.prototype.run = function ($rootScope, $window) {
    };
    IndexRestneerModule.dependencies = [
        'ngRoute', 'ngCookies'
    ];
    return IndexRestneerModule;
}(webapp_1.default));
exports.default = IndexRestneerModule;
//# sourceMappingURL=index-restneer.module.js.map