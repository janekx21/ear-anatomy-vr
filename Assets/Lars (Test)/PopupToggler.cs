using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupToggler : MonoBehaviour
{

    public GameObject PopUp;

    private bool isWindowOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        if (PopUp != null)
        { 
            PopUp.SetActive(false); 
        }
    }

    public void TogglePopUp()
    {
        if (PopUp != null)
        {
            isWindowOpen = !isWindowOpen;

            PopUp.SetActive(isWindowOpen);
        }
    }

    public void ForceClose()
    {
        isWindowOpen = false;

        if (PopUp != null)
        {
            PopUp.SetActive(false);
        }

    }
}
