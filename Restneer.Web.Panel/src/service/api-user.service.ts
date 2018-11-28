import RestneerService from "./restneer.service";

class ApiUserService {
    
    private readonly appModule;
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