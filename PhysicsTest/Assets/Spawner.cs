using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cube;
    public Count count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            count.AddCount(10);
            for(int i = 0; i < 10; i++)
            {
                Instantiate(cube).transform.Translate(-5+i,0,0);
            }
        }
    }
}
