using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Count : MonoBehaviour
{
    TextMeshProUGUI text;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        UpdateText();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCount(int amount)
    {
        count += amount;
        UpdateText();
    }

    void UpdateText()
    {
        text.SetText(string.Format("Count: {0}",count.ToString()));
    }
}
