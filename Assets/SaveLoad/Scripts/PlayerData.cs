using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int OpendLvls;
    public float Volume;
    //добавить разрешение

    public PlayerData(float Volume)
    {
        this.Volume = Volume;
    }
}
