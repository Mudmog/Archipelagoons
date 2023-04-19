using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    public Unit baseUnit;

    public Unit[] units;

    // Start is called before the first frame update
    void Start() {
    }
    public void placeFirstUnit(HexCell cell, Player player) {
        units[0] = Instantiate(baseUnit, new Vector3(cell.Position.x, cell.WaterSurfaceY, cell.Position.z), Quaternion.identity);
        units[0].transform.parent = player.transform; 
        units[0].setCell(cell);
    }

    public Unit[] getUnitList() {
        return units;
    }

    public void setUnitList(Unit[] newUnits) {
        units = newUnits;
    }

}
