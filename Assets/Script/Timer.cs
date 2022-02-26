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
        if (timeTF.text == "1")
        {
            StopAllCoroutines();
			GameObject.Find("AppleGUI").GetComponent<AudioSource>().Stop();
            GameManager.Instance.GameOver();
		}
		
        timeTF.text = (int.Parse(timeTF.text) - 1).ToString();
    }
}
