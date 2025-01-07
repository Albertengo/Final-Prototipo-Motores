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
    //NOTA: por alguna razón desde el inspector se marca que ataca dos veces.
    //NOTA2: ahora parece que solo funciona siempre que no se spawnee un enemigo??

    public GameManager AttackEvent;
    //public int DetectionRange = 2;
    public LayerMask Enemies_Layer;
    public bool detected;
    [SerializeField] InputActionReference Attack_Input;
    //public Enemies Enemigo;
    GameObject Enemigo;
    public DetectionRange Detection;

    //bool enemyIsNear;

    Renderer _renderer;
    Material Material;
    //particle system?
    //combo system ?
    
    void Start()
    {
        //AttackEvent.AttackOnClick.AddListener(Attack); //cambiar x input system pq no parece estar funcionando bien con esto
        Attack_Input.action.performed += Attack;
    }

    // Update is called once per frame
    void Update()
    {
        _renderer = GetComponent<Renderer>();
        Material = GetComponent<Material>();
        Enemigo = GameObject.FindGameObjectWithTag("Enemy");

        //Material.mainTextureOffset = Vector3.zero;
        //_renderer.material.mainTexture.
    }

    private void Attack(InputAction.CallbackContext obj) //necesito q detecte a los enemigos y sus scripts
    {
        Debug.Log("Attacking");
        //GetComponent<DetectionRange>().EnemyDetected();
        Detection.EnemyDetected();
        //código de ataque c/ particle system
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
