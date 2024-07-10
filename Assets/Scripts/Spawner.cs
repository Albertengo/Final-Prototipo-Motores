using System.Collections;
using System.Collections.Generic;
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

        private void Update()
        {

        }
        //void InvokeSpawn()
        //{
        //    //SpawnEnemigos();
        //    while (spawneados < 3)
        //    {
        //        InvokeRepeating("SpawnObjetos", TArranque, Repeticion);
        //    }
        //}
        void SpawnObjetos()
        {
            if (spawneados < 3)
            {
                int RandomIndex = Random.Range(0, enemies.Length);
                GameObject RandomEnemy = enemies[RandomIndex];
                Instantiate(RandomEnemy, SpawnPosition.position, RandomEnemy.transform.rotation);
                spawneados++;
            }
            else
                CancelInvoke("SpawnObjetos");
            
        }
        //IEnumerator SpawnEnemigos()
        //{
            
        //}
    }
}
