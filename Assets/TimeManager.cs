using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2f;
    public bool grappleActive = false;

    void Update()
    {
        if (grappleActive == false)
        {
            Time.timeScale += (0.5f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        }
    }

    public void doSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        //Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    public void doSlowTimeGrapple()
    {
        grappleActive = true;
        Time.timeScale = 0.8f;
    }

    public void stopSlowTimeGrapple()
    {
        grappleActive = false;
    }
}
