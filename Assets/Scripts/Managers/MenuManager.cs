using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private GameManager gm;
    public HandInteraction hi;
    public TextMeshProUGUI pearlsText, hammersText, ordersText;
    public TextMeshProUGUI currentPlayerText;
    public Button turnButton;
    private Player _currentPlayer;
    Canvas theCanvas;
    public TMP_Text HUDActivePlayer1;
    public TMP_Text HUDActivePlayer2;
    public GameObject RecruitUI;
    public GameObject AuctionUI;
    public GameObject mainUIOther;
    public GameObject mainUI;
    public GameObject P1Hand;
    public GameObject P2Hand;


    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _currentPlayer = gm._currentPlayer;
        currentPlayerText.SetText(_currentPlayer.ToString().Remove(8));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HandleTurnChange(Player player) {
        _currentPlayer = player;
        pearlsText.SetText(": " + _currentPlayer.getPearls().ToString());
        currentPlayerText.SetText(_currentPlayer.ToString().Remove(8));
        hammersText.SetText(_currentPlayer.getHammers().ToString()+ "/" + _currentPlayer.getMaxHammers().ToString());
        ordersText.SetText(_currentPlayer.getOrders().ToString() + "/" + _currentPlayer.getMaxOrders().ToString());
        if (_currentPlayer.ToString().Remove(8) is "Player 1")
        {
            P1Hand.SetActive(true);
            P2Hand.SetActive(false);
        }
        else
        {
            P2Hand.SetActive(true);
            P1Hand.SetActive(false);
        }

    }

    public void HandleRecruitMenuChange()
    {
        RecruitUI.SetActive(true);

    }

    public void HandleAuctionMenuChange()
    {
        RecruitUI.SetActive(false);
        mainUIOther.SetActive(false);
        AuctionUI.SetActive(true);
    }

    public void HandleArmyMenuChange()
    {
        AuctionUI.SetActive(false);
        mainUIOther.SetActive(true);
    }

    public void HandlePearlsUpdate(int pearlChange) {
        _currentPlayer.changePearls(pearlChange);
        pearlsText.SetText(": " + _currentPlayer.getPearls().ToString());
    }
    public void HandleHammersUpdate(int hammersChange) {
        _currentPlayer.changeHammers(hammersChange);
        hammersText.SetText(_currentPlayer.getHammers().ToString()+ "/" + _currentPlayer.getMaxHammers().ToString());
    }
    public void HandleOrdersUpdate(int ordersChange) {
        _currentPlayer.changeOrders(ordersChange);
        ordersText.SetText(_currentPlayer.getOrders().ToString() + "/" + _currentPlayer.getMaxOrders().ToString());
    }
    public void onTurnButtonClick() {
        gm.ChangeTurn(gm.getNextTurn(_currentPlayer));
    }

    public void onFishButtonClick()
    {
        hi.HandleAddCard(_currentPlayer,"Guppy Goon");
        gm.ChangeTurn(gm.getNextTurn(_currentPlayer));
    }

    public void onCrustaceanClick()
    {
        hi.HandleAddCard(_currentPlayer, "Stabby Crab");
        gm.ChangeTurn(gm.getNextTurn(_currentPlayer));
    }
    public void onMolluskButtonClick()
    {
        hi.HandleAddCard(_currentPlayer, "Hired Mussel");
        gm.ChangeTurn(gm.getNextTurn(_currentPlayer));
    }
}
