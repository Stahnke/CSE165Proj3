using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    public Text timerText;
    public Text countDownText;

    public int countDownStartTime = 3;

    private float timerTime = 0.0f;
    private bool timerOn = false;

    public GameObject player;

	// Use this for initialization
	void Start () {
        StartCoroutine("StartCountDown", countDownStartTime);
	}
	
    IEnumerator StartCountDown(int startTime)
    {
        int countDownTime = startTime;

        while(countDownTime > 0)
        {
            countDownText.text = countDownTime + "";
            countDownTime--;
            yield return new WaitForSeconds(1.0f);
        }

        countDownText.text = "GO!";

        player.GetComponent<Movement>().LockUnlockMovement(true);

        StartCoroutine("StartTimer", 0.0f);
        yield return new WaitForSeconds(1.0f);
        countDownText.text = "";
    }

    IEnumerator StartTimer(float startTime)
    {
        timerTime = startTime;
        timerOn = true;

        while(timerOn)
        {
            timerText.text = timerTime.ToString("F3") + "s";
            timerTime += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }

    public void EndGame()
    {
        timerOn = false;
        countDownText.text = "Game Complete!\n" + timerText.text;
    }

}
