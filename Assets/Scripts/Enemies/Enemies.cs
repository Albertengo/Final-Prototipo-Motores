using enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{
    //NOTA: usar el trigger dentro del prefab enemigo para que colisione con el player y sacarle vida si el player no llega a matarlo
    //NOTA2: hay un bug, se generan 2 loots en el mismo lugar en vez de una sola 
    //NOTA3: EL PROBLEMA ES EL COLLIDER, DESACTIVARLO!!

    [Header("Enemy properties")]
    public int Life = 1;
    [SerializeField] float speed;
    [SerializeField] GameObject fx;

    [SerializeField] MeshRenderer meshRenderer;
    [SerializeField] Collider collider_Enemy;

    [Header("Spawn properties")]
    public float Tvivo = 0f;
    public float TMAXvida = 12f;

    [Header("Enemy Loot")]
    public GameObject[] Drops;
    public bool enemyKilled;
    //public static int Kills;

    [Header("Extra")]
    public GameManager gameManager;
    public static event Action OnEnemyKilled;
    //public static event Action OnPlayerCollision;
    //bool colisionando;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement();
        Destroy();
        //colisionando = false;
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
            Debug.Log("Enemigos spawneados: " + Spawner.spawneados);
        }
    }
    public void recibirDaño()//(int daño)
    {
        Life = Life - 1;//daño;
        if (Life <= 0)
        {
            //Destroy(gameObject);
            fx.SetActive(false);
            meshRenderer.enabled = false;
            collider_Enemy.enabled = false;
            
            OnEnemyKilled?.Invoke(); //para invocar el agregar tiempo en el slider

            //MECANICA PARA CONTAR COMBO'???
            Loot();
            enemyKilled = true;
        }
    }
    public void Loot()
    {
        //Vector2 position = transform.position; //chequea la posicion
        int dropsIndex = UnityEngine.Random.Range(0, Drops.Length); //randomiza la loot
        GameObject loot = Drops[dropsIndex];
        Instantiate(loot, this.gameObject.transform); //instancia loot a recolectar
        //Instantiate(loot, position, Quaternion.identity);
    }
}
