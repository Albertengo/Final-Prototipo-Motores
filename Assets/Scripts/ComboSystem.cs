using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    public TextMeshProUGUI Text_Combo;
    float ComboTimeLimit = 3f;
    float ComboTimer;
    int ComboCount;


    void Start()
    {
        TimeLimitCombo();
    }

    // Update is called once per frame
    void Update()
    {
        Text_Combo.text = ComboCount + " Combo!";
    }
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
}
