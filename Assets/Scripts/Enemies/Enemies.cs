using enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Enemy properties")]
    [SerializeField] float speed;
    [Header("Spawn properties")]
    public float Tvivo = 0f;
    public float TMAXvida = 20f;
    //public static int enemyKills;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Destroy();
    }
    void movement()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World); //constantemente se mueve al frente
    }
    void Destroy()
    {
        Tvivo += Time.deltaTime; //contador
        if (Tvivo > TMAXvida)
        {
            Destroy(this.gameObject);
            Spawner.spawneados--;
        }
    }
}
