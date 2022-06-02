using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class CameraResolution : MonoBehaviour
    {
        private float _defaultCamera;
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;

            _defaultCamera = _camera.orthographicSize * _camera.aspect;
        }

        private void Update()
        {
            _camera.orthographicSize = _defaultCamera / _camera.aspect;
        }
    }
}