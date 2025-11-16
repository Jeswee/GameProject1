using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    //Script für alle Menu Buttons
    
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        GameManager.instance.switchGameState(GameState.RUNNING);
    }

    public void TryAgain()
    {
        GameManager.instance.switchGameState(GameState.RUNNING);
    }
}
