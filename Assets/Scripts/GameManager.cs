using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score;

    [Header("Timer")]
    private float timer;
    public float maxTimer;
    public bool starstop;

    private void Update()
    {
        Timer();
    }
    void AddScore(int _value)
    {
        score += _value;
    }

    void RemoveScore(int _value)
    {
        score -= _value;
    }

    void Timer()
    {
        if (starstop && timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            starstop = false;
        }
    }

    private void TimerReset()
    {
        timer = maxTimer; 
    }
}
