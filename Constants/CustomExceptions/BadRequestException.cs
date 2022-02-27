using System;

namespace FavoriteFoodApi.Constants.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base(ErrorCodes.BAD_REQUEST)
        {
        }
    }
}