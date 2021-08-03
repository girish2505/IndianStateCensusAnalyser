using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndianStateCensusAnalyser;
using System.Collections.Generic;
using IndianStateCensusAnalyser.DataDAO;

namespace IndianCensusValidation
{
    [TestClass]
    public class UnitTest1
    {
        string stateCensusDataPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCensusData.csv";
        string wrongstateCensusDataPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCensusD.csv";
        string wrongstateCensusDataCSVPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCensusData.csv.txt";
        string wrongDelimiterstateCensusDataCSVPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongDelimiterIndiaStateCensusData.csv";
        string wrongHeaderstateCensusDataCSVPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongHeaderIndiaStateCensusData.csv";
        string stateCodeDataPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaStateCode.csv";
        string wrongStateCodeDataPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\IndiaState.csv";
        string wrongStateCodeDataCSVPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongStateCodeDataCSVPath.txt";
        string wrongDelimiterStateCodeDataPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongDelimiterStateCodeDataPath.csv";
        string wrongHeaderStateCodeDataPath = @"C:\Users\girish.v\source\repos\IndianStateCensusAnalyser\IndianStateCensusAnalyser\WrongHeaderStateCodeDataPath.csv";
        CsvAdapterFactory csv = null;
        List<FullCensusData> totalRecords;
        List<FullCensusData> stateRecords;
        [TestInitialize]
        //Initialize the record value
        public void Setup()
        {
            csv = new CsvAdapterFactory();
            totalRecords = new List<FullCensusData>();
            stateRecords = new List<FullCensusData>();
        }
        /// UC1-TC1.1
        [TestMethod]
        public void Given_State_Census_Return_CountOf_Records()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusDataPath, "State,Population,AreaInSqKm,Density");
            Assert.AreEqual(9, stateRecords.Count);
        }
        [TestMethod]
        public void Incorrect_File_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongstateCensusDataPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customEx.exception);
        }
        
        [TestMethod]
        public void Incorrect_File_Extension_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION, customEx.exception);
        }
       
        [TestMethod]
        public void Incorrect_Delimiter_In_CSVFile_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, customEx.exception);
        }
       
        [TestMethod]

        public void Incorrect_Headers_In_CSVFile_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, customEx.exception);
        }

        [TestMethod]
        public void State_Code_Return_CountOf_Records()
        {
            var totalRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeDataPath, "SerailNo,StateName,StateCode");
            Assert.AreEqual(35, totalRecords.Count);
        }
       
        [TestMethod]
        public void Incorrect_File_Return_CustomException_State_Code()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDataPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customEx.exception);
        }
       
        [TestMethod]
        public void Incorrect_File_Extension_Return_CustomException_For_StateCode()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDataCSVPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION, customEx.exception);
        }
       
        [TestMethod]
        public void Incorrect_Delimiter_In_CSVFile_Return_CustomException_For_StateCode()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterStateCodeDataPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, customEx.exception);
        }
        
        [TestMethod]

        public void Incorrect_Headers_In_CSVFile_Return_CustomException_For_StateCode()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeDataPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, customEx.exception);
        }
    }
}
