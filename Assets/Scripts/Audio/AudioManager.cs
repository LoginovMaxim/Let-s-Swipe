using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Sound[] _sounds;

    private void Awake()
    {
        foreach (Sound s in _sounds)
        {
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.clip = s.Clip;

            s.Source.volume = s.Volume;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.Name == name);
        if (s == null)
            return;
        s.Source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.Name == name);
        if (s == null)
            return;
        s.Source.Stop();
    }

    public bool GetSoundActive(string name)
    {
        Sound s = Array.Find(_sounds, sound => sound.Name == name);
        if (s == null)
            return false;
        else
            return s.Source.isPlaying;
    }

    public void SetPitch(string name, float pitch)
    {
        Sound s = Array.Find(_sounds, sound => sound.Name == name);
        if (s == null)
            return;
        s.Source.pitch = pitch;
    }

    public void SetVolume(string name, float volume)
    {
        Sound s = Array.Find(_sounds, sound => sound.Name == name);
        if (s == null)
            return;
        s.Source.volume = volume;
    }
}
