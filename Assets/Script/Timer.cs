using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class Timer : MonoBehaviour
{
    public Text timeTF;
	public GameObject alertReference;

    void Start()
    {
        InvokeRepeating("ReduceTime", 1, 1);
    }
    
    void ReduceTime()
    {
        if (GameConstants.gameState != GameConstants.GameState.GAMEOVER)
        {
            if (timeTF.text == "2")
            {
                GameConstants.gameState = GameConstants.GameState.STOPFRUITS;
            }
            else if (timeTF.text == "1")
            {
                GameConstants.gameState = GameConstants.GameState.GAMEOVER;
                GameManager.Instance.GameOver();
            }

            timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
        }
    }
}
