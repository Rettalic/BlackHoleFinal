using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlanet : MonoBehaviour
{
    public ScaleFromMic mic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Destruct"))
        {
            mic.scaleIncrease *= 1.3f;
            Destroy(other.gameObject);

        }
    }
}
