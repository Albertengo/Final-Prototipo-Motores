using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
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
        //código de ataque c/ particle system
    }
}
