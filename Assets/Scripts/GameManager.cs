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
    
    public TextMeshProUGUI Text_Coins;
    public Slider Time_Slider;
    public float TiempoInicial_Juego = 20f;
    public float TiempoPresente_Juego;
    public bool agregarTiempo_Bool; 
    //public Enemies Enemy_Script;
    //bool Permitido_Atacar;
    void Start()
    {
        StartGame();

        StartCoroutine(Cronometro());
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
        SliderConfig();
        Enemies.OnEnemyKilled += AgregarTiempo;// (5f);
       // StartCoroutine(Cronometro(TiempoInicial_Juego));
    }

    void SliderConfig()
    {
        TiempoPresente_Juego = TiempoInicial_Juego;
        Debug.Log("Tiempo presente config a: " + TiempoPresente_Juego);
        Time_Slider.maxValue = TiempoInicial_Juego;
        Time_Slider.value = TiempoInicial_Juego;
    }

    public IEnumerator Cronometro()
    {
        //Time_Slider.value = valorCronometro;
        while (TiempoPresente_Juego > 0)
        {
            //if (agregarTiempo_Bool == true)
            //{
            //    AgregarTiempo(10);

            //}
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


    void AgregarTiempo()//(float tiempoExtra)
    {
        TiempoPresente_Juego += 5f;//tiempoExtra;

        if (TiempoPresente_Juego > Time_Slider.maxValue)
            TiempoPresente_Juego = Time_Slider.maxValue; // Limitar al máximo del slider
        Time_Slider.value = TiempoPresente_Juego;

        Debug.Log("Tiempo agregado: 5 segundos.");
        //Debug.Log("Tiempo agregado: " + tiempoExtra + " segundos.");
    }
    public void BoolTiempo()
    {
        //para activar el bool de tiempo y accederlo desde el script de enemies??
    }
    #endregion
}


