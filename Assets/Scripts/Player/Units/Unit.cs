using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

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

    public void updatePosition(HexCell cell, MenuManager mm) {
        //Debug.Log(currentCell.Position.ToString());
        if (checkWithinDistance(cell)) {
            currentCell = cell;
            transform.position = new Vector3(currentCell.Position.x, currentCell.WaterSurfaceY, currentCell.Position.z);
            mm.HandleOrdersUpdate(-1);
        }
    }

    public bool checkWithinDistance(HexCell cell) {
        Debug.Log(currentCell);
        if (currentCell.coordinates.DistanceTo(cell.coordinates) <= card.movement) {
            return true;
        }
        Debug.Log("Unit can't move that far");
        return false;
    }
        public bool checkIsNeighbors(HexCell cell) {
        if (currentCell.coordinates.DistanceTo(cell.coordinates) == 1) {
            return true;
        }
        Debug.Log("Unit can't move that far");
        return false;
    }
    public bool checkIsNeighbors(HexCell cell, Player player) {
        if (currentCell.coordinates.DistanceTo(cell.coordinates) == 1) {
            return true;
        }
        Debug.Log("Unit can't move that far");
        return false;
    }

    public HexCell getCurrentCell() {
        return currentCell;
    }

}
