using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;

//Code referenced from https://catlikecoding.com/unity/tutorials/hex-map/part-1/

public class HexMapEditor : MonoBehaviour
{

	public HexGrid hexGrid;

	int activeElevation;
	int activeWaterLevel;
	int activeUrbanLevel;
	int activePlantLevel;

	int activeTerrainTypeIndex;

	bool applyElevation = true;
	bool applyWaterLevel = true;
	bool applyUrbanLevel;
	bool applyPlantLevel;

	int brushSize;


	void Update()
	{
		if (Input.GetMouseButton(0)) //&& !EventSystem.current.IsPointerOverGameObject())
		{
			HandleInput();
		}
	}

	void HandleInput()
	{
		Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(inputRay, out hit))
		{
			EditCells(hexGrid.GetCell(hit.point));
		}
	}
	public void SetBrushSize(float size)
	{
		brushSize = (int)size;
	}
	void EditCells(HexCell center)
	{
		int centerX = center.coordinates.X;
		int centerZ = center.coordinates.Z;

		for (int r = 0, z = centerZ - brushSize; z <= centerZ; z++, r++)
		{
			for (int x = centerX - r; x <= centerX + brushSize; x++)
			{
				EditCell(hexGrid.GetCell(new HexCoordinates(x, z)));
			}
		}
		for (int r = 0, z = centerZ + brushSize; z > centerZ; z--, r++)
		{
			for (int x = centerX - brushSize; x <= centerX + r; x++)
			{
				EditCell(hexGrid.GetCell(new HexCoordinates(x, z)));
			}
		}
	}
	void EditCell(HexCell cell)
	{
		if (cell) {
			if (activeTerrainTypeIndex >= 0)
			{
				cell.TerrainTypeIndex = activeTerrainTypeIndex;
			}
			if (applyElevation)
			{
				cell.Elevation = activeElevation;
			}
			if (applyWaterLevel)
			{
				cell.WaterLevel = activeWaterLevel;
			}
			if (applyUrbanLevel)
			{
				cell.UrbanLevel = activeUrbanLevel;
			}
			if (applyPlantLevel)
			{
				cell.PlantLevel = activePlantLevel;
			}
		}

	}

	public void SetElevation (float elevation)
    {
		activeElevation = (int)elevation;
    }

	public void SetApplyElevation(bool toggle)
	{
		applyElevation = toggle;
	}

	public void SetApplyWaterLevel(bool toggle)
	{
		applyWaterLevel = toggle;
	}

	public void SetWaterLevel(float level)
	{
		activeWaterLevel = (int)level;
	}
	public void SetApplyUrbanLevel(bool toggle)
	{
		applyUrbanLevel = toggle;
	}

	public void SetUrbanLevel(float level)
	{
		activeUrbanLevel = (int)level;
	}
	public void SetApplyPlantLevel(bool toggle)
	{
		applyPlantLevel = toggle;
	}

	public void SetPlantLevel(float level)
	{
		activePlantLevel = (int)level;
	}
	public void SetTerrainTypeIndex(int index)
	{
		activeTerrainTypeIndex = index;
	}
	public void Save()
	{
		string path = Path.Combine("../archipelagoons/Assets/Maps", "test.map");
		using (
			BinaryWriter writer =
				new BinaryWriter(File.Open(path, FileMode.Create))
		)
		{
			writer.Write(0);
			hexGrid.Save(writer);
		}
	}

	public void Load()
	{
		string path = Path.Combine("../archipelagoons/Assets/Maps", "test.map");
		using (
			BinaryReader reader =
				new BinaryReader(File.OpenRead(path))
		)
		{
			int header = reader.ReadInt32();
			if (header == 0)
			{
				hexGrid.Load(reader);
			}
			else
			{
				Debug.LogWarning("Unknown map format " + header);
			}
		}
	}

}
