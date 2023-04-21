using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    public Unit baseUnit;

    public Unit[] units;

    public int unitCount;

    public Unit guppygoon;
    public Unit stabbycrab;
    public Unit hiredmussel;


    // Start is called before the first frame update
    void Start() {

        unitCount = 0;
    }
    public void placeFirstUnit(HexCell cell, Player player) {
        units[0] = Instantiate(baseUnit, new Vector3(cell.Position.x, cell.WaterSurfaceY, cell.Position.z), Quaternion.identity);
        units[0].transform.parent = player.transform; 
        units[0].setCell(cell);
    }

    public void placeUnit(HexCell cell, Player player, string unitName)
    {

        
        if (unitName is "Guppy Goon"){
            
            units[unitCount] = Instantiate(guppygoon, new Vector3(cell.Position.x, cell.WaterSurfaceY, cell.Position.z), Quaternion.identity);
            units[unitCount].transform.parent = player.transform;
            units[unitCount].setCell(cell);
            
        }
    }

    public Unit[] getUnitList() {
        return units;
    }

    public void setUnitList(Unit[] newUnits) {
        units = newUnits;
    }

}
