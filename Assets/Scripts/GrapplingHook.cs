using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingHook : MonoBehaviour
{
    DistanceJoint2D theDistanceJoint;
    Vector3 targetPosition;
    RaycastHit2D hit;
    public float maxGrappleDistance = 10f;
    public LayerMask mask;
    public float maxHoldTime;
    private float holdTimeCounter;
    public float holdTimeDecreaseRate;

    // Start is called before the first frame update
    void Start()
    {
        theDistanceJoint = GetComponent<DistanceJoint2D>();
        theDistanceJoint.enabled = false;
        holdTimeCounter = maxHoldTime;
    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            holdTimeCounter -= holdTimeDecreaseRate * Time.fixedDeltaTime;
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition.z = 0f;

            hit = Physics2D.Raycast(transform.position, targetPosition - transform.position);

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.GetComponent<Rigidbody2D>() + " has been hit by the raycast");
                theDistanceJoint.enabled = true;
                theDistanceJoint.connectedAnchor = targetPosition;
                theDistanceJoint.distance = Vector2.Distance(transform.position, hit.point);
            }
        }


        if (Input.GetKeyUp(KeyCode.E))
        {
            theDistanceJoint.enabled = false;
            holdTimeCounter = maxHoldTime;
        }
    }
}
