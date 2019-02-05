using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour {

    public Camera MainCamera;
    private int ZoomAmount = 1;
    private int MinZoom = 5;
    private int MaxZoom = 18;

    public void ZoomIn()
    {

        if(MainCamera.orthographicSize <= MaxZoom && MainCamera.orthographicSize > MinZoom)
        {
            MainCamera.orthographicSize =  MainCamera.orthographicSize - ZoomAmount;
        }

    }

    public void ZoomOut()
    {
        if(MainCamera.orthographicSize < MaxZoom && MainCamera.orthographicSize >= MinZoom)
        {
            MainCamera.orthographicSize += ZoomAmount;
        }

    }

}


