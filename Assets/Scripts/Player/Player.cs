using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : MonoBehaviour
{
    private int handsize;
    private int pearls;
    private int pearls_pt;
    private int pearl_range;
    private int hammers;
    private int maxHammers;
    private int orders;
    private int maxOrders;
    public UnitList army;
    private int victory_points; 
    private int islands_controlled;
    private int total_builds;
    private int reef_round_count;
    private Player reef_lord;
    private CompassMark compass_mark;

    public void changePearls(int pearlAmount) {
        pearls += pearlAmount;
    }
    public int getPearls() {
        return pearls;
    }

    public void changeHammers(int hammerAmount) {
        hammers += hammerAmount;
    }
    public int getHammers() {
        return hammers;
    }
    public void resetHammers() {
        hammers = maxHammers;
    }
    public void changeMaxHammers(int hammerAmount) {
        maxHammers += hammerAmount;
    }
    public int getMaxHammers() {
        return maxHammers;
    }
    public void changeOrders(int ordersAmount) {
        orders += ordersAmount;
    }
    public int getOrders() {
        return orders;
    }
    public void resetOrders() {
        orders = maxOrders;
    }
    public void changeMaxOrders(int orderAmount) {
        maxOrders += orderAmount;
    }
    public int getMaxOrders() {
        return maxOrders;
    }

    public Unit getArmyUnit(Unit unit) {
        for (int x = 0; x < army.getUnitList().Count; x++) {
            if(unit == army.getUnitList()[x]) {
                return army.getUnitList()[x];
            }
        }
        Debug.Log("Selected Unit not Found");
        return unit;
    }
    public UnitList getUnitList() {
        return army;
    }

    public Card getUnitCard(Unit unit) {
        for (int x = 0; x < army.getUnitList().Count; x++) {
            if(unit == army.getUnitList()[x]) {
                return army.getUnitList()[x].getCard();
            }
        }
        Debug.Log("Selected Card not Found");
        return null;
    }

    public void assignUnits(CardList listOfCards) {
        string tempName = "";
        for (int x = 0; x < army.units.Count; x++) {
            for (int y = 0; y < listOfCards.UnitCards.cardData.Length; y++) {
                tempName = army.units[x].name.Replace("(Clone)", "");
                if (tempName.Equals(listOfCards.UnitCards.cardData[y])) {
                    army.units[x].setCard(listOfCards.UnitCards.cardData[y]);
                }
            }
        }
    }
}
