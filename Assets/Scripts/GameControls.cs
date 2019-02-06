using UnityEngine;

public class GameControls : MonoBehaviour {

    [SerializeField] private Game gameToStart;

    public void StartGame()
    {
        gameToStart.GameRunning = true;

        // Start game in {second argument} second(s), then TheGame method is called every {3rd argument} second(s)
        InvokeRepeating("CallTheGameFunction", 0.0f, 0.75f);

    }

    private void CallTheGameFunction()
    {
        gameToStart.TheGame();
    }

    public void StopGame()
    {
        gameToStart.GameRunning = false;
        foreach (Cell cell in gameToStart.cells)
        {
            cell.GenerationsSurvived = 0;
        }
    }

    public void ClearBoard()
    {
        foreach (Cell cell in gameToStart.cells)
        {
            cell.IsAlive = false;
        }
    }
}
