using _3DBrushCode.Logic.Contracts;
using UnityEngine;

namespace _3DBrushCode.Logic.Services.ObjectRotateService {
    public class ObjectRotateService : IUnityRotateService {
        private const float RotationSpeed = 40f;
        private GameObject _object;

        private bool _isDragging;
        private Vector3 _lastMousePosition;

        public void SetObject(GameObject shape) {
            _object = shape;
        }

        public void Rotate() {
            if (Input.GetMouseButtonDown(0)) {
                _lastMousePosition = Input.mousePosition;
                _isDragging = true;
            }

            if (Input.GetMouseButtonUp(0)) {
                _isDragging = false;
            }

            if (_isDragging && Input.GetMouseButton(0)) {
                Vector3 currentMousePosition = Input.mousePosition;
                Vector3 deltaMousePosition = currentMousePosition - _lastMousePosition;

                if (deltaMousePosition.magnitude > 0) {
                    float rotationX = deltaMousePosition.y * RotationSpeed * Time.deltaTime;
                    float rotationY = -deltaMousePosition.x * RotationSpeed * Time.deltaTime;

                    _object.transform.Rotate(Vector3.up, rotationY, Space.World);
                    _object.transform.Rotate(Vector3.right, rotationX, Space.World);
                }

                _lastMousePosition = currentMousePosition;
            }
        }
    }
}
