using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class CensusAnalyserException : Exception
    {
        public ExceptionType exception;
        public enum ExceptionType
        {
            FILE_NOT_FOUND, INVALID_FILE_EXTENSION, INVALID_HEADERS, INVALID_DELIMITER, NO_SUCH_COUNTRY
        }
        public CensusAnalyserException(string message, ExceptionType exception) : base(message)
        {
            this.exception = exception;
        }
    }
}
