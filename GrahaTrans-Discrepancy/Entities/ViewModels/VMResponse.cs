﻿
using System.Net;
namespace Entities.Domain
{
    public class VMResponse
    {
        public HttpStatusCode statusCode { get; set; }
        public string? message { get; set; }
        public object? data { get; set; }

        public VMResponse()
        {
            statusCode = HttpStatusCode.InternalServerError;
            message = string.Empty;
            data = null;
        }
    }
}
