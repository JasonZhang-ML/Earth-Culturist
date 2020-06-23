using UnityEngine;
using System.Collections;
using UnityEngine.UI; //Need this for calling UI scripts
using SonicBloom.Koreo;
using UnityEngine.SceneManagement;

public class In_Game_Panel : MonoBehaviour {

    // [SerializeField]
    // Transform UIPanel_base; //Will assign our panel to this variable so we can enable/disable it
    [SerializeField]
    Transform UIPanel; //Will assign our panel to this variable so we can enable/disable it
    [SerializeField]
    Transform UIPanel_WIN; //Win Panel
    [SerializeField]
    Text timeText; //Will assign our Time Text to this variable so we can modify the text it displays.
    [SerializeField]
    Text scoreText; //Will assign our Time Text to this variable so we can modify the text it displays.
    [SerializeField]
    Text Over_Score; //Will assign our Time Text to this variable so we can modify the text it displays.

    bool isPaused; //Used to determine paused state
    public float Final_Score;    
    public float timer; // timing 
    public float GameTime_over = 120f; // Time to win or exit?    

    
    bool isOverd;
    private AudioSource _audioSource;

    void Start ()
    {
        UIPanel.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
        UIPanel_WIN.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
        // UIPanel_base.gameObject.SetActive(false); //make sure our pause menu is disabled when scene starts
        isPaused = false; //make sure isPaused is always false when our scene opens
        isOverd = false;
    }

    void Update ()
    {
        if (isOverd == false)
            timer += Time.deltaTime;

        // Final Score calculation
        Final_Score = Earth_Color._instance.ground_score 
                + Earth_Color._instance.water_score
                + Forest_Change._instance.forest_score
                + Animal_Scaling._instance.animal_score
                + City_Change._instance.city_score;

        timeText.text = System.Math.Round(Time.timeSinceLevelLoad, 0).ToString() + " s";  //Tells us the time since the scene loaded
        scoreText.text =  System.Math.Ceiling(Final_Score * 10000f).ToString();


        //If player presses escape and game is not paused. Pause game. If game is paused and player presses escape, unpause.
        if(Input.GetKeyDown(KeyCode.Escape) && !isPaused)
            Pause();
        else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
            UnPause();

        if(timer > GameTime_over)
        {
            Debug.Log(timer);
            timer = 0f;
            Gameover();
        }
    }

    void Gameover()
    {
        if (isOverd == false){
            // UIPanel_base.gameObject.SetActive(true);
            UIPanel_WIN.gameObject.SetActive(true);
            m_pause = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
            m_pause.Pause();

            Time.timeScale = 0f; //pause the game

            Over_Score.text = System.Math.Ceiling(Final_Score * 10000f).ToString();

            Music_Effect._instance.Win_Effect();

            isOverd = true;
        }
    }


    AudioSource m_pause;
    float timeNow = 0;

    public void Pause()
    {
        m_pause = GameObject.Find("MusicPlayer").GetComponent<AudioSource>();
        m_pause.Pause();
        // AudioSource.PlayClipAtPoint(Effect_clip, new Vector3(0f,0f,0f));
        // m_pause.

        timeNow = m_pause.time;
        isPaused = true;

        // Music_Effect._instance.Tap_Music_Effect();
        // UIPanel_base.gameObject.SetActive(true);
        UIPanel.gameObject.SetActive(true); //turn on the pause menu
        Time.timeScale = 0f; //pause the game

        // SonicBloom.Koreo.Players.SimpleMusicPlayer.Destroy();
        
    }

    public void UnPause()
    {
        m_pause.time = timeNow; 
        m_pause.Play();
        isPaused = false;
        // UIPanel_base.gameObject.SetActive(false);
        UIPanel.gameObject.SetActive(false); //turn off pause menu
        Time.timeScale = 1f; //resume game
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Ryhthm_game()
    {
        isOverd = false;

        Time.timeScale = 1f; //resume game
        // Application.LoadLevel(0);
        // SceneManager.LoadScene(SceneManager.GetActiveScene()) ;
        SceneManager.LoadScene(0,LoadSceneMode.Single);
        m_pause.time = 0f; 
        m_pause.Play();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        // AudioSource.Play();
    }
    public void Random_Earth()
    {
        isOverd = false;

        Time.timeScale = 1f; //resume game
        SceneManager.LoadScene(1,LoadSceneMode.Single);
        // SceneManager.LoadScene(1);
        // AudioSource.Play();
    }
}