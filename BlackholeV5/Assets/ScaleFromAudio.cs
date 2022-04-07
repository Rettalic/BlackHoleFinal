using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleFromAudio : MonoBehaviour
{
    public AudioSource source;
    public Vector3 minScale;
    public Vector3 maxScale;

    public AudioLoudnessDet detector;

    public float loudnessSensibility = 100;
    public float threshhold = 0.1f;

    void Update()
    {
        float loudness = detector.GetLoudNessFromAudio(source.timeSamples, source.clip) *loudnessSensibility;

        if(loudness < threshhold)
        {
            loudness = 0;
        }

        //lerp value from min to max scale
        transform.localScale = Vector3.Lerp(minScale, maxScale, loudness);
    }
}
