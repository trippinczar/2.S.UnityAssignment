using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    // Initial position of background
    private float startPos, length;
    public GameObject cam; // Camera
    public float parallaxEffect; // The speed at which the background should move relative to the camera
    
    // Start is called before the first frame update
    void Start()
    {
        //Only moves horizontally
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // FixedUpdate to remove parallax jitter
    void FixedUpdate()
    {
        // Calculate distance background move based on cam movement
        float distance = cam.transform.position.x * parallaxEffect; 
        // The lower the parallax effect the faster it will move with the cam
        // 0 = move with cam || 1 = won't move || 0.5 = half
        float movement = cam.transform.position.x * (1 - parallaxEffect);

        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        // If background has reached the end of its length, adjust its position for infinite scrolling
        if (movement > startPos + length)
        {
            startPos += length;
        }
        else if (movement < startPos - length)
        {
            startPos -= length;
        }
    }
}
