using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// make game manager public static so can access this from other scripts
	public static GameManager gm;
    public enum GameState { menu, play, pause, over};
	// public variables
	public int score=0;
    public GameState gameState;
	public float startTime=5.0f;

    public GameObject Player;
    public GameObject Spawner;

    public GameObject menuCanvas;
    public GameObject mainCanvas;
	public Text mainScoreDisplay;
	public Text mainTimerDisplay;
    public GameObject pauseQuitButton;
    public GameObject OverCanvas;
    public Text overScoreDisplay;
    public Text overHighScoreDisplay;

	public AudioSource musicAudioSource;

	private float currentTime;
    private MouseLooker ml;
    private SpawnGameObjects sp;
	// setup the game
	void Start () {

        // get a reference to the GameManager component for use by other scripts
        if (gm == null)
            gm = this;

        gameState = GameState.menu;

        if (!PlayerPrefs.HasKey("HighScore"))
            PlayerPrefs.SetInt("HighScore", 0);

#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
        ml = Player.GetComponent<MouseLooker>();
#endif
        sp = Spawner.GetComponent<SpawnGameObjects>();
    }

	// this is the main game event loop
	void Update () {
        switch(gameState)
        {
            case GameState.menu:
                if (Input.GetButtonDown("Cancel"))
                    Application.Quit();
                break;
            case GameState.play:
                if (Input.GetButtonDown("Cancel"))
                    PauseGame();
                else if (currentTime < 0)
                { // check to see if timer has run out
                    EndGame();
                }
                else
                { // game playing state, so update the timer
                    currentTime -= Time.deltaTime;
                    mainTimerDisplay.text = currentTime.ToString("0.00");
                }
                break;
            case GameState.pause:
                if (Input.GetButtonDown("Cancel"))
                    ResumeGame();
                break;
            case GameState.over:
                break;
        }
	}

    public void StartGame()
    {
        score = 0;
        gameState = GameState.play;
        currentTime = startTime;
        mainScoreDisplay.text = score.ToString();
        mainTimerDisplay.text = score.ToString();
        menuCanvas.SetActive(false);
        mainCanvas.SetActive(true);
        sp.Spawn();
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
        ml.LockCursor(true);
#endif
    }

    void PauseGame()
    {
        gameState = GameState.pause;
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
        ml.LockCursor(false);
#endif
        Time.timeScale = 0.0f;
        mainTimerDisplay.text = "Paused";
        pauseQuitButton.SetActive(true);
    }

    void ResumeGame()
    {
        pauseQuitButton.SetActive(false);
        gameState = GameState.play;
        Time.timeScale = 1.0f;
        mainTimerDisplay.text = currentTime.ToString();
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
        ml.LockCursor(true);
#endif
        sp.Spawn();
    }

	void EndGame() {
        gameState = GameState.over;
        mainCanvas.SetActive(false);
        int highscore = PlayerPrefs.GetInt("HighScore");
        if(score>highscore)
        {
            overScoreDisplay.text = score.ToString();
            overHighScoreDisplay.text = "New Record";
            PlayerPrefs.SetInt("HighScore", score);
        }
        else
        {
            overScoreDisplay.text = score.ToString();
            overHighScoreDisplay.text = highscore.ToString();
        }
        OverCanvas.SetActive(true);
#if UNITY_STANDALONE || UNITY_WEBGL || UNITY_EDITOR
        ml.LockCursor(false);
#endif
        // reduce the pitch of the background music, if it is set 
        if (musicAudioSource)
			musicAudioSource.pitch = 0.5f; // slow down the music
	}

	// public function that can be called to update the score or time
	public void targetHit (int scoreAmount, float timeAmount)
	{
		// increase the score by the scoreAmount and update the text UI
		score += scoreAmount;
		mainScoreDisplay.text = score.ToString ();
		
		// increase the time by the timeAmount
		currentTime += timeAmount;
		
		// don't let it go negative
		if (currentTime < 0)
			currentTime = 0.0f;

		// update the text UI
		mainTimerDisplay.text = currentTime.ToString ("0.00");
	}

	// public function that can be called to restart the game
	public void RestartGame ()
	{
        // we are just loading a scene (or reloading this scene)
        // which is an easy way to restart the level
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}
}
