using System;
using System.Net;

namespace Restneer.Core.Application.CustomException
{
	public class RestneerException : Exception
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public RestneerException(string message, HttpStatusCode httpStatusCode)
            : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
    }
}
