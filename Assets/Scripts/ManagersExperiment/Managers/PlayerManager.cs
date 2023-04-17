using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public List<TestPlayer> players = new List<TestPlayer>();

    private void Awake()
    {
        instance = this;
    }

    internal void AssignTurn(int currentPlayerTurn)
    {
        foreach (TestPlayer player in players)
        {
            player.myTurn = player.ID == currentPlayerTurn;
        }
    }

    public TestPlayer FindPlayerByID(int ID)
    {
        TestPlayer foundPlayer = null;

        foreach (TestPlayer player in players)
        {
            /*if (player.ID == currentPlayerTurn)
            {
                player.myTurn = true;
            }
            else
            {
                player.myTurn = false;
            }*/
            foundPlayer = player;
        }
        //TestPlayer player = players.Find(x => x.ID == currentPlayerTurn);
        //player.myTurn = true;
        return foundPlayer;
    }
}
