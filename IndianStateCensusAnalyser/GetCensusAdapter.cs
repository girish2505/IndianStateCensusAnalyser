using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStateCensusAnalyser
{
    public class GetCensusAdapter
    {
        public static string[] GetCensusData(string csvFilePath, string headers)
        {
            try
            {
                string[] censusData;
                if (!File.Exists(csvFilePath))
                {
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
                }
                if (Path.GetExtension(csvFilePath) != ".csv")
                {
                    throw new CensusAnalyserException("Invalid File Extension", CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION);
                }
                censusData = File.ReadAllLines(csvFilePath);
                if (censusData[0] != headers)
                {
                    throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
                }
                return censusData;
            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}
