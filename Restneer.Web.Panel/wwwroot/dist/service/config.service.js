"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ConfigService = /** @class */ (function () {
    function ConfigService(appModule) {
        this.appModule = appModule;
        this.restneerService = {
            host: "http://localhost:5001",
            apiKey: "e6b3c557-72c7-4fc0-a239-d4d8877d5a32"
        };
    }
    ConfigService.prototype.load = function () {
        var _this = this;
        this.appModule.factory('$ConfigService', function () { return _this; });
    };
    return ConfigService;
}());
exports.default = ConfigService;
//# sourceMappingURL=config.service.js.map