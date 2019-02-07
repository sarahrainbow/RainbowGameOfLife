using UnityEngine;

public class GameControls : MonoBehaviour {

    [SerializeField] private Game gameToStart;
    [SerializeField] private Camera MainCamera;
    private int ZoomAmount = 1;
    private int MinZoom = 5;
    private int MaxZoom = 20;

    public void StartGame()
    {
        //gameToStart.GameRunning = true;

        // Start game in {second argument} second(s), then TheGame method is called every {3rd argument} second(s)
        InvokeRepeating("CallTheGameFunction", 0.0f, 0.75f);

    }

    private void CallTheGameFunction()
    {
        gameToStart.TheGame();
    }

    public void StopGame()
    {
        //gameToStart.GameRunning = false;
        CancelInvoke("CallTheGameFunction");
    }

    public void ClearBoard()
    {
        foreach (Cell cell in gameToStart.cells)
        {
            cell.IsAlive = false;
            cell.GenerationsSurvived = 0;
        }
    }


    public void ZoomIn()
    {

        if (MainCamera.orthographicSize <= MaxZoom && MainCamera.orthographicSize > MinZoom)
        {
            MainCamera.orthographicSize = MainCamera.orthographicSize - ZoomAmount;
        }

    }

    public void ZoomOut()
    {
        if (MainCamera.orthographicSize < MaxZoom && MainCamera.orthographicSize >= MinZoom)
        {
            MainCamera.orthographicSize += ZoomAmount;
        }

    }

}
