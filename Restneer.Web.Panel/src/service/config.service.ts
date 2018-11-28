import { IService } from "./i-service";

class ConfigService implements IService {
    
    private readonly appModule: angular.IModule;
    public restneerService: {
        host: string,
        apiKey: string
    };
    
    constructor(appModule) {
        this.appModule = appModule;
        this.restneerService = {
            host: "http://localhost:5001",
            apiKey: "e6b3c557-72c7-4fc0-a239-d4d8877d5a32"
        };
    }
   
    public load(): void {
        this.appModule.factory('$ConfigService', () => this);
    }

}

export default ConfigService;