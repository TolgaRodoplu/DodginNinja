using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public TextMeshProUGUI endText;
    public TextMeshProUGUI countdownText;
    public Image healthImg;

    // Start is called before the first frame update
    void Start()
    {
        EventSystem.instance.gameEnded += End;
        EventSystem.instance.updateHealth += UpdateHealthImg;
        EventSystem.instance.countdownUpdated += UpdateCountdown;
    }

    void UpdateCountdown(object sender, int newTime)
    {
        int minute = newTime / 60;
        int second = newTime % 60;

        if(second < 10)
            countdownText.text = minute+ ":0" + second;
        else
            countdownText.text = minute + ":" + second;
    }

    void UpdateHealthImg(object sender, float newHealth)
    {
        healthImg.fillAmount = newHealth / 3;
    }

    void End(object sender, string str)
    {
        endText.transform.parent.gameObject.SetActive(true);
        endText.text = str;
    }

    public void AgainBtn()
    {
        SceneManager.LoadScene(0);
    }
}
