using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayAway : MonoBehaviour
{
    public float speed;
    public float minimumDistance;
    public Transform target;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < minimumDistance)
        {
            // walk away
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }
    }
}

/*
    
*/