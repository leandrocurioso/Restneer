import { IAppController } from "../../i-app-controller";

class IndexRestneerLoginControler implements IAppController {

    private readonly angularJs;

    constructor(angularJs) {
        this.angularJs = angularJs;
    }

    public load(): void {
        this.angularJs.module('IndexRestneerModule')
        .controller('LoginController',
        (
            $scope, $rootScope, $HttpService
        ) => {
            $scope.email = "leandro.curioso@gmail.com";
        });
    }
     
}

export default IndexRestneerLoginControler;