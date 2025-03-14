using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Tiempo Mec�nica")]
    public float TiempoInicial_Juego = 20f;
    public float TiempoPresente_Juego;
    public float TiempoExtra = 5f;

    [Header("Referencias")]
    public Slider Time_Slider;

    public TextMeshProUGUI Text_Coins;

    void Start()
    {
        StartingGame();

        StartCoroutine(Cronometro());
    }

    void Update()
    {
        Text_Coins.text = "Objectives completed: " + Coins.coins;

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
        //Enemies.OnPlayerCollision += SacarTiempo;
        PlayerMov.OnEnemyCollision += SacarTiempo;
    }

    void SliderConfig()
    {
        TiempoPresente_Juego = TiempoInicial_Juego;
        Time_Slider.maxValue = TiempoInicial_Juego;
        Time_Slider.value = TiempoInicial_Juego;
    }

    void AgregarTiempo()//(float tiempoExtra)
    {
        TiempoPresente_Juego += TiempoExtra;

        if (TiempoPresente_Juego > Time_Slider.maxValue)
            TiempoPresente_Juego = Time_Slider.maxValue; // Limitar al m�ximo del slider
        Time_Slider.value = TiempoPresente_Juego;

        Debug.Log("Tiempo agregado: 5 segundos.");
        Debug.Log("Tiempo agregado: " + TiempoExtra + " segundos.");
    }
    void SacarTiempo()
    {
        TiempoPresente_Juego -= TiempoExtra;

        if (TiempoPresente_Juego < Time_Slider.minValue)
            TiempoPresente_Juego = Time_Slider.minValue; // Limitar al m�nimo del slider
        Time_Slider.value = TiempoPresente_Juego;
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


