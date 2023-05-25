using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public Animator _anim;
    public bool _isOpen;
    void Start()
    {
        _anim.SetBool("open",_isOpen);
    }

    public void Interact()
    {
        _isOpen = !_isOpen;
        _anim.SetBool("open",_isOpen);
    }

    public string GetDescription()
    {
        if (_isOpen) return "Press [E] to <color=red>close</color> the door";
        return "Press [E] to <color=green>open</color> the door";
    }
}
