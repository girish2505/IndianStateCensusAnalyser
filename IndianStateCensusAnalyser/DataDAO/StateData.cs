﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStateCensusAnalyser.DataDAO
{
    public class StateData
    {
        public int serialNum;
        public string stateName;
        public int stateCode;

        //Parameterized constructor
        public StateData(string serialNum, string stateName, string stateCode)
        {
            this.serialNum = Convert.ToInt32(serialNum);
            this.stateName = stateName;
            this.stateCode = Convert.ToInt32(stateCode);
        }
    }
}
