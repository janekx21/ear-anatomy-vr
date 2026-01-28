using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropdownMode : MonoBehaviour
{

    public GameObject[] model1Objects;
    public GameObject[] model2Objects;
    // Start is called before the first frame update
    public void PickModel(int index)
    {
        if (index == 0)
        {
            foreach (GameObject obj in model1Objects)
            {
                obj.SetActive(true);
            }

            foreach (GameObject obj in model2Objects)
            {
                obj.SetActive(false);
            }

        }
        else if (index == 1)
        {
            foreach (GameObject obj in model1Objects)
            {
                obj.SetActive(false);
            }

            foreach (GameObject obj in model2Objects)
            {
                obj.SetActive(true);
            }
        }

    }

}
