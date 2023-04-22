using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    public Unit baseUnit;

    public List<Unit> units;

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

    public void placeUnit(HexCell cell, Player player, string unitName, Card card)
    {

        
        if (unitName is "Guppy Goon"){   
            units.Add(Instantiate(guppygoon, new Vector3(cell.Position.x, cell.WaterSurfaceY, cell.Position.z), Quaternion.identity)); 
            units[units.Count - 1].transform.parent = player.transform;
            units[units.Count - 1].setCell(cell);
            units[units.Count - 1].setCard(card);
        }
        if (unitName is "Stabby Crab"){   
            units.Add(Instantiate(stabbycrab, new Vector3(cell.Position.x, cell.WaterSurfaceY, cell.Position.z), Quaternion.identity)); 
            units[units.Count - 1].transform.parent = player.transform;
            units[units.Count - 1].setCell(cell);
            units[units.Count - 1].setCard(card);
        }
        if (unitName is "Hired Mussel"){   
            units.Add(Instantiate(guppygoon, new Vector3(cell.Position.x, cell.WaterSurfaceY, cell.Position.z), Quaternion.identity)); 
            units[units.Count - 1].transform.parent = player.transform;
            units[units.Count - 1].setCell(cell);
            units[units.Count - 1].setCard(card);
        }
    }
    public void addToHand(Unit unit) {
        units.Add(unit);
    }

    public List<Unit> getUnitList() {
        return units;
    }

    public void setUnitList(List<Unit> newUnits) {
        units = newUnits;
    }

}
