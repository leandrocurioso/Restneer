"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ConfigService = /** @class */ (function () {
    function ConfigService(appModule) {
        this.appModule = appModule;
    }
    ConfigService.prototype.load = function () {
        var _this = this;
        this.appModule.factory('$ConfigService', function () { return _this; });
    };
    return ConfigService;
}());
exports.default = ConfigService;
//# sourceMappingURL=config.service.js.map