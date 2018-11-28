import { IService } from "./i-service";
import { IHttpServiceRequest } from "./i-http-service-request";
import { IServiceResponse } from "./i-service-response";

class HttpService implements IService {

    private readonly appModule: angular.IModule;
    private $rootScope;
    private $http;
    private $cookies;

    constructor(appModule) {
        this.appModule = appModule;
    }

    public async call(httpServiceRequest: IHttpServiceRequest): Promise<IServiceResponse<any>> {
        return await this.$http(httpServiceRequest)
            .then(response => ({ statusCode: response.status, data: response.data }))
            .catch(err => {
                throw err;
        });
    }
   
    public load(): void {
        this.appModule.factory('$HttpService', (
            $rootScope, $http, $cookies
        ) => {
            this.$rootScope = $rootScope;
            this.$http = $http;
            this.$cookies = $cookies;
            return this;
        });
    }
   
}

export default HttpService;