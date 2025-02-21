using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Sight : MonoBehaviour
{

    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] colliders= Physics.OverlapSphere(transform.position, distance, objectsLayers);

        detectedObject = null;

        for (int i = 0; i < colliders.Length; i++)
        {
            Collider collider = colliders[i];
        
            Vector3 dirToController = Vector3.Normalize(collider.bounds.center - transform.position);

            float angleToCollider = Vector3.Angle(transform.forward, dirToController);

            if (angleToCollider < angle) {
                if (!Physics.Linecast(transform.position, collider.bounds.center, obstaclesLayers))
                {
                    detectedObject = collider;
                    break;
                }
            }
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);

        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);

     
        if (detectedObject != null)
        {
            float angleToCollider = Vector3.Angle(transform.forward, (detectedObject.bounds.center - transform.position).normalized);

            if (angleToCollider < angle)
            {
                if (!Physics.Linecast(transform.position, detectedObject.bounds.center, obstaclesLayers))
                {
                    Debug.DrawLine(transform.position, detectedObject.bounds.center, Color.green);
                }
            }

          
            if (!Physics.Linecast(transform.position, detectedObject.bounds.center, out RaycastHit hit, obstaclesLayers))
            {
                Debug.DrawLine(transform.position, detectedObject.bounds.center, Color.green);
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.red);
            }
        }
    }
}

