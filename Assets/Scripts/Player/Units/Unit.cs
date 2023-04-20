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

    public void updatePosition(HexCell cell) {
        //Debug.Log(currentCell.Position.ToString());
        if (checkIsNeighbors(cell)) {
            currentCell = cell;
            transform.position = new Vector3(currentCell.Position.x, currentCell.WaterSurfaceY, currentCell.Position.z);
        }
    }

    private bool checkIsNeighbors(HexCell cell) {
        if (currentCell.coordinates.DistanceTo(cell.coordinates) <= card.movement) {
            return true;
        }
        Debug.Log("Unit can't move that far");
        return false;
    }

}
