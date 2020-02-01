using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSwitcher : MonoBehaviour
{
    public AudioClip song1;
    public AudioClip song2;
    public AudioClip song3;
    public AudioClip song1Panic;
    public AudioClip song2Panic;
    public AudioClip song3Panic;
    private bool _playingPanic;

    private AudioSource _musicPlayer;
    void Start()
    {
        _playingPanic = false;
        _musicPlayer = gameObject.GetComponent<AudioSource>();
        _musicPlayer.loop = true;
        _musicPlayer.clip = ChooseRandomSong();
        _musicPlayer.Play();
        //_musicPlayer.clip = song2;
        //_musicPlayer.clip = song3;
    }

    private AudioClip ChooseRandomSong()
    {
        System.Random r = new System.Random();
        int rInt = r.Next(1, 4);
        switch (rInt)
        {
            case 1: return song1;
            case 2: return song2;
            case 3: return song3;
            default:
                return song1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((GameObject.FindGameObjectWithTag("ShipHealth").GetComponent("ShipDamageBar") as ShipDamageBar).currentDamage >= 60.0)
        {
            if (!_playingPanic)
                PlayPanic();
        } else
        {
            if (_playingPanic)
                PlayNormal();
        }
    }

    private void PlayNormal()
    {
        var currenttime = _musicPlayer.time;
        _musicPlayer.Stop();
        _musicPlayer.clip = GetCurrentNormalSong();
        _musicPlayer.time = currenttime;
        _musicPlayer.Play();
        _playingPanic = false;
    }

    private AudioClip GetCurrentNormalSong()
    {
        if (_musicPlayer.clip == song1Panic)
            return song1;
        else if (_musicPlayer.clip == song2Panic)
            return song2;
        else
            return song3;
    }

    private void PlayPanic()
    {
        var currenttime = _musicPlayer.time;
        _musicPlayer.Stop();
        _musicPlayer.clip = GetCurrentPanicSong();
        _musicPlayer.time = currenttime;
        _musicPlayer.Play();
        _playingPanic = true;
    }

    private AudioClip GetCurrentPanicSong()
    {
        if (_musicPlayer.clip == song1)
            return song1Panic;
        else if (_musicPlayer.clip == song2)
            return song2Panic;
        else
            return song3Panic;
    }
}
