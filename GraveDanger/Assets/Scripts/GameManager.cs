using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{


    [SerializeField] private Texture2D crosshair;

    private float score;

    private bool gateOpened;

    public static GameManager instance;

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

    void Start()
    {


        Cursor.visible = true;
        Cursor.SetCursor(crosshair, Vector2.zero, CursorMode.Auto);

        score = 0;
        gateOpened = false;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIManager.instance.selectItem(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIManager.instance.selectItem(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UIManager.instance.selectItem(2);
        }

    }





    public void increaseScore()
    {
        score += 1;
        UIManager.instance.increaseScoreText(score);
    }

    public void setScore(float s)
    {
        if(s<0){
            s=0;
        }
        score = s;
        UIManager.instance.increaseScoreText(score);
    }

    public float getScore()
    {
        return score;
    }



    public void setGateOpened()
    {
        gateOpened = true;
    }

    public bool getGateOpened()
    {
        return gateOpened;
    }


    public void saveGame()
    {
        PlayerPrefs.SetFloat("Score", score);
        PlayerPrefs.SetInt("GateOpen", (gateOpened ? 1 : 0));
    }

    public void loadSavedData()
    {
        score = PlayerPrefs.GetFloat("Score");
        gateOpened = (PlayerPrefs.GetInt("GateOpen") != 0);

    }
}
