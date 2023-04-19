using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HandInteraction : MonoBehaviour
{

    private int Player1HandSize = 0;
    private int Player2HandSize = 0;
    public Transform Player1Hand;
    public Transform Player2Hand;
    public GameObject guppyGoon;
    public GameObject stabbyCrab;
    public GameObject hiredMussel;


    //chris is responsible for the below code that adds card to player hands
    //if this freaks something you have permission to yell at him
    public void HandleAddCard(Player player, String card)
    {
        //track each players amount of cards in hand, multiply by (n-1)*.75 to get X position to instantiate the prefab at
        if (player.name is "Player 1")
        {
            Player1HandSize++;
            Debug.Log(card + " should be given to " + player.name);
            Debug.Log(player.name+" should have "+Player1HandSize+" cards in hand");
            //instantiate a card hand prefab as a child of playerhand when given card name
            //position changed relative to how many cards are in hand
            //currently instantiates just guppy goon but should be dependant on String card input
            if(card is "Guppy Goon")
                Instantiate(guppyGoon, Player1Hand);
            if (card is "Stabby Crab")
                Instantiate(stabbyCrab, Player1Hand);
            if (card is "Hired Mussel")
                Instantiate(hiredMussel, Player1Hand);
        }
        if (player.name is "Player 2") {
            Player2HandSize++;
            Debug.Log(card + " should be given to " + player.name);
            if (card is "Guppy Goon")
                Instantiate(guppyGoon, Player2Hand);
            if (card is "Stabby Crab")
                Instantiate(stabbyCrab, Player2Hand);
            if (card is "Hired Mussel")
                Instantiate(hiredMussel, Player2Hand);

        }
        
    }

    public void HandleSelectCard()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
