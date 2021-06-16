using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hall : Room
{
    private float _trapPercentage;
    public float trapPercentage 
    {
        get => _trapPercentage;
        set
        {
            if(value > 1)
            {
                _trapPercentage = 1;
                Debug.LogError("trapPercentage needs to be between 0.0 and 1");

            }
            else
                _trapPercentage = value;
        } 
    }

    public Hall(float trapPercentage,float enemyPercentage,float debuff_BuffPercentage, RoomDifficult difficult) : base(enemyPercentage,debuff_BuffPercentage,difficult)
    {
        this.trapPercentage = trapPercentage;
    }

    public void SpawnTrap(int stat,bool activate,int MoneyAmount)
    {
        if(trapPercentage > 0 && Random.value <= trapPercentage)
        {
            if (activate)
            {
                stat_Changed = Mathf.RoundToInt(stat - (stat / 4));
            }
            else
            {
               money = Neutral(MoneyAmount, Room.RoomDifficult.easy);
            }
        }
    }
}
