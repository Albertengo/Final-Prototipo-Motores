using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public TextMeshProUGUI Text_Combo;
    float ComboTimeLimit = 3f;
    float ComboTimer;
    int ComboCount;
    int maxCombo;

    #region funciones básicos
    void Start()
    {
        
        Enemies.AddCombo += CountingCombo;
    }

    // Update is called once per frame
    void Update()
    {
        TimeLimitCombo();

        ActualizarTexto();
    }
    #endregion

    #region Code
    void TimeLimitCombo()
    {
        if (ComboCount > 0)
        {
            ComboTimer -= Time.deltaTime;
            if (ComboTimer <= 0)
            {
                ResetCombo();
            }
        }
    }
    public void CountingCombo()
    {
        ComboCount++;
        ComboTimer = ComboTimeLimit;

        if (ComboCount > maxCombo)
        {
            maxCombo = ComboCount;
            PlayerPrefs.SetInt("MaxCombo", maxCombo); // Guarda el máximo combo
        }
    }

    private void ResetCombo()
    {
        ComboCount = 0;
        ComboTimer = 0f;
    }

    private void ActualizarTexto()
    {
        if (ComboCount > 0)
        {
            Text_Combo.enabled = true;
            Text_Combo.text = ComboCount + " Combo!";
        }
        else
            Text_Combo.enabled = false;
    }
    #endregion
}
