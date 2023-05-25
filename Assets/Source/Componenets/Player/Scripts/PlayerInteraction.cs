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
                    interactable.Interact();
                }
            }
        }
        
        _interactionUI.SetActive(hitSmth);
    }
}
