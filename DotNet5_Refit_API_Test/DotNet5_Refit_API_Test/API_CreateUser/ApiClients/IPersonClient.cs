using Refit;

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Super.EWalletCore.PersonDataManagement.Application.IntegratedTests.ApiClient
{
    public interface IPersonClient
    {
        [Post("/run-create-person")]
        public Task<HttpResponseMessage> RunCreatePerson([Body] CreatePersonRequest request, [Header("x-country")] int country);
    }

    public class CreatePersonResponse_Success
    {
        public string PersonId { get; set; }
    }

    public class CreatePersonResponse_Failure
    {
        public string Code { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public List<Error> Errors { get; set; }
    }

    public class Error
    {
        public string ErrorCode { get; set; }
        public string Message { get; set; }
        public string Path { get; set; }
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

