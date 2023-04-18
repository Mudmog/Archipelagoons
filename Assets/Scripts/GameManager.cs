using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private MenuManager mm;
    public static event Action<GamePhase> OnGamePhaseChange;
    private GameState _currentState;
    private GamePhase _currentPhase;
    private PlayerTurn _currentTurn;
    public HexMapEditor map;

    public HexGrid grid;
    public Player[] players;
    public Player _currentPlayer;
    [SerializeField]
    Unit selectedUnit;

    //chris does hud stuff
    public TMP_Text HUDActivePlayer1;
    public TMP_Text HUDActivePlayer2;
    public GameObject P1UI;
    public GameObject P2UI;
    public GameObject RecruitUI;
    public GameObject AuctionUI;

    public enum PlayerTurn {
        PLAYER1,
        PLAYER2
    }

    public enum GameState {
        NONE,
        LOADING, 
        RUNNING, 
        END, 
        RESTART 
    }

    public enum GamePhase {

        STARTUP,
        UPKEEP, 
        BUILD, 
        RECRUIT,
        ARMY,
        ROUNDEND
    }

    void Awake() {
        Instance = this;
        _currentPlayer = players[0];
    }
    void Start()
    {
        Debug.Log(players.Length);
        mm = GameObject.Find("GameUI").GetComponent<MenuManager>();
        UpdateState(GameState.LOADING);
        map.Load();
        map.enabled = false;
        UpdatePhase(GamePhase.STARTUP);
        placeBeginnerUnit(grid);
    }
    void Update() {
        UpdatePhase(_currentPhase);
    }
    void UpdateState(GameState state) {

        _currentState = state;
        switch(_currentState) {

            case GameState.NONE: 
                //Will be used for something haven't actually figured that out yet
                break;
            
            case GameState.LOADING:
                //For when players need to load and stuff
                break;
            
            case GameState.RUNNING: 
                //game is running
                break;
            
            case GameState.END:
                break;

            case GameState.RESTART:
                break;
            
            default:
                break;

        }
    }

    void UpdatePhase(GamePhase phase) {
        _currentPhase = phase;

        switch(_currentPhase) {

            case GamePhase.STARTUP:
                HandleStartUp();
                //Should only be used at the beginning.
                //Make sure that everyone is connected.
                //Goes to upkeep when done.
                break;

            case GamePhase.UPKEEP:
                HandleUpkeep();
                //each client simotaniously moves
                //make sure they are done before moving on
                break;
            
            case GamePhase.BUILD:
                HandleBuild();
                //each client simotaniously moves
                //make sure they are done before moving on
                break;
            
            case GamePhase.RECRUIT:
                HandleRecruit();
                //basically auction phase
                //lots of waiting on players 
                //cool
                break;

            case GamePhase.ARMY:
                HandleArmy();
                //turn based round
                //each player goes
                //goto roundend
                break;

            case GamePhase.ROUNDEND:
                HandleRoundEnd();
                //make sure everything is correct
                //and updated
                //decide if winner
                //if not goto next round
                //if so endgame
                break;
            
            default:
                break;
        }
        OnGamePhaseChange?.Invoke(phase);
    }
    public void ChangeTurn(PlayerTurn newTurn) {
        _currentTurn = newTurn;

        switch(newTurn) {
            case PlayerTurn.PLAYER1:
                Debug.Log("Player 1 turn");
                HUDActivePlayer1.text = "Player 1";
                P2UI.SetActive(false);
                P1UI.SetActive(true);
                _currentPlayer = players[0];
                mm.HandleTurnChange(players[0]);
                HandlePhaseChange();
                break;

            //note to self, remember to remove comments below
            //they switch between player 1 UI view and player 2 ui view
            //also update player2 ui to be an identical copy of player 1 ui but
            //with green felt material replaced with red felt and vice versa
            case PlayerTurn.PLAYER2:
                Debug.Log("Player 2 turn");
                //also remove the activeplayer1 line below
                HUDActivePlayer1.text = "Player 2";
                //HUDActivePlayer2.text = "Player 2";
                //P1UI.SetActive(false);
                //P2UI.SetActive(true);
                _currentPlayer = players[1];
                mm.HandleTurnChange(players[1]);
                break;
            
            default:
                break;
        }

    }

    private void HandleStartUp() {
    }
    private void HandleUpkeep() {
    }
    private void HandleBuild() {
    }
    private void HandleRecruit() {
        RecruitUI.SetActive(true);

    }
    private void HandleArmy() {
        RecruitUI.SetActive(false);
        if (Input.GetMouseButtonUp(0))
		{
            if (selectedUnit != null) {
                HandleUnitMovement(grid, selectedUnit);
            }
            else {
                HandleUnitSelection();
            }
			

		}
    }
    private void HandleRoundEnd() {
    }
    public void HandlePhaseChange() {
        switch(_currentPhase) {

            case GamePhase.STARTUP:
                UpdatePhase(GamePhase.UPKEEP);
                break;

            case GamePhase.UPKEEP:
                 UpdatePhase(GamePhase.BUILD);
                break;
            
            case GamePhase.BUILD:
                 UpdatePhase(GamePhase.RECRUIT);
                break;
            
            case GamePhase.RECRUIT:
                 UpdatePhase(GamePhase.ARMY);
                break;

            case GamePhase.ARMY:
                 UpdatePhase(GamePhase.ROUNDEND);
                break;

            case GamePhase.ROUNDEND:
                 UpdatePhase(GamePhase.UPKEEP);
                break;
            
            default:
                break;
        }
        Debug.Log("Phase Updated From: " + _currentPhase.ToString());
    }
    void StartLoading() {
        
    }

    public void placeBeginnerUnit(HexGrid hexgrid) {
        players[0].getUnitList().placeFirstUnit(hexgrid.GetCell(new Vector3(69, 9, 87)), players[0]);
        players[1].getUnitList().placeFirstUnit(hexgrid.GetCell(new Vector3(277, 8, 89)), players[1]);
    }

    public void HandleUnitMovement(HexGrid hexGrid, Unit unit)
	{
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit) && hexGrid.GetCell(hit.point).IsUnderwater)
		{
			unit.updatePosition(hexGrid.GetCell(hit.point));
            selectedUnit = null;
		}
	}

    public void HandleUnitSelection() {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit) && hit.transform.gameObject.tag.Equals("Unit"))
		{
            if (hit.transform.gameObject.GetComponentInParent<Player>() != _currentPlayer) {
                Debug.Log("Not Your Unit");
            }
            else {
                selectedUnit = hit.transform.gameObject.GetComponentInParent<Unit>();
                Debug.Log("Selected Unit: " + selectedUnit.ToString());
            }
		}
    }
    
    public PlayerTurn getNextTurn(Player currentPlayer) {
        if (currentPlayer == players[0]) {
            return PlayerTurn.PLAYER2; 
        }
        else if (currentPlayer == players[1]) {
            return PlayerTurn.PLAYER1;
        }
        Debug.Log("Error getting next player");
        return PlayerTurn.PLAYER1;
    }
}
