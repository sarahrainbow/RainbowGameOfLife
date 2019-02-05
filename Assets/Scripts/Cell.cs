using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public bool IsAlive { get; set; }
    public bool NextIsAliveState;
    public Vector2 CellPosition;
    public Renderer CellRenderer;
    public int AliveNeighbours;
    public Color NextCellColor;
    public int TimesBeenAlive;
    private Color[] ColorArray = { Color.red, Color.yellow, Color.green, Color.blue, Color.magenta };


    private void OnMouseDown()
    {
        IsAlive = !IsAlive;
    }

    void Start()
    {
        CellPosition = this.transform.position;
        TimesBeenAlive = 0;

    }

    void Update()
    {



        if (IsAlive)
        {


            CellRenderer.material.color = ColorArray[TimesBeenAlive];
        }
        else
        {
            CellRenderer.material.color = Color.gray;
        }
        
    }

}
