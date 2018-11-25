"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var IndexRestneerLoginControler = /** @class */ (function () {
    function IndexRestneerLoginControler(angularJs) {
        this.angularJs = angularJs;
    }
    IndexRestneerLoginControler.prototype.load = function () {
        this.angularJs.module('IndexRestneerModule')
            .controller('LoginController', function ($scope, $rootScope, $HttpService) {
            $scope.email = "leandro.curioso@gmail.com";
        });
    };
    return IndexRestneerLoginControler;
}());
exports.default = IndexRestneerLoginControler;
//# sourceMappingURL=index-restneer.login.controller.js.map