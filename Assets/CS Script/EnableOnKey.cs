using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnKey : MonoBehaviour
{
    public KeyCode turnOnKey;
    public bool toggle = false;
    new public  GameObject gameObject;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(turnOnKey))
        {
            if (toggle)
            {
                gameObject.SetActive(!gameObject.activeSelf);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }

    }
}
