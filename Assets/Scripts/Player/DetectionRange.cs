using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class DetectionRange : MonoBehaviour
{
    [SerializeField] Transform Origin;
    RaycastHit hit;
    public float hitRange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //private void OnTriggerStay(Collider collision)
    //{
    //    if (collision.CompareTag("Enemy")) //= Enemigo)
    //    {
    //        detected = true;
    //    }
    //}

    public void EnemyDetected()
    {
        if (Physics.Raycast(Origin.position, Origin.right, out hit, hitRange, this.gameObject.GetComponent<PlayerAttack>().Enemies_Layer)) //(hit.collider != null)
        {
            hit.collider.GetComponent<Enemies>()?.recibirDaño();
            //GetComponent<PlayerAttack>().detected = true;
            Debug.Log("Enemigo Atcado");
        }
    }
}
