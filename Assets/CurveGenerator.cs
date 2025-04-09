using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LissajousCurve : MonoBehaviour
{
    public static LissajousCurve Instance;
    public Transform dotPrefab; // The prefab of the dot
    public double xAmplitude = 3;
    public double xFrequency = 0.2f;
    public double yAmplitude = 3;
    public double yFrequency = 0.4f;
    public double xOffset = -3;
    public double yOffset;
    public double deltaAngle; // In degrees
    public bool Continue; // whether to continue going;
    public double xPos;
    public double yPos;
    [Tooltip("You can press \"T\" to turn on and off permanent trail. Default is on")]
    double time;

    Transform dot;
    Transform dot2;
    double xOmega;
    double yOmega;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        time = 0;
        Continue = true;
        xAmplitude = 3;
        yAmplitude = 3;
        xFrequency = 0.2f;
        yFrequency = 0.4f;
        xOffset = -3;
        dot = Instantiate(dotPrefab);
        dot2 = Instantiate(dotPrefab);
    }

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
            xPos = xOffset + xAmplitude * Mathf.Sin((float)xOmega * (float)time);
            yPos = yOffset + yAmplitude * Mathf.Sin((float)yOmega * (float)time + ((float)deltaAngle * Mathf.Deg2Rad));

            dot.position = new Vector2((float)xPos, (float)yPos);
            dot2.position = new Vector2((float)xPos, (float)yPos);
        }
    }
}