using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StreakCounter : MonoBehaviour {

    public TextMeshPro StreakCounterText, DamageMultiplierText;
    private int _streakCounterVal;
    private decimal _damageMultiplierVal;

    public int StreakCounterVal
    {
        get
        {
            return _streakCounterVal;
        }

        set
        {
            _streakCounterVal = value;
            if(_streakCounterVal % 10 == 0)
            {
                UpdateDamageMultiplier();
            }
            StreakTextUpdate();
        }
    }

    public decimal DamageMultiplierVal
    {
        get
        {
            return _damageMultiplierVal;
        }

        set
        {
            _damageMultiplierVal = value;
            UpdateDamageMultiplierText();
        }
    }

    void Awake()
    {
        StreakCounterVal = 0;
        DamageMultiplierVal = 1.0M;
    }

    void UpdateDamageMultiplierText()
    {
        DamageMultiplierText.text = string.Format("{0}X", _damageMultiplierVal);
    }

    void StreakTextUpdate()
    {
        StreakCounterText.text = string.Format("{0}", _streakCounterVal);
    }


    void UpdateDamageMultiplier()
    {
        DamageMultiplierVal += 0.1M;
    }
}
