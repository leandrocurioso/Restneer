import { IAppService } from "./i-app-service";

class $HttpService implements IAppService {

    private readonly angularJs;

    constructor(angularJs) {
        this.angularJs = angularJs;
    }

    public load(): void {
        this.angularJs.module('IndexRestneerModule').factory('$HttpService',
        (
            $rootScope, $http, $cookies
        ) => {
            const service = {};
            return service;
        });
    }
   
}

export default $HttpService;