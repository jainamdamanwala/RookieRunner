using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public GameObject UI;

    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins;
    public static int numberOfGears;
    public Text coinsText;
    public Text gearText;
    public Text ScoreText;
    public Text HighScoreText;

    public Text m_coinsText;
    public Text m_gearText;
    public Text m_HighScoreText;

    public Text GameOvercoinsText;
    public Text GameOverScoreText;

    public Events events;

    private PlayerController player;
    void Start()
    {
        Time.timeScale = 0;
        gameOver = false;
        isGameStarted = false;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            gameOverPanel.SetActive(true);
            UI.SetActive(false);
            if (!events.boughtLifes)
            {
                Time.timeScale = 0;
            }
            if (events.boughtLifes)
            {
                Time.timeScale = 1;
                events.buyLifeMenu.SetActive(false);
                gameOver = false;
                StartCoroutine(resumeGame());
                //events.boughtLifes = false;
            }
        }
        numberOfCoins = player.coinCounter;
        numberOfGears = player.gearCounter;
        ScoreText.text = player.Score.ToString("0");
        //HighScoreText.text =player.HighScore.ToString("0");
        coinsText.text = numberOfCoins.ToString();
        gearText.text = numberOfGears.ToString(); ;

        m_HighScoreText.text =player.HighScore.ToString("0");
        m_coinsText.text = numberOfCoins.ToString();
        m_gearText.text = numberOfGears.ToString();

        GameOverScoreText.text = player.Score.ToString("0");
        GameOvercoinsText.text = numberOfCoins.ToString() ;

        if (SwipeManager.tap  && !isGameStarted)
        {
            Destroy(startingText);
            StartCoroutine(StartGame());
        }
    }
    private IEnumerator StartGame()
    {
        yield return new WaitForSeconds(0f);
        isGameStarted = true;
    }
    private IEnumerator resumeGame()
    {
        events.boughtLifes = true;
        yield return new WaitForSeconds(3f);
        events.boughtLifes = false;
        StopCoroutine(resumeGame());
    }
}

/*    public void savePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void loadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        Coins = data.coins;
        Diamond = data.diamonds;
    public void loadData()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        coinsCounter = data.coins;
        diamondsCounter = data.diamonds;
        gm.diamond = diamondsCounter;
        gm.coins = coinsCounter;
    }
    }*/

