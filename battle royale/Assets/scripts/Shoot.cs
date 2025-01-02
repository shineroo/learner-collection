using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    Sight sight;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        sight = GetComponent<Sight>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(sight.CanSeePlayer == true)
        {
            spriteRenderer.color = new Color32(0, 124, 0, 255);
        }
        else
            spriteRenderer.color = new Color32(255, 124, 124, 255);

    }

    /*void Fire()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(firePoint.position, worldPosition);

        if (hitinfo)
        {

        }
    }*/
}
