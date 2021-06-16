using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : Parameters
{ 
    public enum RoomDifficult
    {
        easy,
        normal,
        hard,
    }

    protected int stat_Changed;
    protected int money;
    private int[,] enemys_and_Stats;
    protected RoomDifficult difficult;

    public Room(float enemyPercentage, float debuff_BuffPercentage, RoomDifficult difficult)
    {
        this.enemyPercentage = enemyPercentage;
        this.debuff_BuffPercentage = debuff_BuffPercentage;
        this.difficult = difficult;

    }

    public void SpawnEnemies(int statsAmount,int[] statsValue,int enemyAmount)
    {
        if (enemyPercentage > 0 && Random.value <= enemyPercentage)
        {
            float numberOfEnemys;
            switch (difficult)
            {
                case RoomDifficult.easy:
                    numberOfEnemys = enemyAmount * 0.3f;
                    numberOfEnemys = Mathf.Round(numberOfEnemys);
                    EnemysStats(statsAmount, statsValue, Mathf.RoundToInt(numberOfEnemys));
                    break;

                case RoomDifficult.normal:
                    numberOfEnemys = enemyAmount * 0.5f;
                    numberOfEnemys = Mathf.Round(numberOfEnemys);
                    EnemysStats(statsAmount, statsValue, Mathf.RoundToInt(numberOfEnemys));
                    break;

                case RoomDifficult.hard:
                        EnemysStats(statsAmount, statsValue, enemyAmount);
                    break;
            }
        }
    }


    private void EnemysStats(int statsAmount, int[] statusValue, int enemyAmount)
    {
        int[,] stats_and_Enemys_MaxAmount = new int[enemyAmount,statsAmount];

        switch (difficult)
        {
            case RoomDifficult.easy:
                for (int i = 0; i < stats_and_Enemys_MaxAmount.GetLength(0); i++)
                {
                    for (int j = 0; j < stats_and_Enemys_MaxAmount.GetLength(1); j++)
                    {
                        stats_and_Enemys_MaxAmount[i, j] = statusValue[j];
                    }
                }
                break;
            case RoomDifficult.normal:
                for (int i = 0; i < stats_and_Enemys_MaxAmount.GetLength(0); i++)
                {
                    for (int j = 0; j < stats_and_Enemys_MaxAmount.GetLength(1); j++)
                    {
                        stats_and_Enemys_MaxAmount[i, j] = statusValue[j] + (statusValue[j]/2);
                    }
                }
                break;

            case RoomDifficult.hard:
                for (int i = 0; i < stats_and_Enemys_MaxAmount.GetLength(0); i++)
                {
                    for (int j = 0; j < stats_and_Enemys_MaxAmount.GetLength(1); j++)
                    {
                        stats_and_Enemys_MaxAmount[i, j] = statusValue[j] * 2;
                    }
                }
                break;
        }
        enemys_and_Stats = stats_and_Enemys_MaxAmount;
    }

    public int[,] GetEnemy_and_Stats()
    {
        return enemys_and_Stats;
    }





    public void SpawnDebuffs_Buffs(int stat, int MaxMoney)
    {
        if(MaxMoney <= 0)
        {
            MaxMoney = 1;
        }

        if(stat < 0)
        {
            stat = 0;
        }

        if(debuff_BuffPercentage > 0 && Random.value <= debuff_BuffPercentage)
        {
            float eventType_Check;

            switch (difficult)
            {
                case RoomDifficult.easy:
                    eventType_Check = Random.value;
                    if(eventType_Check < 0.5f)
                    {
                        stat_Changed = Buff(stat, difficult);
                    }
                    else if(eventType_Check >= 0.5f && eventType_Check < 0.8f)
                    {
                        money = Neutral(MaxMoney, difficult);
                    }
                    else
                    {
                        stat_Changed = Debuff(stat, difficult);
                    }
                    break;

                case RoomDifficult.normal:
                    eventType_Check = Random.value;
                    if (eventType_Check < 0.4f)
                    {
                        stat_Changed = Buff(stat, difficult);
                    }
                    else if (eventType_Check >= 0.4f && eventType_Check < 0.7f)
                    {
                        money = Neutral(MaxMoney, difficult);
                    }
                    else
                    {
                        stat_Changed = Debuff(stat, difficult);
                    }
                    break;

                case RoomDifficult.hard:
                    eventType_Check = Random.value;
                    if (eventType_Check < 0.3f)
                    {
                        stat_Changed = Buff(stat, difficult);
                    }
                    else if (eventType_Check >= 0.3f && eventType_Check < 0.7f)
                    {
                        money = Neutral(MaxMoney, difficult);
                    }
                    else
                    {
                        stat_Changed = Debuff(stat, difficult);
                    }
                    break;
            }
        }
    }

 

    private int Buff(int stat ,RoomDifficult difficult)
    {
        switch (difficult)
        {
         case RoomDifficult.easy:
             stat = stat * (1 + 1);
             break;

         case RoomDifficult.normal:
                stat = (int)(stat * (1 + 0.5f));
                stat = stat + (stat/2);
                Debug.Log("buff " + stat);
            break;

            case RoomDifficult.hard:
            stat = (int)(stat * (1 + 0.3f));
            break;
        }
        return stat;
    }

    private int Debuff(int stat, RoomDifficult difficult)
    {
        switch (difficult)
        {
            case RoomDifficult.easy:
                stat = (int)(stat * (1 - 0.3f));
                break;

            case RoomDifficult.normal:
            stat = (int)(stat * (1 - 0.4f));
                break;

           case RoomDifficult.hard:
                stat = (int)(stat * (1 - 0.5f));
                break;
        }
        return stat;
    }

    public int GetStat_Changed()
    {
        int stat = stat_Changed;
        stat_Changed = 0;
        return stat;
    }




    protected int Neutral(int MaxAmount, RoomDifficult difficult)
    {
        int money = MaxAmount;

        switch (difficult)
        {
            case RoomDifficult.easy:
                money = MaxAmount;
                break;

            case RoomDifficult.normal:
                money = MaxAmount / 2;
                break;

            case RoomDifficult.hard:
                money = Mathf.RoundToInt(MaxAmount / 4);
                break;
        }
        return money;
    }

    public int GetMoney()
    {
        int m = money;
        money = 0;
        if(m == 0)
        {
            return -1;
        }
        else
        {
            return m;
        }
    }
}

