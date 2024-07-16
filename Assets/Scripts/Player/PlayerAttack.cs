using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    //NOTA: por alguna raz�n desde el inspector se marca que ataca dos veces.

    public GameManager AttackEvent;
    public Enemies Enemigo;
    //bool enemyIsNear;

    Renderer _renderer;
    Material Material;
    //particle system?
    //combo system ?

    void Start()
    {
        AttackEvent.AttackOnClick.AddListener(Attack);
    }

    // Update is called once per frame
    void Update()
    {
        _renderer = GetComponent<Renderer>();
        Material = GetComponent<Material>();

        //Material.mainTextureOffset = Vector3.zero;
        //_renderer.material.mainTexture.
    }

    public void Attack()
    {
        Debug.Log("Attacking");
        Enemigo.recibirDa�o(); // enemigo recibe da�o apenas spawnea y el player hace click, capaz resolverlo con  booleano??
        //Enemigo.recibirDa�o(1); // enemigo recibe da�o apenas spawnea y el player hace click, capaz resolverlo con  booleano??
        
        //c�digo de ataque c/ particle system
    }

    //void Attack2()
    //{
    //    Collider[] hitBox = Physics.OverlapSphere(ultimateHitBox.transform.position, ultimateRange, enemy);

    //    foreach (var box in hitBox)
    //    {
    //        box.GetComponent<EnemyController>().die();
    //    }
    //}



}
