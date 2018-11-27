import { IAppService } from "./i-app-service";
import { IHttpServiceRequest } from "./i-http-service-request";

class HttpService implements IAppService {

    protected readonly appModule;
    private $rootScope;
    private $http;
    private $cookies;

    constructor(appModule) {
        this.appModule = appModule;
    }

    public async call(httpServiceRequest: IHttpServiceRequest): Promise<any> {
        httpServiceRequest.url = "http://localhost:5001" + httpServiceRequest.url;
        console.log(httpServiceRequest);
        return await this.$http(httpServiceRequest).catch(err => {
            throw err;
        });
    }
   
    public load(): void {
        this.appModule.factory('$HttpService',
            (
                $rootScope, $http, $cookies
            ) => {
            this.$rootScope = $rootScope;
            this.$http = $http;
            this.$cookies = $cookies;
            return {
                call: async (httpServiceRequest: IHttpServiceRequest): Promise<any> => {
                    return await this.call(httpServiceRequest);
                }
            };
        });
    }
   
}

export default HttpService;