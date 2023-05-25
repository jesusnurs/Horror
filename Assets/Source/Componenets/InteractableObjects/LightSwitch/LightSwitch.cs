using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public Light _light;
    public bool _isOn;
    void Start()
    {
        _light.enabled = _isOn;
    }

    public void Interact()
    {
        _isOn = !_isOn;
        _light.enabled = _isOn;
    }

    public string GetDescription()
    {
        if (_isOn) return "Press [E] to turn <color=red>off</color> the light";
        return "Press [E] to turn <color=green>on</color> the light";
    }
}
