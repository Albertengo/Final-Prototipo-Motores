using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Experimental.GraphView.GraphView;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public LayerMask Enemies_Layer;
    [SerializeField] InputActionReference Attack_Input;
    public DetectionRange Detection;
    public Animator Animator;
    //EndAttack Attacking;

    void Start()
    {
        Attack_Input.action.performed += Attack;
    }

    void Update()
    {
        if (EndAttack.Attacking == false)
            ActualizarAnimacion();
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        Detection.EnemyDetected();
        //Animator.SetBool("IsAttacking", true);
        Animator.Play("Attack");
        EndAttack.Attacking = true;
    }

    void ActualizarAnimacion()
    {
        Animator.Play("Running");
    }

    
}
