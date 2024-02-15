using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public float MasterVolum = 1;
    private static AudioManager instance;
    public enum Sfx {objMove=2, unitHelp=4, Click =0, explosion=1, laser=3 }

    [Header("Bgm")]
    public AudioClip BgmClip;
    public float BgmVolume;
    AudioSource BgmSource;

    [Header("SFX")]
    public AudioClip[] sfxClips;
    public float sfxVolume = 1;
    public int sfxchannels;
    AudioSource[] sfxPlayers;
    int channelIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Init();
    }
    public static AudioManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            else
            {
                return instance;
            }
        }
    }

    void Init()
    {
        // Bgm Init
        var BgmObj = new GameObject("BgmPlayer");
        BgmObj.transform.parent = transform;
        BgmSource = BgmObj.AddComponent<AudioSource>();
        BgmSource.playOnAwake = false;
        BgmSource.loop = true;
        BgmSource.volume = BgmVolume*MasterVolum;
        BgmSource.clip = BgmClip;

        // SFX Init
        var SFXObj = new GameObject("SFXPlayer");
        SFXObj.transform.parent = transform;
        sfxPlayers = new AudioSource[sfxchannels];
        for (int i = 0; i < sfxPlayers.Length; i++)
        {
            sfxPlayers[i] = SFXObj.AddComponent<AudioSource>();
            sfxPlayers[i].playOnAwake = false;
            sfxPlayers[i].volume = sfxVolume*MasterVolum;
        }

    }

    

    public void PlayBgm()
    {
        if (BgmSource.isPlaying != true)
        {
            BgmSource.Play();
        }

        
    }

    public void PlaySFX(Sfx sfx)
    {

        Debug.Log(sfx.ToString());
        for (int i = 0;i < sfxPlayers.Length;i++)
        {
            var loopindex = (i + channelIndex) % sfxPlayers.Length;

            if (sfxPlayers[i].isPlaying == true)
                continue;

            channelIndex = loopindex;
            sfxPlayers[loopindex].clip = sfxClips[(int)sfx];
            sfxPlayers[loopindex].Play();
            break;
        }
    }
    
    public void PlayClick()
    {
        PlaySFX(Sfx.Click);
    }
    public void updateBgmVolum(float volum)
    {
        BgmVolume = volum;
        BgmSource.volume = volum*MasterVolum;
    }

    public void updateSFXVolum(float volum)
    {
        sfxVolume = volum;
        foreach (var sfxPlayer in sfxPlayers)
        {

            sfxPlayer.volume = volum * MasterVolum;
        }
    }
    public void updateMasterVolum(float volum)
    {
        MasterVolum = volum;
        updateBgmVolum(BgmVolume);
        updateSFXVolum(sfxVolume);
    }
}
