using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.OpenVR.Headers;
/// <summary>
/// This class detects the HoloLens 2's HandTracking joints.
/// </summary>
public class HandDetector : MonoBehaviour
{

    [SerializeField, HeaderAttribute("DetectTargetHand")]
    HandMode HandDetectMode;

    Handedness handednesstype;

    [SerializeField, Range(0, 1)]
    float DetectRangeMin;

    [SerializeField, Range(0, 1)]
    float DetectRangeMax;

    [SerializeField]
    GameObject UIObject;

    [SerializeField]
    GameObject CameraObject;
    Transform CameraTrans;
    enum HandMode
    {
        RightHand,
        LeftHand,
        BothHand,
    }

    // Start is called before the first frame update
    void Start()
    {
        CameraObject = GameObject.Find("Main Camera");
        //DetectRighitHandWrist
        if ((int)HandDetectMode == 0)
        {
            handednesstype = Handedness.Right;
        }
        //DetectLeftHandWrist
        if ((int)HandDetectMode ==1)
        {
            handednesstype = Handedness.Left;
        }
        //DetectBothHandWrist
        if ((int)HandDetectMode == 2)
        {
            handednesstype = Handedness.Both;
        }
        Debug.Log(handednesstype);
    }

    // Update is called once per frame
    void Update()
    {
        CameraTrans = CameraObject.transform;
        //DetectRighitHandWrist
        if (HandJointUtils.TryGetJointPose(TrackedHandJoint.Palm, handednesstype, out MixedRealityPose pose))
        { 
            float localrotx =CameraTrans.transform.rotation.eulerAngles.x -pose.Rotation.eulerAngles.x;
            float localroty = CameraTrans.transform.rotation.eulerAngles.y - pose.Rotation.eulerAngles.y;
            float localrotz = CameraTrans.transform.rotation.eulerAngles.z - pose.Rotation.eulerAngles.z;

            float localposx = CameraTrans.transform.position.x - pose.Position.x;
            float localposy = CameraTrans.transform.position.y - pose.Position.y;
            float localposz = CameraTrans.transform.position.z - pose.Position.z;
            UIObject.transform.localPosition = new Vector3(pose.Position.x, pose.Position.y,pose.Position.z);
            UIObject.transform.localRotation = new Quaternion(pose.Rotation.x,pose.Rotation.y,pose.Rotation.z,pose.Rotation.w);
            //Debug.Log(new Vector3(localposx, localposy, localposz));
            //Debug.Log(new Vector3(localrotx,localroty,localrotz));
            bool c =  localrotx > DetectRangeMin;
            Debug.Log(c);
        }
        
    }

}
