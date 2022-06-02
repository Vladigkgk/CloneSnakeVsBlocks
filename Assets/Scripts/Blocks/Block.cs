using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Blocks
{
    public class Block : MonoBehaviour
    {
        [SerializeField] private Vector2Int _blocksToDestroyRange;
        [SerializeField] private Color[] _colors;

        private SpriteRenderer _spriteRenderer;
        private int _needDestroy;
        private int _filling;

        public event UnityAction<int> FillCountChange;
        public int CurrentValue => _needDestroy - _filling;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            _spriteRenderer.color = _colors[Random.Range(0, _colors.Length - 1)];
        }

        private void Start()
        {
            _needDestroy = Random.Range(_blocksToDestroyRange.x, _blocksToDestroyRange.y);
            FillCountChange?.Invoke(CurrentValue);
        }

        public void Fill()
        {
            _filling++;
            FillCountChange?.Invoke(CurrentValue);

            if (_filling == _needDestroy)
            {
                Destroy(gameObject);
            }
        }
    }
}