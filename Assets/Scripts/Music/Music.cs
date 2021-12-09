using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource mainMenuTheme;
    public AudioSource gameTheme;
    static Music instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this; 
            DontDestroyOnLoad(gameObject);
        }
        else if (instance != this)
            Destroy(gameObject); 
    }
public void PlayMainMenuTheme()
    {
        if (mainMenuTheme.isPlaying)
            return;
        else
        {
            mainMenuTheme.Play();
            gameTheme.Stop();
        }
    }
    public void PlayGameTheme()
    {
        if (gameTheme.isPlaying)
            return;
        else
        {
            gameTheme.Play();
            mainMenuTheme.Stop();
        }
    }
}
