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

    public GameObject curCheckPoint;

	// Use this for initialization
	void Start () {
	}

    public void SetCurCheckPoint(GameObject curCheckPoint)
    {
        this.curCheckPoint = curCheckPoint;
    }

    public void CountDownBegin(int startTime, bool first_time)
    {
        object[] parms = new object[2] { startTime, first_time };
        StartCoroutine("StartCountDown", parms);
    }
	
    IEnumerator StartCountDown(object[] parms)
    {

        player.GetComponent<Movement>().LockUnlockMovement(false);

        int startTime = (int)parms[0];
        bool first_time = (bool)parms[1];

        player.transform.position = (curCheckPoint.transform.position);

        int countDownTime = startTime;

        while(countDownTime > 0)
        {
            countDownText.text = countDownTime + "";
            countDownTime--;
            yield return new WaitForSeconds(1.0f);
        }

        countDownText.text = "GO!";

        player.GetComponent<Movement>().LockUnlockMovement(true);

        if(first_time)
        {
            StartCoroutine("StartTimer", 0.0f);
        }
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
