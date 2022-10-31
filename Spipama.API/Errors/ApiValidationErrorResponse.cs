﻿using System;
using System.Collections.Generic;

namespace Spipama.API.Errors
{
    public class ApiValidationErrorResponse : ApiResponse
    {
        public ApiValidationErrorResponse() : base(400)
        {

        }
        public IEnumerable<String> Errors { get; set; }
    }
}