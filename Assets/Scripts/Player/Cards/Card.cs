using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Netcode;

[System.Serializable]
public class CardData {
    public string name, goon, rarity, ability;
    public int power, defense, movement;
}

[System.Serializable]
public class Card : MonoBehaviour
{
    public CardData data;
    public CardList cardList; 
    public TMP_Text nameText, goonText, rarityText, abilityText, powerText, defenseText, movementText;
    public Unit unit;
    // Start is called before the first frame update
    void Start()
    {
        cardList = GameObject.Find("EventSystem").GetComponent<CardList>();
        applyData();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void applyData() {
        for (int x =0; x < cardList.UnitCards.cardData.Length; x++) {
            if (cardList.UnitCards.cardData[x].name == null) {
                continue;
            }
            else if (cardList.UnitCards.cardData[x].name.Equals(this.name.Replace(" Card", ""))) {
                data.name = cardList.UnitCards.cardData[x].name;
                data.goon = cardList.UnitCards.cardData[x].goon;
                data.rarity = cardList.UnitCards.cardData[x].rarity;
                data.ability = cardList.UnitCards.cardData[x].ability;
                data.power = cardList.UnitCards.cardData[x].power;
                data.defense = cardList.UnitCards.cardData[x].defense;
                data.movement = cardList.UnitCards.cardData[x].movement;
                nameText.text = name;
                goonText.text = data.goon;
                defenseText.text = data.defense.ToString();
                powerText.text = data.power.ToString();
                movementText.text = data.movement.ToString();
                abilityText.text = data.ability;
            }
        }
    }

    public CardData getCardData() {
        return data;
    }
    public void setCardData(CardData cardData) {
        data = cardData;
        applyData();
    }


}
