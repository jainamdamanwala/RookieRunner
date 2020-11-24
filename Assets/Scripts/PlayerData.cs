using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int coins;
    public int gear;
    public float HighScore;

    public PlayerData(PlayerController player)
    {
        coins = player.coinCounter;
        gear = player.gearCounter;
        HighScore = player.HighScore;
    }
}
