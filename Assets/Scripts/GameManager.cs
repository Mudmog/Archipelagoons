using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public HexMapEditor map;

    public HexGrid grid;

    public CharacterList characterlist;

    // Start is called before the first frame update
    void Start()
    {
        map.Load();
        map.enabled = false;
    }

    // Update is called once per frame
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
}
