using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DataDAO
{
    public class CensusData
    {
        public string state;
        public string population;
        public long area;
        public long density;

        public CensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = population;
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}
