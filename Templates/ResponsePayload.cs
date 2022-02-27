﻿namespace FavoriteFoodApi.Templates
{
    public class ResponsePayload<T>
    {
        public T Data { get; set; }
        public string ErrorCode { get; set; }
    }

    public static class ResponseHandler
    {
        public static ResponsePayload<T> WrapSuccess<T>(T data)
        {
            return new ResponsePayload<T>
            {
                Data = data,
                ErrorCode = null
            };
        }

        public static ResponsePayload<T> WrapFailure<T>(string errorCode)
        {
            return new ResponsePayload<T>
            {
                ErrorCode = errorCode
            };
        }
    }
}