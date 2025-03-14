using UnityEngine;

namespace enemies
{
    public class Spawner : MonoBehaviour
    {
        public GameObject[] enemies;
        public Transform SpawnPosition;
        public float TArranque;
        public float Repeticion;
        public static int spawneados;

        void Start()
        {
            InvokeRepeating("SpawnObjetos", TArranque, Repeticion);
        }

        void SpawnObjetos()
        {
                int RandomIndex = Random.Range(0, enemies.Length);
                GameObject RandomEnemy = enemies[RandomIndex];
                Instantiate(RandomEnemy, SpawnPosition.position, RandomEnemy.transform.rotation);
                spawneados++;
        }
    }
}
