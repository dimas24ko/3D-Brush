using _3DBrushCode.Logic.Controllers.GameFactory;
using _3DBrushCode.Logic.Services.TextureStorageService;
using _3DBrushCode.Views;

namespace _3DBrushCode.Logic.Contexts {
    public class GlobalContext {
        public GameFactory GameFactory;
        public TextureStorageService TextureStorageService;

        public void InstallGameFactory(UnityContext unityContext) {
            GameFactory = new GameFactory(unityContext.PaintObjectFactory, unityContext.ObjectController, 
                unityContext.ObjectPainter, unityContext.UnityRotateService, TextureStorageService);
        }
        
        public void InstallTextureStorageService(UnityReferenceView unityReferenceView) {
            TextureStorageService = new TextureStorageService(unityReferenceView);
        }
    }
}
