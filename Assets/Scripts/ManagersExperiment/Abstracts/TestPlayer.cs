using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestPlayer
{
    public int health, mana;
    public int ID;
    public bool myTurn;

    public TestPlayer(int health, int mana, int ID)
    {
        this.health = health;
        this.mana = mana;
        this.ID = ID;
    }
}
