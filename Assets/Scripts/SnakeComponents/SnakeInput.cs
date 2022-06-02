using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SnakeComponents
{
    public class SnakeInput : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        public Vector2 GetDirectionMousePositon(Vector3 headPosition)
        {
            Vector3 mousePositon = Input.mousePosition;

            mousePositon = _camera.ScreenToViewportPoint(mousePositon);
            mousePositon.y = 1;
            mousePositon = _camera.ViewportToWorldPoint(mousePositon);

            Vector2 diretion = new Vector2(mousePositon.x - headPosition.x, mousePositon.y - headPosition.y);

            return diretion;

        }
    }
}