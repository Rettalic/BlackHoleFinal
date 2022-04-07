using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromMic : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;

    public float scaleIncrease =1;

    public AudioLoudnessDet detector;

    public float loudnessSensibility = 100;
    public float threshhold = 0.1f;
    private Vector3 targetScale;
    public float scaleSpeed = 1;

    public float loud;

    public bool attract;

    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;
        loud = loudness;
        if (loudness < threshhold)
        {
            loudness = 0;
        }

        //lerp value from min to max scale
        targetScale          = Vector3.Lerp(minScale,             maxScale,    loudness);
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, scaleSpeed);

        if(loudness >= 0.5f)
        {
            attract = true;
        }
        else
        {
            attract = false;
        }

    }
}
