using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class Parameters
{
    private float _enemyPercentage;
    private float _debuff_BuffPercentage;

    protected float enemyPercentage
    {
        get => _enemyPercentage;
        set
        {
            if (value > 1)
            {
                _enemyPercentage = 1;
                Debug.LogError("EnemyPercentage needs to be between 0.0 and 1");
            }
            else
                _enemyPercentage = value;
        }
    }

    
    protected float debuff_BuffPercentage
    {
        get => _debuff_BuffPercentage;
        set
        {
            if (value > 1)
            {
                _debuff_BuffPercentage = 1;
                Debug.LogError("debuff_BuffPercentage needs to be between 0.0 and 1");
            }
            else
                _debuff_BuffPercentage = value;
        }
    }
}
