namespace Restneer.Core.Infrastructure.ResultFlow
{
    public sealed class SuccessResultFlow<T> : ResultFlow<T>
    {
        public SuccessResultFlow(T result, string message)
            :base(result, message)
        {
        }
    }
}
