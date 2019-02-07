using UnityEngine;
using UnityEngine.UI;

public class GameControls : MonoBehaviour {

    [SerializeField] private Game gameToControl;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Button startButton;
    private bool gameStarted;
    private int zoomAmount = 1;
    private int minZoom = 5;
    private int maxZoom = 20;

    public void StartGame()
    {
        startButton.interactable = false;

        // Start game in {second argument} second(s), then TheGame method is called every {3rd argument} second(s)
        InvokeRepeating("CallTheGameFunction", 0.0f, 0.75f);

    }

    private void CallTheGameFunction()
    {
        gameToControl.TheGame();
    }

    public void StopGame()
    {
        startButton.interactable = true;
        CancelInvoke("CallTheGameFunction");

    }

    public void ClearBoard()
    {
        foreach (Cell cell in gameToControl.cells)
        {
            cell.IsAlive = false;
            cell.GenerationsSurvived = 0;
        }
    }


    public void ZoomIn()
    {

        if (mainCamera.orthographicSize <= maxZoom && mainCamera.orthographicSize > minZoom)
        {
            mainCamera.orthographicSize = mainCamera.orthographicSize - zoomAmount;
        }

    }

    public void ZoomOut()
    {
        if (mainCamera.orthographicSize < maxZoom && mainCamera.orthographicSize >= minZoom)
        {
            mainCamera.orthographicSize += zoomAmount;
        }

    }

}
