﻿using System;

namespace AdOut.Identity.Model.Exceptions
{
    public class BadRequestException : Exception, IHttpException
    {
        public BadRequestException(string message) : base(message)
        {
        }

        public int HttpStatusCode => Constants.HttpStatusCodes.Status400BadRequest;
    }
}