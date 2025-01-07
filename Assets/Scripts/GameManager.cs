using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //public UnityEvent AttackOnClick;
    
    public TextMeshProUGUI Text_Coins;
    public Slider Time_Slider;
    public int Tiempo_Juego;
    //bool Permitido_Atacar;
    void Start()
    {
        StartGame();
    }

    void Update()
    {
        Text_Coins.text = "Coins: " + PlayerMov.Coins;

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
}
#endregion

