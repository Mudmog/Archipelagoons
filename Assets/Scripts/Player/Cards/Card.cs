using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class CardData {
    public string name, goon, rarity, ability;
    public int power, defense, movement;

    public string cardName {
        get {
            return name;
        }
        set {
            name = value;
        }
    }
    public string cardGoon {
        get {
            return goon;
        }
        set {
            goon = value;
        }
    }
    public string cardRarity {
        get {
            return rarity;
        }
        set {
            rarity = value;
        }
    }
    public string cardAbility {
        get {
            return ability;
        }
        set {
            ability = value;
        }
    }
    public int cardPower {
        get {
            return power;
        }
        set {
            power = value;
        }
    }
    public int cardDefense {
        get {
            return defense;
        }
        set {
            defense = value;
        }
    }
    public int cardMovement {
        get {
            return movement;
        }
        set {
            movement = value;
        }
    }
}

public class Card : MonoBehaviour
{
    [SerializeField]
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
            if (cardList.UnitCards.cardData[x].cardName == null) {
                continue;
            }
            else if (cardList.UnitCards.cardData[x].cardName.Equals(this.name.Replace(" Card", ""))) {
                data.cardName = cardList.UnitCards.cardData[x].cardName;
                data.cardGoon = cardList.UnitCards.cardData[x].cardGoon;
                data.cardRarity = cardList.UnitCards.cardData[x].cardRarity;
                data.cardAbility = cardList.UnitCards.cardData[x].cardAbility;
                data.cardPower = cardList.UnitCards.cardData[x].cardPower;
                data.cardDefense = cardList.UnitCards.cardData[x].cardDefense;
                data.cardMovement = cardList.UnitCards.cardData[x].cardMovement;
                nameText.text = data.cardName;
                goonText.text = data.cardGoon;
                defenseText.text = data.cardDefense.ToString();
                powerText.text = data.cardPower.ToString();
                movementText.text = data.cardMovement.ToString();
                abilityText.text = data.cardAbility;
                Debug.Log(data.cardName + " and it's movement: " + data.cardMovement);
            }
        }
    }
    public void applyData(CardData cardData) {
        data.cardName = cardData.cardName;
        data.cardGoon = cardData.cardGoon;
        data.cardRarity = cardData.cardRarity;
        data.cardAbility = cardData.cardAbility;
        data.cardPower = cardData.cardPower;
        data.cardDefense = cardData.cardDefense;
        data.cardMovement = cardData.cardMovement;
        Debug.Log(data.cardName + " and it's power: " + data.cardPower);
    }
    

    public CardData getCardData() {
        return data;
    }
    public void setCardData(CardData cardData) {
        data = cardData;
        applyData(cardData);
    }


}
