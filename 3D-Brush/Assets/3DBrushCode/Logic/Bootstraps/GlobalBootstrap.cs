using _3DBrushCode.Logic.Contexts;
using _3DBrushCode.Logic.Contracts;
using _3DBrushCode.Views;
using UnityEngine;

namespace _3DBrushCode.Logic.Bootstraps {
    public class GlobalBootstrap : MonoBehaviour {
        public UnityReferenceView unityReferenceView;
        
        private bool _isInitialized;
        private RootContext _rootContext;

        private void Awake() {
            Initialize();
            LateInitialize();
            _isInitialized = true;
        }

        private void Initialize() {
            _rootContext = new RootContext();
        }

        private void LateInitialize() {
            //TODO: if we run this in the editor, we need to install the context
            //TODO: if we run this from other env (like tests) we don't need to install this version of context
            //and we need to install the other one (mock, for example)
            #if UNITY_EDITOR
            _rootContext.UnityContext.InstallForUnity(unityReferenceView);
            #endif
            
            _rootContext.GlobalContext.InstallTextureStorageService(unityReferenceView);
            _rootContext.GlobalContext.InstallGameFactory(_rootContext.UnityContext);
            _rootContext.GlobalContext.GameFactory.CreateMiniGame();
        }

        private void Update() {
            if (_isInitialized) {
                foreach (ITickable tickable in _rootContext.UnityContext.Tickables) {
                    tickable.OnTick(Time.deltaTime);
                }
            }
        }
    }
}
