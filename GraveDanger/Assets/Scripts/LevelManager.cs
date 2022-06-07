using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;

    private int currentLevel = 0;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape) && currentLevel != 0)
        {
            pauseGame();
        }


    }

    public void pauseGame()
    {

        Time.timeScale = (Time.timeScale + 1) % 2;

        if (Time.timeScale == 0)
        {
            UIManager.instance.showPauseMenu(true);
        }
        else
        {
            UIManager.instance.showPauseMenu(false);
        }

    }

    public void loadNewGame()
    {
        Time.timeScale = 1;
        currentLevel = 1;
        SceneManager.LoadScene(1);
    }

    public void loadSavedGame()
    {
        Time.timeScale = 1;
        currentLevel = 1;
        GameManager.instance.loadSavedData();
        SceneManager.LoadScene(1);
    }

    public void loadMainMenu()
    {

        currentLevel = 2;
        SceneManager.LoadScene(0);
    }

    public void loadWinMenu()
    {
        currentLevel = 0;
        SceneManager.LoadScene(2);
    }

    public void loadArcadeMode()
    {
        Time.timeScale = 1;
        currentLevel = 1;
        SceneManager.LoadScene(3);
    }


    public void quitGame()
    {
        Application.Quit();
    }

}