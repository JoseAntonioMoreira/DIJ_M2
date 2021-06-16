using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Test_Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //CreateRoom();
        CreateHall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateRoom()
    {
        Room.RoomDifficult roomSelect;
        float roll = Random.value;
        if (roll > 0.8f)
        {
            roomSelect = Room.RoomDifficult.hard;
        }else if(roll >= 0.4f)
        {
            roomSelect = Room.RoomDifficult.normal;
        }
        else
        {
            roomSelect = Room.RoomDifficult.easy;
        }

        Debug.Log(roomSelect);
        Room room = new Room(0.9f,0.9f,roomSelect);


        int numberOfEnemies = 5;
        int numberOfStats = 4;
        int[] statusValue = new int[numberOfStats];
        statusValue[0] = Random.Range(100, 201);
        statusValue[1] = Random.Range(0, 6);
        statusValue[2] = Random.Range(0, 6);
        statusValue[3] = Random.Range(0, 6);


        room.SpawnEnemies(numberOfStats,statusValue,numberOfEnemies);
        int[,] enemies_Stats;

        if (room.GetEnemy_and_Stats() != null)
        {
            enemies_Stats = room.GetEnemy_and_Stats();
            for (int i = 0; i < enemies_Stats.GetLength(0); i++)
            {
                for (int j = 0; j < enemies_Stats.GetLength(1); j++)
                {
                    Debug.Log("EnemyStat " + enemies_Stats.GetValue(i, j));
                }
            }
        }
        else
        {
            Debug.Log("Safe Roll");
        }




        room.SpawnDebuffs_Buffs(statusValue[0], 10);

        int moneyReceveid = room.GetMoney();
        int stat_Changed = room.GetStat_Changed();
        if(stat_Changed > 0)
        {
            statusValue[0] = stat_Changed;
            Debug.Log("Stat Changed " + statusValue[0]);
        }
        else if(moneyReceveid > 0)
        {
            int totalMoney = 10;
            totalMoney += moneyReceveid;
            Debug.Log("Money! " + totalMoney);
        }
        else
        {
            Debug.Log("No extra!");
        }
    }

    void CreateHall()
    {
        Room.RoomDifficult roomSelect;
        float roll = Random.value;
        if (roll > 0.8f)
        {
            roomSelect = Room.RoomDifficult.hard;
        }
        else if (roll >= 0.4f)
        {
            roomSelect = Room.RoomDifficult.normal;
        }
        else
        {
            roomSelect = Room.RoomDifficult.easy;
        }

        Debug.Log(roomSelect);


        Hall hall = new Hall(0.9f,0.9f,0.9f, roomSelect);


        int numberOfEnemies = 5;
        int numberOfStats = 4;
        int[] statusValue = new int[numberOfStats];
        statusValue[0] = Random.Range(100, 201);
        statusValue[1] = Random.Range(0, 6);
        statusValue[2] = Random.Range(0, 6);
        statusValue[3] = Random.Range(0, 6);


        hall.SpawnEnemies(numberOfStats, statusValue, numberOfEnemies);
        int[,] enemies_Stats;


        if (hall.GetEnemy_and_Stats() != null)
        {
            enemies_Stats = hall.GetEnemy_and_Stats();
            for (int i = 0; i < enemies_Stats.GetLength(0); i++)
            {
                for (int j = 0; j < enemies_Stats.GetLength(1); j++)
                {
                    Debug.Log("EnemyStat " + enemies_Stats.GetValue(i, j));
                }
            }
        }
        else
        {
            Debug.Log("Safe Roll");
        }




        hall.SpawnDebuffs_Buffs(statusValue[0], 10);

        int moneyReceveid = hall.GetMoney();
        int stat_Changed = hall.GetStat_Changed();
        if (stat_Changed > 0)
        {
            statusValue[0] = stat_Changed;
            Debug.Log("Stat Changed " + statusValue[0]);
        }
        else if (moneyReceveid > 0)
        {
            int totalMoney = 10;
            totalMoney += moneyReceveid;
            Debug.Log("Money! " + totalMoney);
        }
        else
        {
            Debug.Log("No extra!");
        }





        bool activate;
        float trapRoll = Random.value;
        if (trapRoll >= 0.5f)
            activate = true;
        else
            activate = false;


        hall.SpawnTrap(statusValue[1], activate, 10);



        int change_stat = hall.GetStat_Changed();
        int receivedMoney = hall.GetMoney();



        if(change_stat > 0)
        {
            statusValue[1] = change_stat;
            Debug.Log("Trap Stat " + statusValue[1]);
        }
        else if(receivedMoney > 0)
        {
            int totalMoney = 10;
            totalMoney += receivedMoney;
            Debug.Log("Trap Money " + totalMoney);
        }
        else
        {
            Debug.Log("No trap");
        }

    }
}
