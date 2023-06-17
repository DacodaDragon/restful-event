using Microsoft.AspNetCore.Mvc;

namespace RestfulEvents.Api
{
    public enum ErrorCode
    {
        Generic,
        EntryNotFound
    }

    public class Error
    {
        public ErrorCode ErrorCode { get; set; }
        public string ErrorMessage { get; set; }

        public Error(ErrorCode errorCode, string errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public static BadRequestObjectResult EntityNotFound(string entityName, string valueName, string value)
        {
            return new BadRequestObjectResult(new Error(ErrorCode.EntryNotFound, $"Entity with {valueName} {value} has not been found."));
        }
    }
}
