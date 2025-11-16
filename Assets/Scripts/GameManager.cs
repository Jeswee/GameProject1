using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameState gameState;

    [SerializeField] GameObject PlayerUI;
    [SerializeField] GameObject GameOverUI;
    [SerializeField] GameObject PauseUI;

    void Awake()
    {
        switchGameState(GameState.RUNNING);
        instance = this;
    }

    void Start()
    {
        
        
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
                Time.timeScale = 1;
                if (PlayerUI != null) PlayerUI.SetActive(true);
                if (GameOverUI != null) GameOverUI.SetActive(false);
                if (PauseUI != null) PauseUI.SetActive(false);
                
                break;
            case GameState.PAUSED :
                Time.timeScale = 0;
                HighScoreManager.instance.UpdateScore();
                if (PlayerUI != null) PlayerUI.SetActive(false);
                if (GameOverUI != null) GameOverUI.SetActive(false);
                if (PauseUI != null) PauseUI.SetActive(true);
                
                break;
            case GameState.GAMEOVER :
                Time.timeScale = 0;
                HighScoreManager.instance?.UpdateScore();
                if (PlayerUI != null) PlayerUI.SetActive(false);
                if (GameOverUI != null) GameOverUI.SetActive(true);
                if (PauseUI != null) PauseUI.SetActive(false);
                
                break;
            case GameState.INMENU :
                Time.timeScale = 1;

                break;
        }
    }
}
