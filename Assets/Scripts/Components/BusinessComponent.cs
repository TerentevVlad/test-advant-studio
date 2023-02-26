using DefaultNamespace.Configs;

namespace DefaultNamespace
{
    public struct BusinessComponent
    {
        public string Name;
        public ProductionComponent ProductionTime;
        public BusinessConfig BusinessConfig;
    }

    public struct LevelComponent
    {
        public int Level;
    }

    public struct LevelModifiersIncomeComponent
    {
        public int LevelModificator1;
        public int LevelModificator2;
    }
}