using UnityEngine;

public class AudioManager : MonoBehaviour, TimeAffected
{
    [Header("Audio Source")]   
    public AudioSource musicSource;
    public AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip backgroundPast;
    public AudioClip backgroundFuture;
    public AudioClip startMenuMusic;
    public AudioClip endScreenMusic;
    public AudioClip powerPortal;
    public AudioClip nextLevel;
    public AudioClip clockSwish;
    public AudioClip jump;

    [Header("Settings")]
    public bool startMenu;
    public bool endScreen;
    public bool isFuture;

    private TimeController timeController;

    public void IntoTheFuture()
    {
        if (isFuture || endScreen || startMenu) return;
        isFuture = true;
        musicSource.clip = backgroundFuture;
        musicSource.Play();
    }

    public void IntoThePast()
    {
        if (!isFuture || endScreen || startMenu) return;
        isFuture = false;
        musicSource.clip = backgroundPast;
        musicSource.Play();
    }

    private void Start()
    {
        timeController = GameObject.FindGameObjectWithTag("TimeController").GetComponent<TimeController>();
        timeController.Subscribe(this);

        if (startMenu)
        {
            musicSource.clip = startMenuMusic;
            musicSource.Play();
            return;
        }

        if (endScreen)
        {
            musicSource.clip = endScreenMusic;
            musicSource.Play();
            return;
        }

        if (!isFuture)
        {
            musicSource.clip = backgroundPast;
        }
        else
        {
            musicSource.clip = backgroundFuture;
        }
        musicSource.Play();
    }


    public void PlaySound(string soundName)
    {   
        switch (soundName)
        {
            case "ClockSwish":
                SFXSource.clip = clockSwish;
                break;
            case "Jump":
                SFXSource.clip = jump;
                break;
            case "PowerPortal":
                SFXSource.clip = powerPortal;
                break;
            case "NextLevel":
                SFXSource.clip = nextLevel;
                break;
            default:
                return;
        }
        SFXSource.Play();
    }
}
