using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI pearlsText, hammersText, ordersText;
    public TextMeshProUGUI currentPlayerText;
    public Button turnButton;
    private Player _currentPlayer;
    Canvas theCanvas;
    public TMP_Text HUDActivePlayer1;
    public TMP_Text HUDActivePlayer2;
    public GameObject P1UI;
    public GameObject P2UI;
    public GameObject RecruitUI;
    public GameObject AuctionUI;
    // Start is called before the first frame update

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
}
