using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slipper : MonoBehaviour
{
    public KeyCode leftInput;
    public KeyCode rightInput;

    public float targetPressed;
    public float targetRelease;

    public HingeJoint hingeLeft;
    public HingeJoint hingeRight;

    private JointSpring jointLeft;
    private JointSpring jointRight;

    // Start is called before the first frame update
    void Start()
    {
        targetPressed = hingeLeft.limits.max;
        targetRelease = hingeLeft.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        SlipperMovement();
    }

    public void SlipperMovement()
    {
        jointLeft = hingeLeft.spring;
        jointRight = hingeRight.spring;

        if (Input.GetKey(leftInput))
        {
            jointLeft.targetPosition = targetPressed;
        }
        else
        {
            jointLeft.targetPosition = targetRelease;
        }

        if (Input.GetKey(rightInput))
        {
            jointRight.targetPosition = targetPressed;
        }
        else
        {
            jointRight.targetPosition = targetRelease;
        }

        hingeLeft.spring = jointLeft;
        hingeRight.spring = jointRight;
    }
}
