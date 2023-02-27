using UnityEngine;

namespace Configs.Balance
{
    public abstract class BalanceFunction : ScriptableObject
    {
        public abstract bool HasStartValue { get; protected set; }
        public abstract bool HasXArgument { get; protected set; }
        public abstract bool HasYArgument { get; protected set; }
        public abstract bool HasZArgument { get; protected set; }
        public abstract double GetValue(double startValue, int level = 0, float xArg = 0, float yArg = 0, float zArg = 0);
    }
}