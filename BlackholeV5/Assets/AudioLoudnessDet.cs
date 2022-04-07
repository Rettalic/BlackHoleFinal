using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessDet : MonoBehaviour
{

    public int sampleWindow = 64;
    private AudioClip microPhoneClip;
 

    // Start is called before the first frame update
    void Start()
    {
        MicToAudioClip();
    }

    public void MicToAudioClip()
    {
        //get Mic in device List
        string micName = Microphone.devices[0];

        microPhoneClip = Microphone.Start(micName, true, 20, AudioSettings.outputSampleRate);
    }

    public float GetLoudnessFromMicrophone()
    {
        return GetLoudNessFromAudio(Microphone.GetPosition(Microphone.devices[0]), microPhoneClip);
    }

    public float GetLoudNessFromAudio(int clipPosition, AudioClip clip)
    {
        int startPosition = clipPosition - sampleWindow;

        if(startPosition < 0)
        {
            return 0;
        }

        float[] waveDate = new float[sampleWindow];
        clip.GetData(waveDate, startPosition);

        //compute the loudness
        float totalLoudNess = 0;

        for (int i = 0; i < sampleWindow; i++)
        {
            totalLoudNess += Mathf.Abs(waveDate[i]);
        }

        return totalLoudNess/sampleWindow;

    }
}
