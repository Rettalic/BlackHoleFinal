using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SuckObjects : MonoBehaviour
{
    public float attractRange;
    public float attractStrength;
    public LayerMask attractedTo;
    public Rigidbody rb;
    public float attractStartSpeed;
    public float AttractMaxSpeed;
    public AnimationCurve velocityCurve;
    public float accelerationSpeed;

    float s;
    float varSpeed;

    GameObject target;
    RaycastHit[] hits;

    public ScaleFromMic scaleMic;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        hits = Physics.SphereCastAll(transform.position, attractRange, transform.forward, 0.01f, attractedTo);

        if(hits.Length < 1)
        {
            s = 0;
            return;
        }

        List<float> ranges = new List<float>();
        foreach (var item in hits)
        {
            ranges.Add(Vector3.Distance(item.transform.position, transform.position));
        }
        if(ranges.Count < 1)
        {
            s = 0;
            return;
        }

            target = hits[ranges.IndexOf(ranges.Min())].collider.gameObject;
            Vector3 dir = target.transform.position - transform.position;

        if (scaleMic.attract)
        {
            s += Time.deltaTime * accelerationSpeed;
            varSpeed = Mathf.Lerp(attractStartSpeed, AttractMaxSpeed, velocityCurve.Evaluate(s / 1f));
            rb.velocity = dir.normalized * varSpeed;
        }
    }
}
