using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    int countdownTime = 60;
    // Start is called before the first frame update
    void Start()
    {
        EventSystem.instance.gameEnded += Disable;
        StartCoroutine(Timer());
    }

    IEnumerator Timer()
    {
        while(countdownTime >= 0) 
        {
            EventSystem.instance.UpdateCountdown(countdownTime);

            yield return new WaitForSeconds(1f);

            countdownTime--;

        }

        EventSystem.instance.EndGame("You Win !");
    }

    private void Disable(object sender, string str)
    {
        Debug.Log(str);
        StopCoroutine(Timer());
        this.enabled = false;
    }
}
