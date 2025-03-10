using enemies;
using UnityEngine;
using System;

public class Enemies : MonoBehaviour
{
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

    [Header("Extra")]
    public GameManager gameManager;
    public static event Action OnEnemyKilled;
    public static event Action AddCombo;

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
            Debug.Log("Enemigos spawneados: " + Spawner.spawneados);
        }
    }
    public void recibirDaño()//(int daño)
    {
        Life = Life - 1;//daño;
        if (Life <= 0)
        {
            fx.SetActive(false);
            meshRenderer.enabled = false;
            collider_Enemy.enabled = false;
            
            OnEnemyKilled?.Invoke(); //para invocar el agregar tiempo en el slider

            Loot();
            enemyKilled = true;
            AddCombo?.Invoke();
        }
    }
    public void Loot()
    {
        int dropsIndex = UnityEngine.Random.Range(0, Drops.Length); //randomiza la loot
        GameObject loot = Drops[dropsIndex];
        Instantiate(loot, this.gameObject.transform); //instancia loot a recolectar
    }
}
