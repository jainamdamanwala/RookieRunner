using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    private PlayerController player;
    public GameObject playScreen;
    public GameObject pauseMenu;
    public GameObject mainMenu;
    public GameObject storeMenu;
    public GameObject gameOverMenu;
    public GameObject buyLifeMenu;
    public GameObject buyMenu;

    private bool notEnoughGears;
    public bool boughtLifes;
    public GameObject notEnoughMenu;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mainMenu.SetActive(true);
        buyLifeMenu.SetActive(false);
        notEnoughGears = false;
        boughtLifes = false;
    }
    public void ReplayGame()
    {
        SaveSystem.SavePlayer(player);
        SceneManager.LoadScene("Main-Level");
    }
    public void QuitGame()
    {
        SaveSystem.SavePlayer(player);
        Application.Quit();
    }
    public void pause()
    {
        Time.timeScale = 0f;
        playScreen.SetActive(false);
        pauseMenu.SetActive(true);
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        playScreen.SetActive(true);
        pauseMenu.SetActive(false);
    }
    public void Store()
    {
        if (!notEnoughGears) 
        {
            mainMenu.SetActive(false);
            storeMenu.SetActive(true);
        }
        else if (notEnoughGears)
        {
            storeMenu.SetActive(true);
        }
    }
    public void PlayGame()
    {
        mainMenu.SetActive(false);
        playScreen.SetActive(true);
        Time.timeScale = 1;
    }
    public void Cross()
    {
        if (!notEnoughGears)
        {
            storeMenu.SetActive(false);
            mainMenu.SetActive(true);
        }
        else if (notEnoughGears)
        {
            storeMenu.SetActive(false);
        }
    }
    public void Home()
    {
        buyLifeMenu.SetActive(false);
        gameOverMenu.SetActive(true);
    }

    public void buyLifes()
    {
        if(player.gearCounter >= 10)
        {
            player.gearCounter -= 10;
            boughtLifes = true;
        }
        else
        {
            Debug.Log("NotEnoughGears");
            notEnoughGears = true;
            buyMenu.SetActive(false);
            notEnoughMenu.SetActive(true);
        }
    }
}
