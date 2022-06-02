using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.SnakeComponents
{
    [RequireComponent(typeof(TailGenerator))]
    [RequireComponent(typeof(SnakeInput))]
    public class Snake : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _speedSpringing;
        [SerializeField] private SnakeHead _snakeHead;
        [SerializeField] private int _tailSize;

        private SnakeInput _input;
        private TailGenerator _tailGenerator;
        private List<Segment> _tailList;

        public event UnityAction<int> SizeChanged;

        private void Awake()
        {
            _tailGenerator = GetComponent<TailGenerator>();
            _input = GetComponent<SnakeInput>();

            _tailList = _tailGenerator.Generate(_tailSize);


        }

        private void OnEnable()
        {
            _snakeHead.DestroingBlock += DestroySegment;
            _snakeHead.AddSegment += OnAddSegment;
        }

        private void Start()
        {
            SizeChanged?.Invoke(_tailList.Count);
        }

        private void FixedUpdate()
        {
            Move(_snakeHead.transform.position + _snakeHead.transform.up * _moveSpeed);

            _snakeHead.transform.up = _input.GetDirectionMousePositon(_snakeHead.transform.position);
        }

        private void OnDisable()
        {
            _snakeHead.DestroingBlock -= DestroySegment;
            _snakeHead.AddSegment -= OnAddSegment;

        }

        private void Move(Vector3 nextPostion)
        {
            Vector3 previewPosition = _snakeHead.transform.position;

            foreach (var tailItem in _tailList)
            {
                var tempPosition = tailItem.transform.position;
                tailItem.transform.position = Vector2.Lerp(previewPosition, tempPosition, _speedSpringing);
                previewPosition = tempPosition; 
            }

            _snakeHead.Move(nextPostion);
        }

        private void DestroySegment()
        {
            var segment = _tailList[_tailList.Count - 1];
            _tailList.Remove(segment);
            Destroy(segment.gameObject);
            SizeChanged?.Invoke(_tailList.Count);
            if (_tailList.Count == 0) Reload();
        }

        private void Reload()
        {
            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        private void OnAddSegment(int addSegment)
        {
            _tailList.AddRange(_tailGenerator.Generate(addSegment));
            SizeChanged?.Invoke(_tailList.Count);
        }

    }
}