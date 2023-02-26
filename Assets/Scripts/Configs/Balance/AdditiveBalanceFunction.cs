using UnityEngine;

namespace DefaultNamespace.Configs
{
    [CreateAssetMenu(fileName = "AdditiveBalanceFunction",
        menuName = "Configs/Balance/AdditiveFunction", order = 0)]
    public class AdditiveBalanceFunction : BalanceFunction
    {
        public override bool HasStartValue { get; protected set; } = true;
        public override bool HasXArgument { get; protected set; } = true;
        public override bool HasYArgument { get; protected set; } = false;
        public override bool HasZArgument { get; protected set; } = false;

        public override double GetValue(double startValue, int level = 0, float xArgument = 0,float yArgument = 0,float zArgument = 0)
        {
            double sum = startValue;
            for (int i = 0; i < level; i++)
            {
                sum += xArgument;
            }
            
            return sum;
        }
    }
}