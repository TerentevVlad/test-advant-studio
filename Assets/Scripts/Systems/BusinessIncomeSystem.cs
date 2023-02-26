using Components;
using Leopotam.Ecs;

namespace DefaultNamespace
{
    public class BusinessIncomeSystem : IEcsRunSystem
    {
        private EcsFilter<MultiplierIncomeComponent, LevelModifiersIncomeComponent, BusinessComponent> _filterModifierIncome;
        private EcsFilter<BaseIncomeComponent, LevelComponent, BusinessComponent> _filterBaseIncome;
        private EcsFilter<BusinessIncome, BaseIncomeComponent, MultiplierIncomeComponent> _filterIncome;


        public void Run()
        {
            foreach (var index in _filterModifierIncome)
            {
                var businessComponent = _filterModifierIncome.Get3(index);
                var levelComponent = _filterModifierIncome.Get2(index);
                var multiplier = businessComponent.BusinessConfig.GetMultiplier1Income(levelComponent.LevelModificator1);
                multiplier *= businessComponent.BusinessConfig.GetMultiplier2Income(levelComponent.LevelModificator2);

                ref var multiplierIncomeComponent = ref _filterModifierIncome.Get1(index);
                multiplierIncomeComponent.Multiplier = multiplier;
            }
            
            
            foreach (var index in _filterBaseIncome)
            {
                var businessComponent = _filterBaseIncome.Get3(index);
                var level = _filterBaseIncome.Get2(index).Level;
                var value = businessComponent.BusinessConfig.GetIncome(level);
                
                ref var baseIncomeComponent = ref _filterBaseIncome.Get1(index);
                baseIncomeComponent.Income = value;
            }

            foreach (var index in _filterIncome)
            {
                ref var businessIncomeComponent = ref _filterIncome.Get1(index);
                var businessBaseIncomeComponent = _filterIncome.Get2(index);
                var businessMultiplierIncome= _filterIncome.Get3(index);
                businessIncomeComponent.Income =
                    businessBaseIncomeComponent.Income * businessMultiplierIncome.Multiplier;

            }
        }
    }
}