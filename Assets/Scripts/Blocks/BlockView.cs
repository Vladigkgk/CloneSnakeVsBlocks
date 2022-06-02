using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts.Blocks
{
    [RequireComponent(typeof(Block))]
    public class BlockView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        
        private Block _block;

        private void Awake()
        {
            _block = GetComponent<Block>();
        }

        private void OnEnable()
        {
            _block.FillCountChange += OnFillCountChange;
        }

        private void OnDisable()
        {
            _block.FillCountChange -= OnFillCountChange;
        }

        private void OnFillCountChange(int currentValue)
        {
            _text.text = currentValue.ToString();
        }
    }
}