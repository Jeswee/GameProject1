using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState = GameState.RUNNING;

    [SerializeField] GameObject PlayerUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject PauseUI;


    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        checkInput();
    }

    void checkInput()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            switchGameState(GameState.PAUSED);
        }
    }

    public void switchGameState(GameState gameState)
    {
        this.gameState = gameState;
        switch (this.gameState)
        {
            case GameState.RUNNING : 
                PlayerUI.SetActive(true);
                GameOverUI.SetActive(false);
                PauseUI.SetActive(false);
                Time.timeScale = 1;
                break;
            case GameState.PAUSED :
                PlayerUI.SetActive(false);
                GameOverUI.SetActive(false);
                PauseUI.SetActive(true);
                Time.timeScale = 0;
                return;
            case GameState.GAMEOVER :
                PlayerUI.SetActive(false);
                GameOverUI.SetActive(true);
                PauseUI.SetActive(false);
                Time.timeScale = 0;
                return;
        }
    }
}
