namespace Restneer.Core.Infrastructure.ResultFlow
{
    public abstract class ResultFlow<T> : IResultFlow<T>
    {
        public T Result { get; set; }
        public string Message { get; set; }

        public ResultFlow(T result, string message)
        {
            Result = result;
            Message = message;
        }

        public bool IsSuccess()
        {
            try
            {
                if (this is SuccessResultFlow<T>)
                    return true;
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool IsException()
        {
            try
            {
                if (this is ExceptionResultFlow<T>)
                    return true;
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}