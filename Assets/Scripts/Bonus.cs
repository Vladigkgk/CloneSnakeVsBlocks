using System.Collections;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private TMP_Text _bonusSizeView;
        [SerializeField] private Vector2Int _bonusSizeRange;

        private int _bonusSize;

        private void Start()
        {
            _bonusSize = Random.Range(_bonusSizeRange.x, _bonusSizeRange.y);
            _bonusSizeView.text = _bonusSize.ToString();
        }

        public int GetBonusSize()
        {
            Destroy(gameObject);
            return _bonusSize;
        }

    }
}