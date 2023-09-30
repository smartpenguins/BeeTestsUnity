using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FPS : MonoBehaviour
{
    public TextMeshProUGUI text;
    [Range(.1f,3f)]
    public float updateEveryXSeconds = .5f;

    private int count = 0;
    static private FPS _instence;
    private void Awake()
    {
        if (_instence)
        {
            Destroy(gameObject);
            return;
        }
        _instence = this;
    }

    // Update is called once per frame
    float fps = 60;
    float timeSincelastUpdate = 10f;
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if (Input.GetKeyDown(KeyCode.Keypad1+i)|| Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                SceneManager.LoadScene(i);
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(gameObject.scene.name);
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            if(QualitySettings.vSyncCount==0)
                QualitySettings.vSyncCount = 1;
            else
                QualitySettings.vSyncCount=0;
        }


        fps = Mathf.Lerp(fps, 1f / Mathf.Max(.0001f,Time.smoothDeltaTime), .01f);

        timeSincelastUpdate += Time.deltaTime;
        if (timeSincelastUpdate>=updateEveryXSeconds)
        {
            timeSincelastUpdate = 0;
        }
        else {
            return; 
        }

        text.SetText(count+"\n"+fps.ToString("0.0"));
    }

    public static void SetCount(int count)
    {
        _instence.count = count;
    }
}
