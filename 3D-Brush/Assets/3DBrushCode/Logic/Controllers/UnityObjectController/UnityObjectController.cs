using _3DBrushCode.Logic.Contracts;
using _3DBrushCode.Views;
using UnityEngine;

namespace _3DBrushCode.Logic.Controllers.UnityObjectController {
    public class UnityObjectController : ITickable {
        private readonly ButtonsView _buttonsView;
        
        private ControlState _state;
        private GameObject _shape;
        private Camera _raycastCamera;

        private IObjectPainter _objectPainter;
        private IUnityRotateService _objectRotator;
        private Vector2? _lastUVPosition;
        
        public UnityObjectController(ButtonsView buttonsView) {
            _buttonsView = buttonsView;
        }

        public void Initialize(GameObject shape, Camera raycastCamera, IObjectPainter objectPainter, IUnityRotateService objectRotator, ControlState state) {
            _shape = shape;
            _raycastCamera = raycastCamera;
            _objectPainter = objectPainter;
            _objectRotator = objectRotator;
            _state = state;
            
            BindEvents();
        }
        
        public void OnTick(float deltaTime) {
            if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonDown(0)){
                Ray ray = _raycastCamera.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out RaycastHit hit)) {
                    return;
                }

                if (hit.transform != _shape.transform) {
                    return;
                }
                
                Vector2 uv;
                if (hit.collider is MeshCollider) {
                    uv = hit.textureCoord;
                } 
                else {
                    return;
                }

                if (_lastUVPosition.HasValue) {
                    DoCurrentState(_lastUVPosition.Value, uv);
                }
                else if (Input.GetMouseButtonDown(0) && _state == ControlState.Rotating) {
                    DoCurrentState(Vector2.zero, uv);
                }

                _lastUVPosition = uv;
            } 
            else {
                _lastUVPosition = null;
                
            }
        }
        
        //TODO: Implement UnBind method when it will be needed
        private void BindEvents() {
            _buttonsView.buttonsByColorMap.ForEach(b => b.button.onClick.AddListener(()=> _state = ControlState.Painting));
            _buttonsView.rotateButton.onClick.AddListener(() => _state = ControlState.Rotating);
        }

        private void DoCurrentState(Vector2 lastPos, Vector2 newPos) {
            switch (_state) {
            case ControlState.Painting:
                _objectPainter.Paint(lastPos, newPos);
                break;
            case ControlState.Rotating:
                _objectRotator.Rotate();
                break;
            case ControlState.None:
                break;
            }
        }
    }
}
