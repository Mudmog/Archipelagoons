using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    HexCell currentCell; //The current cell that the ship is over
    Card card; //The card that represents the Unit

    public void updatePosition(HexCell cell) {
        currentCell = cell;
        //Debug.Log(currentCell.Position.ToString());
        transform.position = new Vector3(currentCell.Position.x, currentCell.WaterSurfaceY, currentCell.Position.z);
    }

}
