using _3DBrushCode.Logic.Controllers.GameFactory;

namespace _3DBrushCode.Logic.Contexts {
    public class GlobalContext {
        public GameFactory GameFactory;

        public void InstallGameFactory(UnityContext unityContext) {
            GameFactory = new GameFactory(unityContext.PaintObjectFactory, unityContext.ObjectController, 
                unityContext.ObjectPainter, unityContext.UnityRotateService);
        }
    }
}
