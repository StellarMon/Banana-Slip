using SolarStudios;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public static VideoManager instance;
    private bool played;

    public VideoPlayer player;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);

        }
    }

    private void Start()
    {
        if(!played)
        {
            played = true;
            player.Play();
        }
        
    }
}
