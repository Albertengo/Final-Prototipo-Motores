using enemies;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemies : MonoBehaviour
{
    //NOTA: hacer que la loot sea hijo del enemy para que siga moviendose despues de que se muera el enemigo y no se quede en el piso nomas
    // (para dar la ilusion de que el personaje se sigue moviendo y no está estático)
    //NOTA2: usar el trigger dentro del prefab enemigo para que colisione con el player y sacarle vida si el player no llega a matarlo

    [Header("Enemy properties")]
    [SerializeField] float speed;
    [SerializeField] GameObject fx;

    [SerializeField] MeshRenderer meshRenderer;

    [Header("Spawn properties")]
    public float Tvivo = 0f;
    public float TMAXvida = 20f;
    //public static int enemyKills;

    [Header("Enemy Loot")]
    public int Life = 1;
    public GameObject[] Drops;
    public bool enemyKilled;
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
            //Destroy(gameObject);
            fx.SetActive(false);
            meshRenderer.enabled = false;
            
            Debug.Log("enemigo desactivado");
            //MECANICA PARA CONTAR COMBO'???
            Loot();
            enemyKilled = true;
        }
    }
    public void Loot()
    {
        //Vector2 position = transform.position; //chequea la posicion
        int dropsIndex = Random.Range(0, Drops.Length); //randomiza la loot
        GameObject loot = Drops[dropsIndex];
        //this.transform.parent = loot.transform;
        //Instantiate(loot, position, Quaternion.identity); //instancia loot a recolectar
        Instantiate(loot, this.gameObject.transform); //instancia loot a recolectar
        //loot.transform.SetParent(this.gameObject.transform, true);
    }
}
