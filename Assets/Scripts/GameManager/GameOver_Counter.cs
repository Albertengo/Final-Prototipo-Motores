using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver_Counter : MonoBehaviour
{
    public TextMeshProUGUI maxComboText;
    public TextMeshProUGUI maxCoinsText;

    void Start()
    {
        int maxCombo = PlayerPrefs.GetInt("MaxCombo", 0);
        int maxCoins = PlayerPrefs.GetInt("Coins", 0);
        maxComboText.text = "Max. Combo: " + maxCombo;
        maxCoinsText.text = "Coins collected: " + maxCoins;
    }
}
