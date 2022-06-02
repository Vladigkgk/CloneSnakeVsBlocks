using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.SnakeComponents
{
    public class TailGenerator : MonoBehaviour
    {
        [SerializeField] private Segment _tail;

        public List<Segment> Generate(int tailSize)
        {
            List<Segment> tailList = new List<Segment>();

            for (int i = 0; i < tailSize; i++)
            {
                tailList.Add(Instantiate(_tail, transform));
            }

            return tailList;
        }
    }
}