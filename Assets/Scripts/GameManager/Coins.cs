using UnityEngine;

public class Coins : MonoBehaviour
{
    public static int coins;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("MONEDA RECOGIDA");
            coins++;
            PlayerPrefs.SetInt("Coins", coins);
            Debug.Log("CANTIDAD: " + coins);
        }
    }
}