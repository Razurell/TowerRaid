using UnityEngine;
using UnityEngine.UI;

public class grapleGun : MonoBehaviour
{

    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatIsGrappleable;
    public Transform gunTip, camera, player;
    private float maxDistance = 100f;
    private SpringJoint joint;
    private bool grapped = false;
    private int grapState = 0;
    public Button grappleBtn;
    public TimeManager timeManager;

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        this.grappleBtn.onClick.AddListener(() => {
            this.buttonAction();
        });
    }

    void Update()
    {
        if (grapState == 1)
        {
            StartGrapple();
            timeManager.doSlowTimeGrapple();
        }
        else if (grapState == 2)
        {
            StopGrapple();
            timeManager.stopSlowTimeGrapple();
        }
        grapState = 0;
        //else if (!grapped)
        //{
        //    StopGrapple();
        //}
        //else if (!grapped)
        //{
        //    StopGrapple();
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    StartGrapple();
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
        //    StopGrapple();
        //}
    }

    void buttonAction()
    {
        if (!grapped)
        {
            //StartGrapple();
            grapped = true;
            grapState = 1;
        }
        else if (grapped)
        {
            //StopGrapple();
            grapped = false;
            grapState = 2;
            timeManager.doSlowMotion();
        }
    }

    //Called after Update
    void LateUpdate()
    {
        DrawRope();
    }

    /// <summary>
    /// Call whenever we want to start a grapple
    /// </summary>
    void StartGrapple()
    {
        RaycastHit hit; 
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            //The distance grapple will try to keep from grapple point. 
            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.25f;

            //Adjust these values to fit your game.
            joint.spring = 14f;
            joint.damper = 1f;
            joint.massScale = 2f;

            lr.positionCount = 2;
            currentGrapplePosition = gunTip.position;
        }
    }

    /// <summary>
    /// Call whenever we want to stop a grapple
    /// </summary>
    public void StopGrapple()
    {
        lr.positionCount = 0;
        Destroy(joint);
    }

    private Vector3 currentGrapplePosition;

    void DrawRope()
    {
        //If not grappling, don't draw rope
        if (!joint) return;

        currentGrapplePosition = Vector3.Lerp(currentGrapplePosition, grapplePoint, Time.deltaTime * 8f);

        lr.SetPosition(0, gunTip.position);
        lr.SetPosition(1, currentGrapplePosition);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
