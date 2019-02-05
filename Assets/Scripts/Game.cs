using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    private int GameSize = 33;
    public Cell cellPrefab;
    private List<Cell> cells = new List<Cell>();
    private bool GameRunning;
    public Color[] ColorArray = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };

    private void InstantiateCells()
    {
        for (int y = 0; y < GameSize; y++)
        {
            for (int x = 0; x < GameSize; x++)
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


        int TotalCells = GameSize * GameSize;

        // numbering cells (for debugging)
        for (int i = 0; i < TotalCells; i++)
        {
            cells[i].name = "cell " + i;
        }

    }

    public void StartGame()
    {

        GameRunning = true;

        // Start game in {second argument} second(s), then TheGame method is called every {3rd argument} second(s)
        InvokeRepeating("TheGame", 0.0f, 0.15f);

    }


    public void StopGame()
    {
        GameRunning = false;
        foreach(Cell cell in cells)
        {
            cell.TimesBeenAlive = 0;
        }
    }

    public void ClearBoard()
    {
        foreach(Cell cell in cells)
        {
            cell.IsAlive = false;
        }
    }

    public void TheGame()
    {



        if(GameRunning)
        {

        foreach (Cell cell in cells)
        {
            //find amount of alive neighbours
            cell.AliveNeighbours = FindNumberOfAliveNeighbours(cell);

                // Stop the changing color method exceeding the amount of colors in the array
               //if (cell.TimesBeenAlive == ColorArray.Length-1)
               //{
               //    cell.TimesBeenAlive = ColorArray.Length-1;
               //}

                // check if alive and whether it should stay alive to NextIsAliveState

                bool result=false;

            if (cell.IsAlive == true)
            {
                if (cell.AliveNeighbours < 2)
                {
                    result = false;
                    cell.TimesBeenAlive = 0;
                }

                else if (cell.AliveNeighbours > 3)
                {
                    result = false;
                    cell.TimesBeenAlive = 0;
                }

                else if (cell.AliveNeighbours == 2 || cell.AliveNeighbours == 3)
                {
                    result = true;
                    if(cell.TimesBeenAlive < ColorArray.Length)
                        {
                            cell.TimesBeenAlive++;
                        }
                        

                }
            }

            else if (cell.IsAlive == false)
            {
                if(cell.AliveNeighbours == 3)
                {
                    result = true;
                    cell.TimesBeenAlive=0;
                }
            }
            cell.NextIsAliveState = result;

        }
            // set all the results to next states
            SetNextState();

        }
    }


    private int FindNumberOfAliveNeighbours(Cell thisCell)
    {

        int aliveNeighbours = 0;
        //get position of cell
        float[] cellPosition = { thisCell.transform.position.x, thisCell.transform.position.y };

        // define neighbours and add to array

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

        // find the neighbour cells from x and y coordinates in allCells, and if they are alive, +1 to aliveNeighbours counter

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
            cell.IsAlive = cell.NextIsAliveState;
        }

    }


}

