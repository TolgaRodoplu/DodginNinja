using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static EventSystem instance;
    public event EventHandler<string> gameEnded;
    public event EventHandler<int> countdownUpdated;
    public event EventHandler<float> updateHealth;
    bool isStarted = false;

    private void Awake()
    {
        instance = this;
    }

    public void EndGame(string endStr)
    {
        gameEnded?.Invoke(this, endStr);
    }

    public void UpdateHealth(float newHealth)
    {
        updateHealth?.Invoke(this, newHealth);
    }

    public void UpdateCountdown(int countdown)
    {
        countdownUpdated?.Invoke(this, countdown);
    }
}
