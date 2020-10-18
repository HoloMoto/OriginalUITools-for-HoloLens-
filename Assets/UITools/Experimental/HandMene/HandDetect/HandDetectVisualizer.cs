using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Utilities;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.OpenVR.Headers;

public class HandDetectVisualizer : MonoBehaviour
{

    [SerializeField, HeaderAttribute("DetectTargetHand")]
    HandMode HandDetectMode;

    Handedness handednesstype;

    Vector3 posepos;

    Quaternion poserote;

    [SerializeField]
    GameObject UIObject;

    [SerializeField]
    bool isDetect = false;

    [SerializeField]
    GameObject CameraObject;
    Transform CameraTrans;

    [SerializeField]
    GameObject _areaVisualizerObject;
    [SerializeField]
    GameObject targetObject;
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
        if ((int)HandDetectMode == 1)
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
            if (!isDetect)
            {
                isDetect = true;

            }
            posepos = pose.Position;
            poserote = pose.Rotation;
        }
        else
        {
            if (isDetect)
            {
                Debug.Log(pose);
                isDetect = false;
                GameObject Obj = (GameObject)Instantiate(_areaVisualizerObject, posepos,poserote);
                Obj.transform.parent = targetObject.transform;
            }
        }
    }

}
