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
    Card card;


    [System.Serializable]
    public class createUnitCardsList
    {
        public Card[] cards;

    }

    public void setCardStats(Card card)
    {

                Debug.Log("Found card data: Card name is " + card.name);
                UnitName.text = card.name;
                UnitGoon.text = card.goon;
                UnitDefense.text = ""+card.defense;
                UnitPower.text = ""+card.power;
                UnitMovement.text = ""+card.movement;
                UnitAbility.text = card.ability;

        
    }

    public createUnitCardsList UnitCards = new createUnitCardsList();
    // Start is called before the first frame update

    //
    void Start()
    {
        UnitCards = JsonUtility.FromJson<createUnitCardsList>(json.text);


        //Debug.Log("successfull");

        Debug.Log(CardName);    //gets card name
        
        
        int TotalCards = UnitCards.cards.Length;

        
        for (int i = 0; i < TotalCards; ++i)
        {
            //Debug.Log(i);
            if(UnitCards.cards[i].name == CardName)
            {
                setCardStats(UnitCards.cards[i]);
                Debug.Log("card " + CardName + " set to the stats of " +UnitCards.cards[i].name);
            }
            //else
                //Debug.Log("card " +CardName+ " not found");
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
