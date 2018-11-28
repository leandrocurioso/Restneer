class ConfigService {
    
    private readonly appModule;
    public restneerService: {
        host: string,
        apiKey: string
    };
    
    constructor(appModule) {
        this.appModule = appModule;
    }
   
    public load(): void {
        this.appModule.factory('$ConfigService', () => this);
    }

}

export default ConfigService;