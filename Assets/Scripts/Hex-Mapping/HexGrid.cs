
using UnityEngine;
using UnityEngine.UI;
using System.IO;


//Code referenced from https://catlikecoding.com/unity/tutorials/hex-map/part-1/

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexGrid : MonoBehaviour
{
	public HexGridChunk chunkPrefab;

	HexGridChunk[] chunks;

	int cellCountX, cellCountZ;

	public HexCell cellPrefab;

	HexCell[] cells;

	public Text cellLabelPrefab;

	public Texture2D noiseSource;

	public int chunkCountX = 4, chunkCountZ = 3;

	public int seed;

	public Color[] colors;


	void Awake()
	{
		HexMetrics.noiseSource = noiseSource;
		HexMetrics.InitializeHashGrid(seed);
		HexMetrics.colors = colors;


		cellCountX = chunkCountX * HexMetrics.chunkSizeX;
		cellCountZ = chunkCountZ * HexMetrics.chunkSizeZ;

		CreateChunks();
		CreateCells();



	}

	void CreateChunks()
	{
		chunks = new HexGridChunk[chunkCountX * chunkCountZ];

		for (int z = 0, i = 0; z < chunkCountZ; z++)
		{
			for (int x = 0; x < chunkCountX; x++)
			{
				HexGridChunk chunk = chunks[i++] = Instantiate(chunkPrefab);
				chunk.transform.SetParent(transform);
			}
		}
	}

	void CreateCells()
    {
		cells = new HexCell[cellCountZ * cellCountX];

		for (int z = 0, i = 0; z < cellCountZ; z++)
		{
			for (int x = 0; x < cellCountX; x++)
			{
				CreateCell(x, z, i++);
			}
		}
	}

    private void OnEnable()
    {
		if (!HexMetrics.noiseSource)
		{
			HexMetrics.noiseSource = noiseSource;
			HexMetrics.InitializeHashGrid(seed);
			HexMetrics.colors = colors;
		}
	}

    public HexCell GetCell(Vector3 position)
	{
		position = transform.InverseTransformPoint(position);
		HexCoordinates coordinates = HexCoordinates.FromPosition(position);
		int index = coordinates.X + coordinates.Z * cellCountX + coordinates.Z / 2;
		return cells[index];
	}

	public HexCell GetCell(HexCoordinates coordinates)
	{
		int z = coordinates.Z;
		if (z < 0 || z >= cellCountZ)
		{
			return null;
		}
		int x = coordinates.X + z / 2;
		if (x < 0 || x >= cellCountX)
		{
			return null;
		}
		return cells[x + z * cellCountX];
	}

	void CreateCell(int x, int z, int i)
	{
		Vector3 position;

		position.x = x * (HexMetrics.innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics.outerRadius * 1.5f);
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics.innerRadius * 2f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.localPosition = position;
		cell.coordinates = HexCoordinates.FromOffsetCoordinates(x, z);

		if (x > 0)
        {
			cell.SetNeighbor(HexDirection.W, cells[i - 1]);
        }
		if (z > 0)
		{
			if ((z & 1) == 0)
			{
				cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX]);
				if (x > 0)
				{
					cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX - 1]);
				}
			}
			else
			{
				cell.SetNeighbor(HexDirection.SW, cells[i - cellCountX]);
				if (x < cellCountX - 1)
				{
					cell.SetNeighbor(HexDirection.SE, cells[i - cellCountX + 1]);
				}
			}
		}

		Text label = Instantiate<Text>(cellLabelPrefab);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.z);
		label.text = cell.coordinates.ToStringOnSeparateLines();
		cell.uiRect = label.rectTransform;
		cell.Elevation = 0;

		AddCellToChunk(x, z, cell);

	}
	void AddCellToChunk(int x, int z, HexCell cell)
	{
		int chunkX = x / HexMetrics.chunkSizeX;
		int chunkZ = z / HexMetrics.chunkSizeZ;
		HexGridChunk chunk = chunks[chunkX + chunkZ * chunkCountX];

		int localX = x - chunkX * HexMetrics.chunkSizeX;
		int localZ = z - chunkZ * HexMetrics.chunkSizeZ;
		chunk.AddCell(localX + localZ * HexMetrics.chunkSizeX, cell);

	}

	public void Save(BinaryWriter writer)
	{
		for (int i = 0; i < cells.Length; i++)
		{
			cells[i].Save(writer);
		}
	}

	public void Load(BinaryReader reader)
	{
		for (int i = 0; i < cells.Length; i++)
		{
			cells[i].Load(reader);
		}
		for (int i = 0; i < chunks.Length; i++)
		{
			chunks[i].Refresh();
		}
	}

}
