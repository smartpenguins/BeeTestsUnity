using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBee : MonoBehaviour
{
    public float speed = 1f;
    public float flyRadius = 4f;
    Vector3 startPoint;
    Vector3 toPoint;
    new Transform transform;

    // Start is called before the first frame update
    void Start()
    {
        transform = base.transform;
        startPoint = transform.position;
        toPoint = startPoint;
    }


    // Update is called once per frame
    void Update()
    {
        if ((transform.position - toPoint).sqrMagnitude < .02f)
        {
            Vector2 newPoint = Random.insideUnitCircle * flyRadius;
            toPoint = startPoint + new Vector3(newPoint.x, newPoint.y, 0);
        }
        transform.Translate((toPoint - transform.position).normalized * Time.deltaTime*speed);
    }
}
