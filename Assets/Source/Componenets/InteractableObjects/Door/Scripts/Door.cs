using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private bool _needDescription;
    [SerializeField] private bool _ClosedDoor;
    
    [SerializeField] private bool _isOpen;

    [SerializeField] private AudioClip _closedDoorSound;
    [SerializeField] private AudioSource _audioSource;
    
    [SerializeField] private Animator _anim;

    [SerializeField] private Door _teleportDoor;
    [SerializeField] private Transform _teleport;
    [SerializeField] private Transform _secondTeleport;
    
    void Start()
    {
        _anim.SetBool("open",_isOpen);
    }

    public void Interact()
    {
        if (!_ClosedDoor)
        {
            _isOpen = !_isOpen;
            _anim.SetBool("open",_isOpen);
        }
        else
        {
            //_anim.SetTrigger("closed");
            _audioSource.PlayOneShot(_closedDoorSound);
        }
        
    }

    public string GetDescription()
    {
        if (!_needDescription)
            return "";
        
        if (_isOpen) return "Press [E] to <color=red>close</color> the door";
        return "Press [E] to <color=green>open</color> the door";
    }
    
    public bool IsClosed()
    {
        return _ClosedDoor;
    }
    public Door GetTeleportDoor()
    {
        return _teleportDoor;
    }
    
    public Transform GetTeleport()
    {
        return _teleport;
    }
    
    public Transform GetSecondTeleport()
    {
        return _secondTeleport;
    }
}
