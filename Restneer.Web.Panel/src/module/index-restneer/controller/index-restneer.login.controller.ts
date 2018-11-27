import { IAppController } from "../../i-app-controller";
import ApiUserService from "../../../service/api-user.service";

class IndexRestneerLoginControler implements IAppController {

    private readonly appModule;
    private $ApiUserService;

    constructor(appModule) {
        this.appModule = appModule;
    }

    public load(): void {
        this.appModule.controller('LoginController',
        async (
            $scope, $rootScope, $ApiUserService: ApiUserService
        ) => {
              this.$ApiUserService = $ApiUserService;
            const result = await this.$ApiUserService.authenticate("leandro.curioso@gmail.com", "5221684");
            console.log(result);
        });
    }
     
}

export default IndexRestneerLoginControler;