using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownMode : MonoBehaviour
{

    public GameObject model1;
    public GameObject model2;
    // Start is called before the first frame update
    public void PickModel(int index)
    {
        if (index == 0)
        {
            model1.SetActive(true);
            model2.SetActive(false);
        }
        else if (index == 1)
        {
            model1.SetActive(false);
            model2.SetActive(true);
        }

    }

}
