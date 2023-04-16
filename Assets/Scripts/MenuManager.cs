using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private GameManager gm;
    public TextMeshProUGUI pearlsText;
    public TextMeshProUGUI currentPlayerText;
    private Player _currentPlayer;
    Canvas theCanvas;
    // Start is called before the first frame update

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
         _currentPlayer = gm._currentPlayer;
        pearlsText.SetText(_currentPlayer.getPearls().ToString());
        currentPlayerText.SetText(_currentPlayer.ToString().Remove(8));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P)) {
            HandlePearlsUpdate(10);
        }
    }

    public void HandleTurnChange(Player player) {
        _currentPlayer = player;
        pearlsText.SetText(_currentPlayer.getPearls().ToString());
        currentPlayerText.SetText(_currentPlayer.ToString().Remove(8));
    }

    void HandlePearlsUpdate(int pearlChange) {
        _currentPlayer.changePearls(pearlChange);
        pearlsText.SetText(_currentPlayer.getPearls().ToString());
    }
}
