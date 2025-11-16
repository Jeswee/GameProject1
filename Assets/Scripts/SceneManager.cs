using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    //Script für alle Menu Buttons
    
    public void StartGame()
    {
        //GameManager.instance.switchGameState(GameState.RUNNING);
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        
        Application.Quit();
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        
        GameManager.instance.switchGameState(GameState.RUNNING);
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }

    public void Resume()
    {
        GameManager.instance.switchGameState(GameState.RUNNING);
    }

    public void TryAgain()
    {
        Time.timeScale = 1;

        GameManager.instance.switchGameState(GameState.RUNNING);
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
