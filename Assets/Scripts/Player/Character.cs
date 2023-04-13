using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Character : MonoBehaviour
{
    HexCell currentCell; //The current cell that the ship is over

    public void updatePosition(HexCell cell) {
        currentCell = cell;
        //Debug.Log(currentCell.Position.ToString());
        transform.position = new Vector3(currentCell.Position.x, currentCell.WaterSurfaceY, currentCell.Position.z);
    }

}
