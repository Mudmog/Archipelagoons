using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AuctionManager : MonoBehaviour
{

    public TMP_Text pearlBet;
    public int pearlBetValue;
    public GameManager gm;
    public MenuManager mm;
      
    void Start()
    {
        pearlBetValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBetUpClick()
    {
        
        pearlBetValue += 1;
        CheckValidPearlAmount();
        pearlBet.SetText(pearlBetValue.ToString());
        Debug.Log("increment bet to "+ pearlBetValue);
    }

    public void OnBetDownClick()
    {
        
        pearlBetValue -= 1;
        CheckValidPearlAmount();
        pearlBet.SetText(pearlBetValue.ToString());
        Debug.Log("decrement bet to "+ pearlBetValue);
    }

    public void CheckValidPearlAmount()
    {
        //remember to also have it set so you cant bet more than your total pearls
        if (pearlBetValue <= 0)
        {
            pearlBetValue = 0;
        }
        else if (pearlBetValue >= gm.currentPlayer.getPearls()) {
            pearlBetValue = gm.currentPlayer.getPearls();
        }
    }

    public void onBetButtonClick() {
        mm.HandlePearlsUpdate(-pearlBetValue);
        gm.ChangeTurn(gm.getNextTurn(gm.currentPlayer));
        pearlBetValue = 0;
        pearlBet.SetText(pearlBetValue.ToString());   
    }
    

    // Start is called before the first frame update
}
