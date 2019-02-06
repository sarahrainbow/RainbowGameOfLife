using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    private Renderer cellRenderer;
    private List<Color> cellColors = new List<Color>();
    
    public bool IsAlive { get; set; }
    public bool NextCellState { get; set; }
    public Vector2 CellPosition { get; set; }
    public int AliveNeighbours { get; set; }
    public int GenerationsSurvived { get; set; }


    private void OnMouseDown()
    {
        IsAlive = !IsAlive;
    }

    private void Start()
    {
        cellRenderer = GetComponent<Renderer>();
        CellPosition = this.transform.position;
        GenerationsSurvived = 0;

        Color[] colors = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };
        cellColors.AddRange(colors);

    }

    private void Update()
    {

        if (IsAlive)
        {

            cellRenderer.material.color = cellColors[GenerationsSurvived];
        }
        else
        {
            cellRenderer.material.color = Color.white;
        }
        
    }

    public void Promote()
    {
        if (GenerationsSurvived < cellColors.Count - 1)
        {
            GenerationsSurvived++;
        }

    }

}
