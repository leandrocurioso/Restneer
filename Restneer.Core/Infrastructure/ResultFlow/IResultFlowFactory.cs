namespace Restneer.Core.Infrastructure.ResultFlow
{
    public interface IResultFlowFactory
    {
        ResultFlow<T> Success<T>(object result, string message = null);
        ResultFlow<T> Exception<T>(string message, object result = null);
    }
}