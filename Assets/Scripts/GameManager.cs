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
        //switchGameState(GameState.RUNNING);
    }

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
                Time.timeScale = 1;
                PlayerUI?.SetActive(true);
                GameOverUI?.SetActive(false);
                PauseUI?.SetActive(false);
                
                break;
            case GameState.PAUSED :
                Time.timeScale = 0;
                HighScoreManager.instance.UpdateScore();
                PlayerUI?.SetActive(false);
                GameOverUI?.SetActive(false);
                PauseUI?.SetActive(true);
                
                break;
            case GameState.GAMEOVER :
                Time.timeScale = 0;
                HighScoreManager.instance?.UpdateScore();
                PlayerUI?.SetActive(false);
                GameOverUI?.SetActive(true);
                PauseUI?.SetActive(false);
                
                break;
        }
    }
}
