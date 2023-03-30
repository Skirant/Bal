using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] _sounds;

    public static AudioManager instance;
    public bool isMuted = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in _sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume * (1 + UnityEngine.Random.Range(-s.randomVolue / 2f, s.randomVolue / 2f));
            s.source.pitch = s.pitch * (1 + UnityEngine.Random.Range(-s.randomPitch / 2f, s.randomPitch / 2f));
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(_sounds, Sound => Sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " опечатка");
            return;
        }


        s.source.volume = s.volume * (1 + UnityEngine.Random.Range(-s.randomVolue / 2f, s.randomVolue / 2f));
        s.source.pitch = s.pitch * (1 + UnityEngine.Random.Range(-s.randomPitch / 2f, s.randomPitch / 2f));
        s.source.Play();
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;

        foreach (Sound s in _sounds)
        {
            if (s.name != "Theme")
            {
                s.source.mute = isMuted;
            }
        }
    }

    public void ToggleOffMute()
    {
        isMuted = false;

        foreach (Sound s in _sounds)
        {
            if (s.name != "Theme")
            {
                s.source.mute = isMuted;
            }
        }
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(_sounds, Sound => Sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " опечатка");
            return;
        }

        s.source.Stop();
    }
}
