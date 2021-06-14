using System;

namespace TaskManagerPlatform.Application.Exceptions
{
    public class BadRequestException: ApplicationException
    {
        public BadRequestException(string message): base(message)
        {
        }
    }
}