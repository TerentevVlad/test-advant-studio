
using System.Collections.Generic;
using DefaultNamespace.Configs;

namespace DefaultNamespace
{
    public struct BusinessComponent
    {
        public string Name;
        public BusinessConfig BusinessConfig;
    }

    public struct LevelComponent
    {
        public int Level;
    }

    public struct LevelModifiersIncomeComponent
    {
        public List<int> Levels;
    }
}