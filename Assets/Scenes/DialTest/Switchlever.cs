using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.UI;

[RequireComponent(typeof(Interactable))]
[RequireComponent(typeof(InteractableReceiver))]
[RequireComponent(typeof(ManipulationHandler))]
public class Switchlever : MonoBehaviour
{
    //Event
    public UnityEvent OnUpdateRightAxisEvent;
    public UnityEvent OnUpdateLeftAxisEvent;
    public UnityEvent OnUpdateUpAxisEvent;
    public UnityEvent OnUpdateDownAxisEvent;

    //RereaseEvent
    public UnityEvent OnRereaseRightAxisEvent;
    public UnityEvent OnRereaseLeftAxisEvent;
    public UnityEvent OnRereaseUpAxisEvent;
    public UnityEvent OnRereaseDownAxisEvent;

    //min detect area (Radias)
    public float minRange;
    
    bool isActionEnebled = false;
    

    bool isUpdateupperAxisEventEnabled = true;
    bool isUpdatedownAxisEventEnabled = true;
    bool isUpdaterightAxisEventEnabled = true;
    bool isUpdateleftAxisEventEnabled = true;


    Vector3 positionalShift;
    
    private void Reset()
    {
        Interactable inte = this.gameObject.GetComponent<Interactable>();
        InteractableReceiver ire = this.gameObject.GetComponent<InteractableReceiver>();
        ire.Interactable = inte;       
    }

    public void Update()
    {
        if (isActionEnebled)
        {
            positionalShift = this.gameObject.transform.localPosition;

            //Absolute value of the target coordinates (local)
            float YAxisValue = System.Math.Abs(positionalShift.y);
            float XAxisValue = System.Math.Abs(positionalShift.x);

            //Y-axis input or not
            bool isYaxisInput = YAxisValue > XAxisValue;
            
            bool isYaxisPlus = positionalShift.y > 0;
            bool isXaxisPlus = positionalShift.x > 0;
            bool isYaxisDetection = YAxisValue > minRange;
            bool isXaxisDetection = XAxisValue > minRange;

           // Debug.Log(resultabsx);

            if (!isXaxisDetection && !isYaxisDetection)
            {
                //  UpdateStatus(false, false, false, false);
            }

            if (isYaxisInput && isYaxisPlus && isYaxisDetection)
            {
                if (isUpdateupperAxisEventEnabled)
                {
                    reslutUpperAxisEvent();
                }
            }

            if (isYaxisInput && !isYaxisPlus && isYaxisDetection)
            {
                if (isUpdatedownAxisEventEnabled)
                {
                    reslutDownAxisEvent();
                }
            }

            if (!isYaxisInput && isXaxisPlus && isXaxisDetection)
            {
                if (isUpdaterightAxisEventEnabled)
                {
                    reslutRightAxisEvent();
                }
            }

            if (!isYaxisInput && !isXaxisPlus && isXaxisDetection)
            {
                if (isUpdateleftAxisEventEnabled)
                {
                    resultLeftAxisEvent();
                }
            }
        }
    }

    void reslutRightAxisEvent()
    {
        OnUpdateRightAxisEvent.Invoke();
        isUpdaterightAxisEventEnabled = false;
        Debug.Log("RightEvent");
    }

    void resultLeftAxisEvent()
    {
        OnUpdateLeftAxisEvent.Invoke();
    }

    void reslutUpperAxisEvent()
    {
        OnUpdateUpAxisEvent.Invoke();
    }

    void reslutDownAxisEvent()
    {
        OnUpdateDownAxisEvent.Invoke();
    }
    /// <summary>
    /// Holdを検知します。MRTKのInteractableReceiverからイベントを実行します。
    /// </summary>
    public void leverHoldStat()
    {
        Debug.Log("leverActionStart");
        isActionEnebled = true;
    }
    /// <summary>
    /// MRTKのInteractableReceiverからイベントを実行します。
    /// </summary>
    public void leverHoldEnd()
    {
        Debug.Log("leverActionEnd");
        isActionEnebled = false;
        this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        isUpdateupperAxisEventEnabled = true;
        isUpdatedownAxisEventEnabled = true;
        isUpdaterightAxisEventEnabled = true;
        isUpdateleftAxisEventEnabled = true;
    }

}
