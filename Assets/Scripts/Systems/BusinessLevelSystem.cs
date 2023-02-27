using Components.StateComponents;
using Leopotam.Ecs;

namespace Systems
{
    public class BusinessLevelSystem : IEcsRunSystem
    {
        private EcsFilter<LevelComponent, ProductionComponent> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                ref var levelComponent = ref _filter.Get1(index);
                ref var productionComponent = ref _filter.Get2(index);

                productionComponent.IsActive = levelComponent.Level > 0;
            }
        }
    }
}