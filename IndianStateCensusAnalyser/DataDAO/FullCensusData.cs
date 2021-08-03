using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DataDAO
{
    public class FullCensusData
    {
        public string state;
        public string population;
        public long area;
        public long density;
        public int serialNum;
        public string stateName;
        public int stateCode;
        public FullCensusData(StateData stateData)
        {
            this.serialNum = stateData.serialNum;
            this.stateName = stateData.stateName;
            this.stateCode = stateData.stateCode;
        }
        public FullCensusData(CensusData censusData)
        {
            this.state = censusData.state;
            this.population = censusData.population;
            this.area = censusData.area;
            this.density = censusData.density;
        }
    }
}
