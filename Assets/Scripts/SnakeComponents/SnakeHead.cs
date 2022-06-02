using Assets.Scripts.Blocks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.SnakeComponents
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SnakeHead : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;

        public event UnityAction DestroingBlock;
        public event UnityAction<int> AddSegment;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector3 newPosition)
        {
            _rigidbody.MovePosition(newPosition);
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Block block))
            {
                DestroingBlock?.Invoke();
                block.Fill();
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Bonus bonus))
            {
                var addSegmentsCount = bonus.GetBonusSize();
                AddSegment?.Invoke(addSegmentsCount);
            }
        }
    }
}