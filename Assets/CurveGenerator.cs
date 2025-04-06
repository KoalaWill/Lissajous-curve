using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LissajousCurve : MonoBehaviour
{
    public Transform dotPrefab; // The prefab of the dot
    public float xAmplitude = 3;
    public float xFrequency = 0.2f;
    public float yAmplitude = 3;
    public float yFrequency = 0.4f;
    public float xOffset;
    public float yOffset;
    public float deltaAngle; // In degrees
    public bool Continue; // whether to continue going;
    public float xPos;
    public float yPos;
    [Tooltip("You can press \"T\" to turn on and off permanent trail. Default is on")]
    float time;

    Transform dot;
    Transform dot2;
    float xOmega;
    float yOmega;

    
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        Continue = false;
        dot = Instantiate(dotPrefab);
        dot2 = Instantiate(dotPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        xOmega = 2*Mathf.PI* xFrequency;
        yOmega = 2*Mathf.PI* yFrequency;
        if (Input.GetKey(KeyCode.T))
        {
            dot2.gameObject.GetComponent<TrailRenderer>().time = 0;
        }
        else
        {
            dot2.gameObject.GetComponent<TrailRenderer>().time = Mathf.Infinity;
        }
        if(Continue) {
            time += Time.deltaTime;
            Debug.Log(xPos + " " + yPos);
            xPos = xAmplitude * Mathf.Sin(xOmega * time);
            yPos = yAmplitude * Mathf.Sin(yOmega * time + (deltaAngle * Mathf.Deg2Rad));

            dot.position = new Vector2(xPos, yPos);
            dot2.position = new Vector2(xPos, yPos);
        }
    }
}