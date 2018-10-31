namespace Restneer.Core.Infrastructure.ResultFlow
{
    public sealed class ExceptionResultFlow<T> : ResultFlow<T>
    {
        public ExceptionResultFlow(T result, string message)
            :base(result, message)
        {
        }
    }
}
