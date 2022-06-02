using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.SnakeComponents
{
    [RequireComponent(typeof(Snake))]
    public class SnakeSizeView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;

        private Snake _snake;

        private void Awake()
        {
            _snake = GetComponent<Snake>();
        }

        private void OnEnable()
        {
            _snake.SizeChanged += OnSizeChanged;
        }

        private void OnDisable()
        {
            _snake.SizeChanged -= OnSizeChanged;
        }

        private void OnSizeChanged(int currentSize)
        {
            _text.text = currentSize.ToString();
        }


    }
    
}