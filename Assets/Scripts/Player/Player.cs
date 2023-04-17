using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Player : MonoBehaviour
{
    private int[] hand;
    private int pearls;
    private int pearls_pt;
    private int pearl_range;
    private int hammers;
    private int orders;
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
    public void changeOrders(int ordersAmount) {
        orders += ordersAmount;
    }
    public int getOrders() {
        return orders;
    }

    public Unit getArmyUnit(Unit unit) {
        for (int x = 0; x < army.getUnitList().Length; x++) {
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
}
