using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPS : MonoBehaviour
{
    TextMeshProUGUI text;
    float averageDeltaTime = 1f/60f;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (QualitySettings.vSyncCount == 0)
                QualitySettings.vSyncCount = 1;
            else
                QualitySettings.vSyncCount = 0;
        }
        averageDeltaTime = Mathf.Lerp(averageDeltaTime, Time.deltaTime, .05f);
        text.SetText(string.Format("FPS: {0:#.}", 1f / averageDeltaTime));
    }
}
