"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var WebApp = /** @class */ (function () {
    function WebApp(appName, dependencies, angularJs) {
        this.appName = appName;
        this.dependencies = dependencies;
        this.angularJs = angularJs;
    }
    WebApp.prototype.setModule = function (config, run) {
        this.appModule = this.angularJs.module(this.appName, this.dependencies)
            .config(config)
            .run(run);
    };
    return WebApp;
}());
exports.default = WebApp;
//# sourceMappingURL=webapp.js.map