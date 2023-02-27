using System;
using System.Collections.Generic;

namespace Saves
{
    [Serializable]
    public class BusinessData : Data
    {
        public int Level;
        public List<int> LevelModifiers;

        public BusinessData()
        {
            Level = 0;
            LevelModifiers = new List<int>();
        }
    }
}