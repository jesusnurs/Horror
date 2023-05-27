using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelinePlayer : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    
    private PlayableDirector _director;

    private void Awake()
    {
        _director = GetComponent<PlayableDirector>();
        _director.played += DirectorPlayed;
        _director.stopped += DirectorStopped;
    }

    private void DirectorPlayed(PlayableDirector obj)
    {
        _playerController.enabled = false;
    }
    
    private void DirectorStopped(PlayableDirector obj)
    {
        _playerController.enabled = true;
    }

    public void StartTimeline()
    {
        _director.Play();
    }
}