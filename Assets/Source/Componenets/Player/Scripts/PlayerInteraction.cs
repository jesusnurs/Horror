using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public Camera _mainCamera;
    public float _interactionDistance;

    public GameObject _interactionUI;
    public TextMeshProUGUI _interantionText;

    private TimelinePlayer _timelinePlayer;

    private PlayerController _playerController;

    private void Start()
    {
        _playerController = gameObject.GetComponent<PlayerController>();
        _timelinePlayer = gameObject.GetComponent<TimelinePlayer>();
    }

    void Update()
    {
        InteractionRay();
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void InteractionRay()
    {
        Ray ray = _mainCamera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        bool hitSmth = false;
        
        if(Physics.Raycast(ray,out hit, _interactionDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != null)
            {
                hitSmth = true;
                _interantionText.text = interactable.GetDescription();

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Door door = hit.collider.GetComponent<Door>();
                    if (door != null && !door.IsClosed())
                    {
                        StartCoroutine(TransformToTeleportPosition(door));
                        return;
                    }
                    interactable.Interact();
                }
            }
        }
        
        _interactionUI.SetActive(hitSmth);
    }

    public IEnumerator TransformToTeleportPosition(Door door)
    {
        _playerController.enabled = false;
        float timeElapsed = 0;
        Vector3 targetPosition = door.GetTeleport().position;
        Vector3 startPosition = transform.position;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = door.GetTeleportDoor().GetTeleport().position;
        door.GetTeleportDoor().Interact();
        yield return new WaitForSeconds(2f);
        
        timeElapsed = 0;
        targetPosition = door.GetTeleportDoor().GetSecondTeleport().position;
        startPosition = transform.position;
        while (timeElapsed < 1)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, timeElapsed);
            timeElapsed += Time.deltaTime/2f;
            yield return null;
        }
        door.GetTeleportDoor().Interact();
        _playerController.enabled = true;
    }
    
}
