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
    //NOTA: capaz agregar un cooldown?

    public LayerMask Enemies_Layer;
    [SerializeField] InputActionReference Attack_Input;
    public DetectionRange Detection;

    Renderer _renderer;
    Material Material;
    //particle system?
    //combo system ?
    
    void Start()
    {
        Attack_Input.action.performed += Attack;
    }

    void Update()
    {
        _renderer = GetComponent<Renderer>();
        Material = GetComponent<Material>();

        //Material.mainTextureOffset = Vector3.zero;
        //_renderer.material.mainTexture.
    }

    private void Attack(InputAction.CallbackContext obj)
    {
        Debug.Log("Attacking");
        //GetComponent<DetectionRange>().EnemyDetected();
        Detection.EnemyDetected();
        //código de ataque c/ particle system
    }

}
