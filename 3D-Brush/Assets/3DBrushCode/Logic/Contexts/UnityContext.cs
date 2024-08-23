using System.Collections.Generic;
using _3DBrushCode.Logic.Contracts;
using _3DBrushCode.Logic.Controllers.UnityObjectController;
using _3DBrushCode.Logic.Services.ObjectRotateService;
using _3DBrushCode.Logic.Services.ObjectsFactory;
using _3DBrushCode.Logic.Services.ObjectsPainter;
using _3DBrushCode.Views;

namespace _3DBrushCode.Logic.Contexts {
    public class UnityContext {
        public List<ITickable> Tickables { get; } = new List<ITickable>();

        public UnityObjectController ObjectController;
        public PaintObjectFactory PaintObjectFactory;
        public IObjectPainter ObjectPainter;
        public IUnityRotateService UnityRotateService;

        public void InstallForUnity(UnityReferenceView unityReferenceView) {
            ObjectController = new UnityObjectController(unityReferenceView.mainCanvasView.buttonsView);
            PaintObjectFactory = new PaintObjectFactory();

            ObjectPainter = new UnityObjectPainter(unityReferenceView.mainCanvasView.buttonsView.buttonsByColorMap, 
                unityReferenceView.mainCanvasView.brushSizeSlider);
            UnityRotateService = new ObjectRotateService();

            Tickables.Add(ObjectController);
        }
    }
}
