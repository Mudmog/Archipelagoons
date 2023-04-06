using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameState _currentState;
    private GamePhase _currentPhase;
    public HexMapEditor map;

    public HexGrid grid;

    public CharacterList characterlist;

    enum GameState {
        NONE,
        LOADING, 
        RUNNING, 
        END, 
        RESTART 
    }

    enum GamePhase {

        STARTUP,
        UPKEEP, 
        BUILD, 
        RECRUIT,
        ARMY,
        ROUNDEND
    }

    void Start()
    {
        _currentState = GameState.LOADING;
        _currentPhase = GamePhase.STARTUP;
        map.Load();
        map.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
		{
			HandleInput(grid, characterlist.characters[0]);
		}
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

    void ChangeState(GameState state) {

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

    void ChangePhase(GamePhase phase) {
        _currentPhase = phase;

        switch(_currentPhase) {

            case GamePhase.STARTUP:
                //Should only be used at the beginning.
                //Make sure that everyone is connected.
                //Goes to upkeep when done.
                break;

            case GamePhase.UPKEEP:
                //each client simotaniously moves
                //make sure they are done before moving on
                break;
            
            case GamePhase.BUILD:
                //each client simotaniously moves
                //make sure they are done before moving on
                break;
            
            case GamePhase.RECRUIT:
                //basically auction phase
                //lots of waiting on players 
                //cool
                break;

            case GamePhase.ARMY:
                //turn based round
                //each player goes
                //goto roundend
                break;

            case GamePhase.ROUNDEND:
                //make sure everything is correct
                //and updated
                //decide if winner
                //if not goto next round
                //if so endgame
                break;
            
            default:
                break;
        }
    }

    void StartLoading() {
        
    }
}
