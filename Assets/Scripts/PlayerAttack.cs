using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    //NOTA: por alguna raz�n desde el inspector se marca que ataca dos veces.

    public GameManager AttackEvent;
    //particle system?
    //combo system ?

    void Start()
    {
        AttackEvent.AttackOnClick.AddListener(Attack);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        Debug.Log("Attacking");
        //c�digo de ataque c/ particle system
    }
}
