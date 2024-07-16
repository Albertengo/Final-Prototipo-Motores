using enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    [Header("Enemy properties")]
    [SerializeField] float speed;
    [Header("Spawn properties")]
    public float Tvivo = 0f;
    public float TMAXvida = 20f;
    //public static int enemyKills;

    [Header("Enemy Loot")]
    public int Life = 1;
    public GameObject[] Drops;
    //public static int Kills;

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
    public void recibirDaño()//(int daño)
    {
        Life = Life - 1;//daño;
        if (Life <= 0)
        {
            Destroy(gameObject);
            //MECANICA PARA CONTAR COMBO'???
            Loot();
        }
    }
    public void Loot()
    {
        Vector2 position = transform.position; //chequea la posicion
        int dropsIndex = Random.Range(0, Drops.Length); //randomiza la loot
        Instantiate(Drops[dropsIndex], position, Quaternion.identity); //instancia loot a recolectar
    }
}
