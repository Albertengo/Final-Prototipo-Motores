using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    //NOTA: por alguna razón desde el inspector se marca que ataca dos veces.

    public GameManager AttackEvent;

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
        //código de ataque c/ particle system
    }

    

}
