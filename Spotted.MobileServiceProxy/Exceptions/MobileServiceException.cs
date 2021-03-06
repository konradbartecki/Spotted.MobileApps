﻿using System;
using System.Net;
using System.Net.Http;

namespace Spotted.MobileServiceProxy.Exceptions
{
    public class MobileServiceException : Exception
    {
        public MobileServiceException(HttpResponseMessage response) : base(response.Content.ReadAsStringAsync().Result)
        {
            this.StatusCode = response.StatusCode;
        }

        public MobileServiceException(string message) : base(message)
        {
            this.StatusCode = HttpStatusCode.InternalServerError;
        }

        public HttpStatusCode StatusCode { get; set; }
    }
}
