import WebApp from "../webapp";
import { IAppModule } from "../i-app-module";
import HttpService from "../../service/http.service";
import { IAppService } from "../../service/i-app-service";
import { IAppController } from "../../module/i-app-controller";
import IndexRestneerLoginController from "../../module/index-restneer/controller/index-restneer.login.controller";
import ApiUserService from "../../service/api-user.service";

class IndexRestneerModule extends WebApp implements IAppModule {

    private static readonly dependencies: string[] = [
      'ngRoute', 'ngCookies'
    ];

    constructor(angularJs) {
        super("IndexRestneerModule", IndexRestneerModule.dependencies, angularJs);
    }

    public load(): void {
        super.setModule(this.config, this.run);
        this.loadServices();
        this.loadControllers();
    }

    private loadServices(
        services: IAppService[] = 
            [
                new HttpService(this.appModule),
                new ApiUserService(this.appModule)
            ]
    ): void {
        services.forEach(service => {
            service.load();
        });
    }

    private loadControllers(
        controllers: IAppController[] = 
            [
                new IndexRestneerLoginController(this.appModule)
            ]
    ): void {
        controllers.forEach(controller => {
            controller.load();
        });
    }

    private config(
        $routeProvider, 
        $cookiesProvider
    ): void {
        $routeProvider.when('/', {
            templateUrl: 'module/index-restneer/index-restneer-login.view.html',
            controller: 'LoginController',
            controllerAs: 'vm',
            reloadOnSearch: false
        });
    }

    private run(
        $rootScope, 
        $window
    ): void {

    }
  
}

export default IndexRestneerModule;