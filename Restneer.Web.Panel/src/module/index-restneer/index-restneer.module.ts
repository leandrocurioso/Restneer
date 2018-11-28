import WebApp from "../webapp";
import { IModule } from "../i-module";
import HttpService from "../../service/http.service";
import { IService } from "../../service/i-service";
import { IController } from "../../module/i-controller";
import IndexRestneerLoginController from "../../module/index-restneer/controller/index-restneer.login.controller";
import ApiUserService from "../../service/api-user.service";
import RestneerService from "../../service/restneer.service";
import ConfigService from "../../service/config.service"

class IndexRestneerModule extends WebApp implements IModule {

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
        services: IService[] = 
            [
                new ConfigService(this.appModule),
                new HttpService(this.appModule),
                new RestneerService(this.appModule),
                new ApiUserService(this.appModule)
            ]
    ): void {
        services.forEach(service => {
            service.load();
        });
    }

    private loadControllers(
        controllers: IController[] = 
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