using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public Text scoretxt;
    public Text Timer;
    public GameObject GameoverObj;
    
    private static GameManager instance;
    int score;

    public void Awake()
    {
        instance = this;
        GameoverObj.SetActive(false);
    }

    public static GameManager Instance {
        get {
            return instance;
        }
    }

    public void UpdateScore()
    {
        score += 1;
        scoretxt.text = score.ToString();
    }

    public void GameOver()
    {
        GameoverObj.GetComponent<AudioSource>().Play();
        GameoverObj.SetActive(true);
    }

    public void Reload()
    {
        SceneManager.LoadScene("Scene1");
    }
}
