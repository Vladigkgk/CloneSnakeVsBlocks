using System.Collections;
using UnityEngine;

namespace Assets.Scripts.SnakeComponents
{
    public class CameraTracking : MonoBehaviour
    {
        [SerializeField] private SnakeHead _snakeHead;
        [SerializeField] private float _speed;
        [SerializeField] private float _offsetY;

        private void FixedUpdate()
        {
            Vector3 newPosition = Vector3.Lerp(transform.position, GetPosition(), _speed);
            transform.position = newPosition;
        }

        private Vector3 GetPosition()
        {
            return new Vector3(transform.position.x, _snakeHead.transform.position.y + _offsetY, transform.position.z);
        }
    }
}