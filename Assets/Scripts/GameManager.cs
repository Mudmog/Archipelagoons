using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public CharacterList characterlist;

    public Player[] players;
    public Player _currentPlayer;

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
        mm = GameObject.Find("GameUI").GetComponent<MenuManager>();
        UpdateState(GameState.LOADING);
        map.Load();
        map.enabled = false;
        UpdatePhase(GamePhase.STARTUP);
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
                _currentPlayer = players[0];
                mm.HandleTurnChange(players[0]);
                HandlePhaseChange();
                break;

            case PlayerTurn.PLAYER2:
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
    }
    private void HandleArmy() {
        if (Input.GetMouseButton(0))
		{
			HandleInput(grid, characterlist.characters[0]);
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

    public void HandleInput(HexGrid hexGrid, Character character)
	{
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit) && hexGrid.GetCell(hit.point).IsUnderwater)
		{
			character.updatePosition(hexGrid.GetCell(hit.point));
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
