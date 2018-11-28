import { IAppController } from "../../i-app-controller";
import ApiUserService from "../../../service/api-user.service";

class IndexRestneerLoginControler implements IAppController {

    private readonly appModule;
    private $ApiUserService: ApiUserService;
    private $scope;

    constructor(appModule) {
        this.appModule = appModule;
    }
   
    public load(): void {
        this.appModule.controller('LoginController',
        (
            $scope, $window, $rootScope, $ApiUserService: ApiUserService
        ) => {
            this.$scope = $scope;
            this.$ApiUserService = $ApiUserService;
            this.$scope["authenticate"] = async () => {
                const result = await this.$ApiUserService.authenticate(this.$scope.email, this.$scope.password)
                    .catch(err => {
                        alert(err.message);
                        throw err;
                    });
                $window.localStorage.setItem("token", result.payload.token);
            };
        });
    }
     
}

export default IndexRestneerLoginControler;