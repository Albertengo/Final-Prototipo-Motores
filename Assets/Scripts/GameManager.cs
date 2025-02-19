using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEditor.Timeline.Actions.MenuPriority;

public class GameManager : MonoBehaviour
{
    //NOTA: agregar una mecanica de agregar tiempo cada vez que muere un enemigo y si no agregar directamente vidas...

    //public UnityEvent AttackOnClick;
    [Header("Tiempo Mecánica")]
    public float TiempoInicial_Juego = 20f;
    public float TiempoPresente_Juego;
    public float TiempoExtra = 5f;

    [Header("Referencias")]
    public TextMeshProUGUI Text_Coins;
    public Slider Time_Slider;
    
    //public Enemies Enemy_Script;
    //bool Permitido_Atacar;
    void Start()
    {
        StartingGame();

        StartCoroutine(Cronometro());
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
    void StartingGame()
    {
        SliderConfig();
        Enemies.OnEnemyKilled += AgregarTiempo;// (5f);
    }

    void SliderConfig()
    {
        TiempoPresente_Juego = TiempoInicial_Juego;
        //Debug.Log("Tiempo presente config a: " + TiempoPresente_Juego);
        Time_Slider.maxValue = TiempoInicial_Juego;
        Time_Slider.value = TiempoInicial_Juego;
    }

    void AgregarTiempo()//(float tiempoExtra)
    {
        TiempoPresente_Juego += TiempoExtra;

        if (TiempoPresente_Juego > Time_Slider.maxValue)
            TiempoPresente_Juego = Time_Slider.maxValue; // Limitar al máximo del slider
        Time_Slider.value = TiempoPresente_Juego;

        Debug.Log("Tiempo agregado: 5 segundos.");
        Debug.Log("Tiempo agregado: " + TiempoExtra + " segundos.");
    }

    public IEnumerator Cronometro()
    {
        while (TiempoPresente_Juego > 0)
        {
            yield return new WaitForSeconds(1.0f);
            TiempoPresente_Juego--;
            Time_Slider.value = TiempoPresente_Juego;
        }
     }

    void TiempoTerminado()
    {
        Debug.Log("GAMEOVER.");
        SceneManager.LoadScene("EndGame");
    }
    #endregion
}


