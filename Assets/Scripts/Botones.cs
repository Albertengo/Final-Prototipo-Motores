//using BotsEnemigos;
//using Jugador;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace interfaz
{
    public class Botones : MonoBehaviour
    {
        //lógica para los botones usados dentro del juego
        public void Restart()
        {
            PlayerPrefs.SetInt("MaxCombo", 0);
            PlayerPrefs.SetInt("Coins", 0);
            SceneManager.LoadScene("Game");
            Time.timeScale = 1f;
        }
        public void Menu()
        {
            SceneManager.LoadScene("Menu");
        }
        public void PlayButton()
        {
            PlayerPrefs.SetInt("MaxCombo", 0);
            PlayerPrefs.SetInt("Coins", 0);
            SceneManager.LoadScene("Game");
            Time.timeScale = 1f;
        }
        public void QuitGame()
        {
            Debug.Log("Saliste.");
            Application.Quit();
        }
    }
}
