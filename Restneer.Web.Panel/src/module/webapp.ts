abstract class WebApp {

    protected readonly angularJs;
    protected readonly appName: string;
    protected readonly dependencies: string[];
    public appModule: angular.IModule;

    constructor(appName: string, dependencies: string[], angularJs) {
        this.appName = appName;
        this.dependencies = dependencies;
        this.angularJs = angularJs;
    }

    protected setModule(config, run): void {
        this.appModule = this.angularJs.module(this.appName, this.dependencies)
                                       .config(config)
                                       .run(run);
    }
    
}

export default WebApp;