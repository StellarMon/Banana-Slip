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

    private bool pauseStatus = false;

    public Canvas pauseCanvas;
    private void Start()
    {
        
    }

    private void Update()
    {
        Timer();
        Pause();
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
            TimerReset();
        }
    }

    private void TimerReset()
    {
        timer = maxTimer; 
    }


    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseCanvas.enabled = !pauseStatus;
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
