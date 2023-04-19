using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    HexCell currentCell; //The current cell that the ship is over
    Card card; //The card that represents the Unit

    void Start() {
    }
    public void setCell(HexCell cell) {
        currentCell = cell;
    }

    public void setCard(Card playerCard) {
        if (playerCard.name.Equals(this.name.Replace("(Clone)", ""))) {
            card = playerCard;
        }
        else {
            Debug.Log("Card name doesn't match unit");
        }
        
    }
    public Card getCard() {
        return card;
    }

    public void updatePosition(HexCell cell) {
        //Debug.Log(currentCell.Position.ToString());
        if (checkIsNeighbors(cell)) {
            currentCell = cell;
            transform.position = new Vector3(currentCell.Position.x, currentCell.WaterSurfaceY, currentCell.Position.z);
        }
    }

    private bool checkIsNeighbors(HexCell cell) {
        HexCell checkedCell = currentCell;
        for (int y = 0; y < card.movement; y++) {
            for (int x = 0; x < checkedCell.gettotalNeighbors(); x++) {
                if (cell == checkedCell.getNeighbor(x)) {
                    Debug.Log("That is a neighbor");
                    return true;
                }
                checkedCell = checkedCell.getNeighbor(y);
            }
            checkedCell = currentCell;
        }
        Debug.Log("That is not a neighbor");
        return false;
    }

}
