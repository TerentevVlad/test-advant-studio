using ResourceSystem;

namespace Layouts.Presenters
{
    public class MainWindowPresenter
    {
        private readonly PlayerResourceContainer _playerResourceContainer;
        private readonly MainWindowLayout _layout;

        public MainWindowPresenter(PlayerResourceContainer playerResourceContainer, MainWindowLayout layout)
        {
            _playerResourceContainer = playerResourceContainer;
            
            _playerResourceContainer.OnValueChanged += OnValueChanged;
            _layout = layout;
            
            _layout.SetPlayerResourceContainer(_playerResourceContainer);
        }

        private void OnValueChanged(Resource resource)
        {
            _layout.UpdateResource(resource);
        }
    }
}