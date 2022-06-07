using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{

    public void saveGame()
    {
        GameManager.instance.saveGame();
    }

    public void loadSavedGame()
    {
        LevelManager.instance.loadSavedGame();
    }

    public void loadNewGame()
    {
        LevelManager.instance.loadNewGame();
    }

    public void quitGame()
    {
        LevelManager.instance.quitGame();
    }

    public void loadMainMenu()
    {
        LevelManager.instance.loadMainMenu();
    }

    public void loadArcadeMode()
    {
        LevelManager.instance.loadArcadeMode();
    }

}
