using DefaultNamespace;
using Leopotam.Ecs;

namespace Systems
{
    public class BusinessLevelPresenterSystem : IEcsRunSystem
    {
        private EcsFilter<LevelComponent, BusinessPresenterComponent> _filter;
        public void Run()
        {
            foreach (var index in _filter)
            {
                var level = _filter.Get1(index).Level;
                _filter.Get2(index).Presenter.SetLevel(level);
            }
        }
    }
}