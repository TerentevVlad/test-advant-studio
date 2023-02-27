using ResourceSystem;
using UnityEngine;

namespace Layouts
{
    public class MainWindowLayout : MonoBehaviour
    {
        [SerializeField] private ResourceLayout _softResourceLayout;
        
        public void SetPlayerResourceContainer(PlayerResourceContainer playerResourceContainer)
        {
            foreach (var resource in playerResourceContainer.Resources)
            {
                var layout = GetResourceLayout(resource);
                if(layout != null)
                    layout.SetValue(resource.ResourceConfig, resource.Value);
            }
        }
        

        private ResourceLayout GetResourceLayout(Resource resource)
        {
            switch (resource.ResourceConfig.Key)
            {
                case "resource/soft": return _softResourceLayout;
                default: return null;
            }   
        }

        public void UpdateResource(Resource resource)
        {
            GetResourceLayout(resource).SetValue(resource.Value);
        }
    }
}