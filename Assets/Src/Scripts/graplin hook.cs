using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour
{
    private LineRenderer lr;
    private Vector3 pos;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera;

    void awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartGraple();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopGraple();
        }
    }

    void StartGraple()
    {

    }

    void StopGraple()
    {

    }
}
