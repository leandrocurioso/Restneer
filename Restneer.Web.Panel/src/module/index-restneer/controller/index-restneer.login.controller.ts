import { IController } from "../../i-controller";
import ApiUserService from "../../../service/api-user.service";

class IndexRestneerLoginControler implements IController {

    private readonly appModule: angular.IModule;
    private $ApiUserService: ApiUserService;
    public $scope;

    constructor(appModule) {
        this.appModule = appModule;
    }
   
    public async authenticate(): Promise<any> {
        return await this.$ApiUserService.authenticate(this.$scope.email, this.$scope.password)
        .catch(err => {
            console.log(this.$scope.showInvalidCredential);
            this.$scope.showInvalidCredential = true;
            console.log(err);
        });
    }

    public load(): void {
        this.appModule.controller('LoginController',
        async (
            $scope, $window, $rootScope, $ApiUserService: ApiUserService
        ) => {
            this.$scope = $scope;
            this.$scope.showInvalidCredential = false;
            this.$ApiUserService = $ApiUserService;
            console.log(this.authenticate);
            this.$scope["authenticate"] = this.authenticate;
            return this;
        });
    }
     
}

export default IndexRestneerLoginControler;