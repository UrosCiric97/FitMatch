﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs
{
	public class AppException
	{
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string StackTrace { get; set; }
		public AppException(int statusCode, string message, string? stackTrace = null)
		{
			StatusCode = statusCode;
			Message = message;
			StackTrace = stackTrace;
		}
	}
}
