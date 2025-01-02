using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float radius = 5;
    [Range(1,360)]public float angle = 90;
    public LayerMask targetLayer;
    public LayerMask obstructionLayer;
    public GameObject playerRef;

    public bool CanSeePlayer { get; private set; }
    public GameObject LookingAt { get; private set; }

    private void Update()
    {
        FOV();
    }

    private void FOV()
    {
        Collider2D[] rangeCheck = Physics2D.OverlapCircleAll(transform.position, radius, targetLayer);

        if (rangeCheck.Length > 1)
        {
            bool found = false;
            for (int i = 0; i < rangeCheck.Length; i++)
            {
                if (rangeCheck[i].name != gameObject.name)
                {
                    Transform target = rangeCheck[i].transform;
                    Vector2 directionToTarget = (target.position - transform.position).normalized;

                    if (Vector2.Angle(transform.up, directionToTarget) < angle / 2)
                    {
                        float distanceToTarget = Vector2.Distance(transform.position, target.position);

                        if (!Physics2D.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionLayer))
                        {
                            CanSeePlayer = true;
                            LookingAt = rangeCheck[i].gameObject;
                            found = true;
                        }
                    }
                }                
            }
            if (!found)
                CantSee();
        }
        else if (CanSeePlayer)
            CantSee();
    }

    private void CantSee()
    {
        CanSeePlayer = false;
        LookingAt = null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.forward, radius);

        Vector3 angle1 = DirectionFromAngle(-transform.eulerAngles.z, -angle / 2);
        Vector3 angle2 = DirectionFromAngle(-transform.eulerAngles.z, angle / 2);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + angle1 * radius);
        Gizmos.DrawLine(transform.position, transform.position + angle2 * radius);
    }

    private Vector2 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
