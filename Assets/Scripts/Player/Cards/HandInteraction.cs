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


    
    GameObject selectedUnitCard;
    public String cardName;
    public GameObject gm;



    void Start()
    {
        gm = GameObject.Find("Game Manager");
    }

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

            
            if (card is "Guppy Goon")
                Instantiate(guppyGoon, new Vector3(Player1Hand.position.x-330+(150*Player1HandSize), Player1Hand.position.y-190, Player1Hand.position.z), Quaternion.identity, Player1Hand);
            if (card is "Stabby Crab")
                Instantiate(stabbyCrab, new Vector3(Player1Hand.position.x - 330 + (150 * Player1HandSize), Player1Hand.position.y - 190, Player1Hand.position.z), Quaternion.identity, Player1Hand);
            if (card is "Hired Mussel")
                Instantiate(hiredMussel, new Vector3(Player1Hand.position.x - 330 + (150 * Player1HandSize), Player1Hand.position.y - 190, Player1Hand.position.z), Quaternion.identity, Player1Hand);
        }
        if (player.name is "Player 2") {
            Player2HandSize++;
            Debug.Log(card + " should be given to " + player.name);
            if (card is "Guppy Goon")
                Instantiate(guppyGoon, new Vector3(Player2Hand.position.x - 330 + (150 * Player2HandSize), Player2Hand.position.y - 190, Player2Hand.position.z), Quaternion.identity, Player2Hand);
            if (card is "Stabby Crab")
                Instantiate(stabbyCrab, new Vector3(Player2Hand.position.x - 330 + (150 * Player2HandSize), Player2Hand.position.y - 190, Player2Hand.position.z), Quaternion.identity, Player2Hand);
            if (card is "Hired Mussel")
                Instantiate(hiredMussel, new Vector3(Player2Hand.position.x - 330 + (150 * Player2HandSize), Player2Hand.position.y - 190, Player2Hand.position.z), Quaternion.identity, Player2Hand);
        }

    }

    public void HandleSelectCard()
    {


        gm.GetComponent<GameManager>().SetSelectedCard(cardName);
        
        //when card button is clicked, selected unit card = respective unit 
        //then reference handlebuildunit
    }


    public void HandleBuildUnit(String UnitName)
    {

       
        //instantiate the selected unit on that hex cell
        //allow the player to click a hex cell
        //also instantiates unit card to the first open army field slot
    }

    public void HandleDiscardCard()
    {
        //card is removed from play and added to the list of discarded cards
        //decrement player hand size
        //rearrange card positions
    }




}
