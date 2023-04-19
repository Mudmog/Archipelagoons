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
    public GameObject mainUI;
    public Canvas P1Hand;


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
        hammersText.SetText(_currentPlayer.getHammers().ToString()+ "/7");
        ordersText.SetText(_currentPlayer.getOrders().ToString() + "/5");
        //P2UI.SetActive(false);
        //P1UI.SetActive(true);
    }

    public void HandleRecruitMenuChange()
    {
        RecruitUI.SetActive(true);

    }

    public void HandleAuctionMenuChange()
    {
        RecruitUI.SetActive(false);
        mainUI.SetActive(false);
        AuctionUI.SetActive(true);
    }

    public void HandleArmyMenuChange()
    {
        AuctionUI.SetActive(false);
        mainUI.SetActive(true);
    }

    void HandlePearlsUpdate(int pearlChange) {
        _currentPlayer.changePearls(pearlChange);
        pearlsText.SetText(": " + _currentPlayer.getPearls().ToString());
    }
    void HandleHammersUpdate(int hammersChange) {
        _currentPlayer.changePearls(hammersChange);
        hammersText.SetText(_currentPlayer.getHammers().ToString() + "/5");
    }
    void HandleOrdersUpdate(int ordersChange) {
        _currentPlayer.changePearls(ordersChange);
        ordersText.SetText(_currentPlayer.getOrders().ToString() + "/5");
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
