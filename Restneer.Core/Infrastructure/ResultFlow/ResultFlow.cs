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

        public bool IsSuccessWithResult()
        {
            try
            {
                if (this is SuccessResultFlow<T>)
                {
                    if (Result == null)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool IsSuccessWithoutResult()
        {
            try
            {
                if (this is SuccessResultFlow<T>)
                {
                    if (Result == null)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool IsExceptionWithResult()
        {
            try
            {
                if (this is ExceptionResultFlow<T>)
                {
                    if (Result == null)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }

        public bool IsExceptionWithoutResult()
        {
            try
            {
                if (this is ExceptionResultFlow<T>)
                {
                    if (Result == null)
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            catch
            {
                throw;
            }
        }
    }
}