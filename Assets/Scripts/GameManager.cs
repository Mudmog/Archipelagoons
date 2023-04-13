using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public static event Action<GamePhase> OnGamePhaseChange;
    private GameState _currentState;
    private GamePhase _currentPhase;
    public HexMapEditor map;

    public HexGrid grid;

    public CharacterList characterlist;

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
    }
    void Start()
    {
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

    private void HandleStartUp() {
        if (Input.GetKeyUp(KeyCode.Q)) {
            UpdatePhase(GamePhase.UPKEEP);
            Debug.Log("Switched to Upkeep");
        }
    }
    private void HandleUpkeep() {
        if (Input.GetKeyUp(KeyCode.Q)) {
            UpdatePhase(GamePhase.BUILD);
            Debug.Log("Switched to Build");
        }
    }
    private void HandleBuild() {
        if (Input.GetKeyUp(KeyCode.Q)) {
            UpdatePhase(GamePhase.RECRUIT);
            Debug.Log("Switched to Recruit");
        }
    }
    private void HandleRecruit() {
        if (Input.GetKeyUp(KeyCode.Q)) {
            UpdatePhase(GamePhase.ARMY);
            Debug.Log("Switched to Army");
        }
    }
    private void HandleArmy() {
        if (Input.GetKey(KeyCode.Q)) {
            UpdatePhase(GamePhase.ROUNDEND);
            Debug.Log("Switched to EndRound");
        }
        if (Input.GetMouseButton(0))
		{
			HandleInput(grid, characterlist.characters[0]);
		}
    }
    private void HandleRoundEnd() {
        if (Input.GetKeyUp(KeyCode.Q)) {
            Debug.Log("Game Ended");
        }
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
}
