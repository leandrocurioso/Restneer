import RestneerService from "./restneer.service";
import { IService } from "./i-service";

class ApiUserService implements IService {
    
    private readonly appModule: angular.IModule;
    private readonly baseUrl: string;
    private $RestneerService: RestneerService;

    constructor(appModule) {
        this.appModule = appModule;
        this.baseUrl = "/v1/api-user";
    }

    public async authenticate(email: string, password: string): Promise<{ payload: { token: string } }> {
        return await this.$RestneerService.call({
            url: this.baseUrl + "/authenticate",
            method: "POST",
            data: { email, password }
            }).then(response => response.data)
            .catch(err => {
                console.log(err);
               throw new Error("Invalid credentials!");
            });
    }

    public load(): void {
        this.appModule.factory('$ApiUserService',(
            $RestneerService: RestneerService
        ) => {
            this.$RestneerService = $RestneerService;
            return this;
        });
    }

}

export default ApiUserService;