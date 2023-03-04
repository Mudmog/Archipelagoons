using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Code referenced from https://catlikecoding.com/unity/tutorials/hex-map/part-1/

public class HexCell : MonoBehaviour
{

    [SerializeField] HexCell[] neighbors;

    public HexCoordinates coordinates;

    public Color color;


    public HexCell GetNeighbor (HexDirection direction)
    {
        return neighbors[(int)direction];
    }

    public void SetNeighbor (HexDirection direction, HexCell cell)
    {
        neighbors[(int)direction] = cell;
        cell.neighbors[(int)direction.Opposite()] = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
