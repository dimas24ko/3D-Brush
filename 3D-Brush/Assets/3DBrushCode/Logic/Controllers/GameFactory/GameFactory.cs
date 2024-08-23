using _3DBrushCode.Logic.Contracts;
using _3DBrushCode.Logic.Services.ObjectsFactory;
using UnityEngine;

namespace _3DBrushCode.Logic.Controllers.GameFactory {
    public class GameFactory {
        private readonly PaintObjectFactory _paintObjectFactory;
        private readonly UnityObjectController.UnityObjectController _objectController;
        private readonly IObjectPainter _objectPainter;
        private readonly IUnityRotateService _unityRotateService;

        public GameFactory(PaintObjectFactory paintObjectFactory, UnityObjectController.UnityObjectController objectController, IObjectPainter objectPainter, IUnityRotateService unityRotateService) {
            _paintObjectFactory = paintObjectFactory;
            _objectController = objectController;
            _objectPainter = objectPainter;
            _unityRotateService = unityRotateService;
        }
        
        public void CreateMiniGame() {
            GameObject paintObject = _paintObjectFactory.CreateObject(PrimitiveType.Sphere);
            _objectController.Initialize(paintObject, Camera.main, _objectPainter, _unityRotateService, ControlState.Rotating);
            _objectPainter.SetObject(paintObject);
            _unityRotateService.SetObject(paintObject);
        }
    }
}
