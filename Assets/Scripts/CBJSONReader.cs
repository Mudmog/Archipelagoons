using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CBJSONReader : MonoBehaviour
{
    public TextAsset jsonFile;
    public string CardName;
    public TMP_Text UnitName;
    public TMP_Text UnitType;
    public TMP_Text UnitDefense;
    public TMP_Text UnitPower;
    public TMP_Text UnitSpeed;
    public TMP_Text UnitText;



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
}
