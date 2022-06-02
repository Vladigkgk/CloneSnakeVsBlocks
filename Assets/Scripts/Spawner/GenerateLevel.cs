using Assets.Scripts.Blocks;
using Assets.Scripts.Spawner.SpawnerPoints;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Spawner
{
    public class GenerateLevel : MonoBehaviour
    {
        [Header("Main")]
        [SerializeField] private Transform _container;
        [SerializeField] private int _repeatCount;
        [SerializeField] private int _distanceBetweenFullingLine;
        [SerializeField] private int _distanceBetweenRandowLine;
        [Header("Blocks")]
        [SerializeField] private Block _blockTemplete;
        [SerializeField] private int _blockChance;
        [Header("Walls")]
        [SerializeField] private Wall _wallTemplate;
        [SerializeField] private int _wallChance;
        [SerializeField] private float _modifyScaleY;
        [Header("Bonus")]
        [SerializeField] private Bonus _bonusTemplate;
        [SerializeField] private int _bonusChance;

        private BlockSpawnPoint[] _blockPoints;
        private WallSpawnPoint[] _wallPoints;

        private void Start()
        {
            _blockPoints = GetComponentsInChildren<BlockSpawnPoint>();
            _wallPoints = GetComponentsInChildren<WallSpawnPoint>();

            for (int i = 0; i < _repeatCount; i++)
            {
                MoveSpawner();
                GenerateRandomLine(_wallPoints, _wallTemplate.gameObject, _wallChance, _distanceBetweenFullingLine / _modifyScaleY, false,  _distanceBetweenFullingLine / 2.5f);
                GenerateFullLine(_blockPoints, _blockTemplete.gameObject);
                MoveSpawner();
                GenerateRandomLine(_blockPoints, _blockTemplete.gameObject, _blockChance, _blockTemplete.transform.localScale.y, true);
                GenerateRandomLine(_wallPoints, _wallTemplate.gameObject, _wallChance, _distanceBetweenRandowLine /  _modifyScaleY, false, _distanceBetweenRandowLine / 2.5f);


            }
        }

        private void MoveSpawner()
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + _distanceBetweenFullingLine, transform.position.z);
        }

        private void GenerateFullLine(SpawnPoint[] spawnPoints, GameObject spawnedGameObject)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GenerateGameObject(spawnPoints[i].transform.position, spawnedGameObject);
            }
        }

        private void GenerateRandomLine(SpawnPoint[] spawnPoints, GameObject spawnedGameObject, int spawnChance, float scaleY, bool isBonus, float offsetY = 0)
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                if (Random.Range(0, 100) < spawnChance)
                {
                    var spawn =  GenerateGameObject(spawnPoints[i].transform.position, spawnedGameObject, offsetY);
                    spawn.transform.localScale = new Vector3(spawn.transform.localScale.x, scaleY, spawn.transform.localScale.z);
                }
                else if (isBonus)
                {
                    if(Random.Range(0, 100) < _bonusChance)
                    {
                        GenerateGameObject(spawnPoints[i].transform.position, _bonusTemplate.gameObject);
                    }
                }
            }
        }

        private GameObject GenerateGameObject(Vector3 spawnPoint, GameObject spawnedGameObject, float offsetY = 0)
        {
            spawnPoint.y -= offsetY;
            return Instantiate(spawnedGameObject, spawnPoint, Quaternion.identity, _container);

        }
    }
}