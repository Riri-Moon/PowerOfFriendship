using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.LWRP;


public class blikanie : MonoBehaviour
{
    public Transform other;
    public float DesiredDistance;
    public Rigidbody2D body;
    [Tooltip("External light to flicker; you can leave this null if you attach script to a light")]
    private new Light2D light;
    [Tooltip("Minimum random light intensity")]
    public float minIntensity = 0f;
    [Tooltip("Maximum random light intensity")]
    public float maxIntensity = 1f;
    [Tooltip("How much to smooth out the randomness; lower values = sparks, higher = lantern")]
    [Range(1, 50)]
    public int smoothing = 5;
    private new AudioSource audio;
    public float DecreaseIntensity;

    // Continuous average calculation via FIFO queue
    // Saves us iterating every time we update, we just change by the delta
    Queue<float> smoothQueue;
    float lastSum = 0;

   
    /// <summary>
    /// Reset the randomness and start again. You usually don't need to call
    /// this, deactivating/reactivating is usually fine but if you want a strict
    /// restart you can do.
    /// </summary>
    public void Reset()
    {
        smoothQueue.Clear();
        lastSum = 0;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
        smoothQueue = new Queue<float>(smoothing);
        // External or internal light?
        if (light == null)
        {
            light = GetComponent<Light2D>();
        }
    }

    void Update()
    {

        float dist = Vector3.Distance(body.transform.position, other.transform.position);

        if (DesiredDistance < dist)
        {
            audio.volume = audio.volume - DecreaseIntensity;
        }
        else audio.volume = 0.1f;


        if (light == null)
            return;

        // pop off an item if too big
        
        while (smoothQueue.Count >= smoothing)
        {
            lastSum -= smoothQueue.Dequeue();
        }

        // Generate random new item, calculate new average
        float newVal = Random.Range(minIntensity, maxIntensity);
        smoothQueue.Enqueue(newVal);
        lastSum += newVal;

        // Calculate new smoothed average
        light.intensity = lastSum / (float)smoothQueue.Count;
    }

}
