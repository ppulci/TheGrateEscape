using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioClip clickSound;
    public static AudioClip gulpSound;

    //These were changed to static for the cheese ball drop trap, if issues occur change it back!
    public static bool soundEnabled = true;
    public static bool musicEnabled = true;

    public static GameObject clickSoundManager;
    public static GameObject gulpSoundManager;
    public static GameObject musicManager;

    public Sprite on;
    public Sprite off;

    public Image soundSprite;
    public Image musicSprite;
    

    public void Start()
    {
        //1 is the default value, in case it does not exist
        if (PlayerPrefs.GetInt("SoundEnabled", 1) == 0) { soundEnabled = false; if (soundSprite != null) { soundSprite.sprite = off; } } else { soundEnabled = true; if (soundSprite != null) { soundSprite.sprite = on; } }
        if (PlayerPrefs.GetInt("MusicEnabled", 1) == 0) { musicEnabled = false; if (musicSprite != null) { musicSprite.sprite = off; } } else { musicEnabled = true; if (musicSprite != null) { musicSprite.sprite = on; } }

        musicManager = GameObject.FindWithTag("Music");

        clickSoundManager = GameObject.FindWithTag("Click Sound");
        gulpSoundManager = GameObject.FindWithTag("Gulp Sound");

        clickSound = clickSoundManager.GetComponent<AudioSource>().clip;
        gulpSound = gulpSoundManager.GetComponent<AudioSource>().clip;

        checkSound();   
    }

    public void checkSound()
    {
        if (!soundEnabled)
        {
            clickSoundManager.GetComponent<AudioSource>().mute = true;
            gulpSoundManager.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            clickSoundManager.GetComponent<AudioSource>().mute = false;
            gulpSoundManager.GetComponent<AudioSource>().mute = false;
        }

        if (!musicEnabled)
        {
            musicManager.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            musicManager.GetComponent<AudioSource>().mute = false;
        }
    }

    public void TOGGLESound()
    {
        if (soundEnabled)
        {
            soundSprite.sprite = off;
            soundEnabled = false;
            PlayerPrefs.SetInt("SoundEnabled", 0);
        }
        else
        {
            soundSprite.sprite = on;
            soundEnabled = true;
            PlayerPrefs.SetInt("SoundEnabled", 1);
        }
        checkSound();
    }

    public void TOGGLEMusic()
    {
        if (musicEnabled)
        {
            musicSprite.sprite = off;
            musicEnabled = false;
            PlayerPrefs.SetInt("MusicEnabled", 0);
        }
        else
        {
            musicSprite.sprite = on;
            musicEnabled = true;
            PlayerPrefs.SetInt("MusicEnabled", 1);
        }
        checkSound();
    }

    public static void playClick()
    {
        clickSoundManager.GetComponent<AudioSource>().PlayOneShot(clickSound);
    }

    public static void playGulp()
    {
        gulpSoundManager.GetComponent<AudioSource>().PlayOneShot(gulpSound);
    }
}
