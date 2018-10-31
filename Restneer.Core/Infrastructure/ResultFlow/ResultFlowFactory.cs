using System;

namespace Restneer.Core.Infrastructure.ResultFlow
{
    public class ResultFlowFactory : IResultFlowFactory
    {
        public ResultFlow<T> Success<T>(object result, string message = null)
        {
            try
            {
                return new SuccessResultFlow<T>((T) result, message);
            }
            catch
            {
                throw;
            }
        }

        public ResultFlow<T> Exception<T>(string message, object result = null)
        {
            try
            {
                if (message == null)
                {
                    throw new Exception("You must specify a message when executed param is false!");
                }
                return new ExceptionResultFlow<T>((T) result, message);
            }
            catch
            {
                throw;
            }
        }
    }
}
