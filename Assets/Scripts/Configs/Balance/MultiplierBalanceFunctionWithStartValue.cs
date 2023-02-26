using DefaultNamespace.Configs;
using UnityEngine;

namespace Configs.Balance
{
    [CreateAssetMenu(fileName = "MultiplierFunctionWithStartValue",
        menuName = "Configs/Balance/MultiplierFunctionWithStartValue", order = 0)]
    public class MultiplierBalanceFunctionWithStartValue : BalanceFunction
    {
        public override bool HasStartValue { get; protected set; } = true;
        public override bool HasXArgument { get; protected set; } = true;
        public override bool HasYArgument { get; protected set; } = true;
        public override bool HasZArgument { get; protected set; } = false;

        public override double GetValue(double startValue, int level = 0, float xArgument = 0,float yArgument = 0,float zArgument = 0)
        {
            if (level == 0)
                return yArgument;
            else
            {
                level -= 1;
                double multiplier = Mathf.Pow(xArgument, level);
                double sum = startValue * multiplier;
                return sum;
            }
        }
    }
}