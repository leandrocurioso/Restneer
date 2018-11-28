export interface IServiceResponse<T> {
    statusCode: number;
    data: T;
}