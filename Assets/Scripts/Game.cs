using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private int gameSize = 34;
    [SerializeField] private Cell cellPrefab;
    public List<Cell> cells = new List<Cell>();
    public bool GameRunning { get; set; }


    private void InstantiateCells()
    {
        for (int y = 0; y < gameSize; y++)
        {
            for (int x = 0; x < gameSize; x++)
            {
                var cell = Instantiate(cellPrefab, new Vector2(x, y), Quaternion.identity);
                cells.Add(cell);
            }
        }
    }

    // Use this for initialization
    public void Start()
    {
        InstantiateCells();

        int totalCells = gameSize * gameSize;

        #if DEBUG
        for (int i = 0; i < totalCells; i++)
        {
            cells[i].name = "cell " + i;
        }
        #endif
    }

    public void TheGame()
    {
        if(GameRunning)
        {

        foreach (Cell cell in cells)
        {
            cell.AliveNeighbours = FindNumberOfAliveNeighbours(cell);
            bool alive=false;

            if (cell.IsAlive)
            {
                if (cell.AliveNeighbours < 2)
                {
                    alive = false;
                    cell.GenerationsSurvived = 0;
                }

                else if (cell.AliveNeighbours > 3)
                {
                    alive = false;
                    cell.GenerationsSurvived = 0;
                }

                else if (cell.AliveNeighbours == 2 || cell.AliveNeighbours == 3)
                {
                    alive = true;
                        cell.Promote();
                }
            }

            else if (!cell.IsAlive)
            {
                if(cell.AliveNeighbours == 3)
                {
                    alive = true;
                    cell.GenerationsSurvived=0;
                }
            }
            cell.NextCellState = alive;

        }
            SetNextState();

        }
    }


    private int FindNumberOfAliveNeighbours(Cell thisCell)
    {

        int aliveNeighbours = 0;
        float[] cellPosition = { thisCell.CellPosition.x, thisCell.CellPosition.y };

        double[,] neighbourCellPositions = {
                { cellPosition[0] - 1, cellPosition[1] + 1},  /* nw */ 
                { cellPosition[0], cellPosition[1] + 1 },     /* n */ 
                { cellPosition[0] + 1, cellPosition[1] + 1},  /* ne */ 
                { cellPosition[0] + 1, cellPosition[1] },     /* e */ 
                { cellPosition[0]+1, cellPosition[1] -1 },    /* se */ 
                { cellPosition[0], cellPosition[1] - 1 },     /* s */
                { cellPosition[0] - 1, cellPosition[1] - 1 }, /* sw */
                { cellPosition[0] - 1, cellPosition[1]}       /* w */
            };

        for (int i = 0; i < 8; i++)
        {
            foreach(Cell cell in cells)
            {
                if (cell.transform.position.x == neighbourCellPositions[i, 0] &&
                    cell.transform.position.y == neighbourCellPositions[i, 1] &&
                        cell.IsAlive == true)
                {
                    aliveNeighbours++;
                }
            }
        }

        return aliveNeighbours;
    }


    public void SetNextState()
    {
        foreach(Cell cell in cells)
        {
            cell.IsAlive = cell.NextCellState;
        }

    }


}

