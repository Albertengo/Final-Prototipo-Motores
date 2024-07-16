using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public UnityEvent AttackOnClick;
    public TextMeshProUGUI Text_Coins;
    public Slider Time_Slider;
    void Start()
    {
        StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            AttackOnClick.Invoke();
        Text_Coins.text = "Coins: " + PlayerMov.Coins;

        if (Time_Slider.value == 0) //si el tiempo llega a 0, gameover.
        {
            TiempoTerminado();
        }
    }

    #region Code
    void StartGame()
        {
            StartCoroutine(Cronometro(20));
        }

        public IEnumerator Cronometro(float valorCronometro = 20)
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
        }
}
#endregion

