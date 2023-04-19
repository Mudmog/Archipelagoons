using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CBJSONReader : MonoBehaviour
{

    public TextAsset json;



    //public TextAsset jsonFile;
    public string CardName;
    public TMP_Text UnitName;
    public TMP_Text UnitGoon;
    public TMP_Text UnitDefense;
    public TMP_Text UnitPower;
    public TMP_Text UnitMovement;
    public TMP_Text UnitAbility;


    [System.Serializable]
    public class createUnitCardsList
    {
        public Card[] cards;

    }

    public createUnitCardsList UnitCards = new createUnitCardsList();
    // Start is called before the first frame update
    void Start()
    {
        UnitCards = JsonUtility.FromJson<createUnitCardsList>(json.text);
        //Debug.Log("successfull");

        //Debug.Log(UnitCards.cards[1].name);    gets stabby crab name
        //Debug.Log(UnitCards.cards.Length);
        int TotalCards = UnitCards.cards.Length;

        Debug.Log(TotalCards);
        for (int i = 0; i == TotalCards; ++i)
        { 
            if(UnitCards.cards[i].name == CardName)
            {
                Debug.Log("Found card data: Card name is " + UnitCards.cards[i].name);
                UnitName.text = UnitCards.cards[i].name;
                UnitGoon.text = UnitCards.cards[i].goon;
                UnitDefense.text = ""+UnitCards.cards[i].defense;
                UnitPower.text = "" + UnitCards.cards[i].power;
                UnitMovement.text = "" + UnitCards.cards[i].movement;
                UnitAbility.text = UnitCards.cards[i].ability;
            }
            else
                Debug.Log("card" +CardName+ "not found");
        }


    }

    /*

    void Start()
    {
        CardsArray cardsInJSON = JsonUtility.FromJson<CardsArray>(jsonFile.text);

        foreach (CardData card in cardsInJSON.testing)
        {
            if (card.name == CardName)
            {
                Debug.Log("Found card data: Card name is " + card.name);
                UnitName.text = card.name;
                UnitType.text = card.goon;
                UnitDefense.text = card.defense;
                UnitPower.text = card.power;
                UnitSpeed.text = card.movement;
                UnitText.text = card.cardAbility;

            }
            else
                Debug.Log("card not found");
        }
       

    }
    */
}
