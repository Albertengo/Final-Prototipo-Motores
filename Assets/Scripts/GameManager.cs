using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //NOTA: agregar una mecanica de agregar tiempo cada vez que muere un enemigo y si no agregar directamente vidas...

    //public UnityEvent AttackOnClick;
    
    public TextMeshProUGUI Text_Coins;
    public Slider Time_Slider;
    public int Tiempo_Juego;
    //public Enemies Enemy_Script;
    //bool Permitido_Atacar;
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        Text_Coins.text = "Coins: " + PlayerMov.Coins;

        //AgregarTiempo();

        if (Time_Slider.value == 0) //si el tiempo llega a 0, gameover.
        {
            TiempoTerminado();
        }
    }

    #region Code
    void StartGame()
    {
        StartCoroutine(Cronometro(Tiempo_Juego));
    }

    public IEnumerator Cronometro(float valorCronometro)
    {
        Time_Slider.value = valorCronometro;
        while (Time_Slider.value > 0)
        {
            yield return new WaitForSeconds(1.0f);
            Time_Slider.value--;
        }
     }

    void TiempoTerminado()
    {
       Debug.Log("GAMEOVER.");
        SceneManager.LoadScene("EndGame");
    }


    public void AgregarTiempo(float tiempoExtra)
    {
        Time_Slider.value += tiempoExtra;
        Debug.Log("Tiempo agregado: " + tiempoExtra + " segundos.");
    }

    #endregion
}


