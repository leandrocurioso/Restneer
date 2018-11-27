import HttpService from "./http.service";

class ApiUserService {
    
    private readonly appModule;
    private readonly baseUrl: string;
    private $HttpService: HttpService;

    constructor(appModule) {
        this.appModule = appModule;
        this.baseUrl = "/v1/api-user";
    }

    public async authenticate(email: string, password: string): Promise<boolean> {
        return await this.$HttpService.call({
                url: this.baseUrl + "/authenticate",
                method: "POST",
                headers: {
                    "Api-Key": "e6b3c557-72c7-4fc0-a239-d4d8877d5a32"
                },
                data: { email, password }
            }).then(response => {
                console.log(response);
                return true;
             }).catch(err => {
                console.log(err);
                throw err;
             });
    }

    public load(): void {
        this.appModule.factory('$ApiUserService',
            (
                $HttpService: HttpService
            ) => {
            this.$HttpService = $HttpService;
            return {
                authenticate: async (email: string, password: string): Promise<boolean> => {
                    return await this.authenticate(email, password);
                }
            };
        });
    }

}

export default ApiUserService;