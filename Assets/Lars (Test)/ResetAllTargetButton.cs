using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class ResetAllTargetButton : MonoBehaviour
{
    public Transform targetObject;

    string popUpName = "Pop Up";

    private Dictionary<Transform, (Vector3 pos, Quaternion rot)> savedTransforms = new();
    //private List<XRGrabInteractable> allGrabbables = new();
    private List<XRSocketInteractor> allSockets = new();
    private List<GameObject> allPopUps = new List<GameObject>();

    void Start()
    {
        if (targetObject != null)
        {
            foreach (Transform t in targetObject.GetComponentsInChildren<Transform>(true))
            {
                savedTransforms[t] = (t.localPosition, t.localRotation);

                if (t.name == popUpName)
                {
                    allPopUps.Add(t.gameObject);
                }

            }


            //allGrabbables.AddRange(targetObject.GetComponentsInChildren<XRGrabInteractable>());
            allSockets.AddRange(targetObject.GetComponentsInChildren<XRSocketInteractor>());
        }


    }

    public void ResetTarget()
    {

        foreach (var socket in allSockets)
        {
            if (socket != null)
                socket.enabled = false;
        }

/*        foreach (var grabInteractable in allGrabbables)
        {
            if (grabInteractable != null)
            {

                if (grabInteractable.isSelected)
                {
                    var interactors = new List<IXRSelectInteractor>(grabInteractable.interactorsSelecting);
                    foreach (var interactor in interactors)
                    {
                        grabInteractable.interactionManager.SelectExit(interactor, grabInteractable);
                    }
                }
            }
        }*/ // this would be used if we want to reset the object while holding it in our hand  

        foreach (var kvp in savedTransforms)
        {
            if (kvp.Key != null)
            {
                kvp.Key.localPosition = kvp.Value.pos;
                kvp.Key.localRotation = kvp.Value.rot;
            }
        }

        foreach (var popup in allPopUps)
        {
            if (popup != null)
            {
                popup.SetActive(false);
            }
            
        }

        foreach (var socket in allSockets)
        {
            if (socket != null)
                socket.enabled = true;
        }
    }

}
