using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{

    public LayerMask Enemies_Layer;
    [SerializeField] InputActionReference Attack_Input;
    public DetectionRange Detection;
    public Animator Animator;

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
        Animator.Play("Attack");
        EndAttack.Attacking = true;
    }

    void ActualizarAnimacion()
    {
        Animator.Play("Running");
    }

    
}
