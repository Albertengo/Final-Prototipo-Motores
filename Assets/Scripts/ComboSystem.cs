using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    //NOTA: maybe hacer un unity event "AddCombo" para poder invocar countingCombo() desde el enemy script?

    public TextMeshProUGUI Text_Combo;
    float ComboTimeLimit = 3f;
    float ComboTimer;
    int ComboCount;

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
