
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuCanvas;
    public GameManager gameManager;
    public BarMove2 bmtwo;
    private void Start()
    {
        pauseMenuCanvas.SetActive(false);
    }
    void Update()
    {
        if(gameManager.Result == false) { 
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }    
    }

    public void Resume()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        
    }

    public void ToMain(int scene)
    {
        Time.timeScale = 1f;
        gameManager.Result = false;
        SceneManager.LoadScene(scene);
        bmtwo.Mode2();
        bmtwo.middleCheck();

    }
    
    public void Restart(int scene)
    {
        Time.timeScale = 1f;
        gameManager.Result = false;
        SceneManager.LoadScene(scene);
    }

}
