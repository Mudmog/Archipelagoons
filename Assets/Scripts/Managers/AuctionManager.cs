using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuctionManager : MonoBehaviour
{

    public TMP_Text pearlBet;
    public int pearlBetValue = 0;
    

    public void OnBetUpClick()
    {
        
        pearlBetValue += 1;
        CheckValidPearlAmount();
        pearlBet.SetText(""+pearlBetValue);
        Debug.Log("increment bet to "+pearlBetValue);
    }

    public void OnBetDownClick()
    {
        
        pearlBetValue -= 1;
        CheckValidPearlAmount();
        pearlBet.SetText("" + pearlBetValue);
        Debug.Log("decrement bet to "+pearlBetValue);
    }

    public void CheckValidPearlAmount()
    {
        //remember to also have it set so you cant bet more than your total pearls
        if (pearlBetValue <= 0)
        {
            pearlBetValue = 0;
        }
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
