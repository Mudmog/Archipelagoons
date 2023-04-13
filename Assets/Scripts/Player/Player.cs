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
    private Character[] army;
    private int victory_points; 
    private int islands_controlled;
    private int total_builds;
    private int reef_round_count;
    private Player reef_lord;
    private CompassMark compass_mark;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changePearls(int pearlAmount) {
        pearls += pearlAmount;
    }
    public int getPearls() {
        return pearls;
    }
}
