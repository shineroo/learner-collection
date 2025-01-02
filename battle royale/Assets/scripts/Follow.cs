using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public float speed;
    public float minimumDistance;
    public Transform target;
    public Rigidbody2D rb;

    private Vector3 mousePosition;
    private Vector3 worldPosition;

    // Update is called once per frame
    void Update()
    {
        if(target == null) // if no target has been selected, follow the cursor
        {
            mousePosition = Input.mousePosition;
            mousePosition.z = Camera.main.nearClipPlane;
            worldPosition = Camera.main.ScreenToWorldPoint(mousePosition); // some bullshit about converting screen position to world position

            if (Vector2.Distance(transform.position, worldPosition) > minimumDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, worldPosition, speed * Time.deltaTime);
            }
        }
        else // follow target
        {
            if (Vector2.Distance(transform.position, target.position) > minimumDistance)
            {
                // walk
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

                // look
                Vector2 lookdir = target.position - transform.position;
                float angle = Mathf.Atan2(lookdir.y, lookdir.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
            }
        }
    }
}
