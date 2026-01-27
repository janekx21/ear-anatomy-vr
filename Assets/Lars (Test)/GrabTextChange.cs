using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabTextChange : MonoBehaviour
{
    [Tooltip("The text to display when this object is grabbed")]
    [TextArea(5, 10)]
    public string infoText;

    public AutoScrollText textScreenScript;

    private XRGrabInteractable grabInteractable;


    void OnEnable()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null )
        {
            grabInteractable.selectEntered.AddListener(OnGrab);
        }
    }

    void OnDisable()
    {
        if (grabInteractable != null )
        {
            grabInteractable.selectEntered.RemoveListener(OnGrab);
        }
    }


    private void OnGrab(SelectEnterEventArgs args)
    {
        if (textScreenScript != null)
        {
            textScreenScript.UpdateText(infoText);
        }

    }

}
