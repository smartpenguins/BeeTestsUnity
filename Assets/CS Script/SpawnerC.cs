using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerC : MonoBehaviour
{
    public GameObject prefab;
    public int maxCount = 0;
    public KeyCode turnOnKey = KeyCode.C;
    public int maxSpawnPerFrame = 100;

    private bool run = false;
    private int count = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(run)
                maxCount += 10000;
        }
        if (Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Return))
        {
            if (run)
                maxCount += 100000;
        }
        if (Input.GetKeyDown(turnOnKey))
        {
            run = true;
            maxCount += 1000;
        }
        if (run && maxCount > count)
        {
            int maxSpwanTemp = Mathf.Min(maxSpawnPerFrame, maxCount - count);
            for(int i = 0; i < maxSpwanTemp; i++)
            {
                Instantiate(prefab);
                count++;
            }
            FPS.SetCount(count);
        }
    }
}
