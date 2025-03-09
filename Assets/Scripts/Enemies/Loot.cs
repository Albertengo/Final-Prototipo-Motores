using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //("" + "Coin"))
        {
            Destroy(this.gameObject);
            Debug.Log("MONEDA RECOGIDA");
        }
    }
}
