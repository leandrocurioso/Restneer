import { IAppService } from "./i-app-service";
import { IHttpServiceRequest } from "./i-http-service-request";
import { IServiceResponse } from "./i-service-response";

class HttpService implements IAppService {

    protected readonly appModule;
    private $rootScope;
    private $http;
    private $cookies;

    constructor(appModule) {
        this.appModule = appModule;
    }

    public async call(httpServiceRequest: IHttpServiceRequest): Promise<IServiceResponse<any>> {
        httpServiceRequest.url = "http://localhost:5001" + httpServiceRequest.url;
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