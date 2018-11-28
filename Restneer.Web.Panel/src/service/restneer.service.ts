import HttpService from "./http.service";
import ConfigService from "./config.service";

import { IHttpServiceRequest } from "./i-http-service-request";
import { IServiceResponse } from "./i-service-response";

class RestneerService {
    
    private readonly appModule;
    private readonly baseUrl: string;
    private $HttpService: HttpService;
    private $ConfigService: ConfigService;
    
    constructor(appModule) {
        this.appModule = appModule;
    }

    public async call(httpServiceRequest: IHttpServiceRequest): Promise<IServiceResponse<any>> {
        return await this.$HttpService.call({
            url: this.baseUrl + httpServiceRequest.url,
            method: httpServiceRequest.method,
            headers: Object.assign({},  
            {
                "Api-Key": this.$ConfigService.restneerService
            }, 
            httpServiceRequest.headers),
            data: httpServiceRequest.data,
            }).catch(err => {
               throw err;
            });
    }

    public load(): void {
        this.appModule.factory('$RestneerService',(
            $HttpService: HttpService,
            $ConfigService: ConfigService
        ) => {
            this.$HttpService = $HttpService;
            this.$ConfigService = $ConfigService;
            return this;
        });
    }

}

export default RestneerService;