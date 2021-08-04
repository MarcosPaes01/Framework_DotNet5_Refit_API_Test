using System;
using System.Collections.Generic;

namespace Super.GlobalPlatform.Regression.Api.ApiClients
{
    public class ResponseApiClient
    {
        public class Response_Failure
        {
            public string Code { get; set; }
            public Guid Id { get; set; }
            public string Message { get; set; }
            public List<Error> Errors { get; set; }
        }

        public class Error
        {
            public string ErrorCode { get; set; }
            public string Message { get; set; }
            //public string Path { get; set; }
        }

        public class BadRequest
        {
            public string Code { get; set; }
            public Guid Id { get; set; }
            public string Message { get; set; }
            public string Errors { get; set; }
        }

        public class Errors
        {
            public string ErrorCode { get; set; }
            public string Message { get; set; }
        }
    }
}