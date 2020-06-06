using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.UI;

[RequireComponent(typeof(Interactable))]
public class DialUIforHoloLens: MonoBehaviour
{
    /// <summary>
    /// The event that occurs when the target is moved to the right
    /// </summary>
    public UnityEvent OnUpdateRightAxisEvent;

    public UnityEvent OnUpdateLeftAxisEvent;

    public UnityEvent OnUpdateUpAxisEvent;

    public UnityEvent OnUpdateDownAxisEvent;
    //target interactable.cs
    Interactable inter;

    /// <summary>
    /// Radius to recognize the input
    /// </summary>
    [SerializeField, TooltipAttribute("Radius to recognize the input")]
    [Range(0,1)]
    public float MinRange = 0.3f;

    public float MaxRange = 1.0f;
    //Action On/Off
    bool _ActionEnebled;
    bool _OnUpdaterightAxisEvent =true;
    bool _OnUpdateleftAxisEvent = true;
    bool _OnUpdateupperAxisEvent = true;
    bool _OnUpdatedownAxisEvent = true;
   //transform
   Vector3 dpos;
    

    private void Start()
    {
        inter = this.gameObject.GetComponent<Interactable>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_ActionEnebled)
        {
            dpos = this.gameObject.transform.localPosition;
            // x axis input is pluse value 

            float yaxisparm = System.Math.Abs(dpos.y);
            float xaxisparm = System.Math.Abs(dpos.x);

            bool result = System.Math.Abs(dpos.y) > System.Math.Abs(dpos.x);
            bool resulty = dpos.y>MinRange;
            bool resultx = dpos.x> MinRange;
   
               if(!resultx && !resulty)
               {
                  return;
               }

               if(result && resulty)
               {
                     Result_Yp(yaxisparm);
                if (_OnUpdateupperAxisEvent)
                {
                    reslutUpperAxisEvent();
                    _OnUpdateupperAxisEvent = false;
                }
            }

               if (result && !resulty)
               {
                    Result_Ym(yaxisparm);
                if (_OnUpdatedownAxisEvent)
                {
                    reslutDownAxisEvent();
                    _OnUpdatedownAxisEvent = false;
                }
            }

               if (!result && resultx)
               {
                    Result_Xp(xaxisparm);
                if (_OnUpdaterightAxisEvent) 
                {
                    reslutRightAxisEvent();
                    _OnUpdaterightAxisEvent = false;
                }
               }

               if(!result && !resultx )
               {
                    Result_Xm(xaxisparm);
                if (_OnUpdateleftAxisEvent)
                {
                    resultLeftAxisEvent();
                    _OnUpdateleftAxisEvent = false;
                }
               }          
        }

    }

    void Result_Yp(float yaxis)
    {
        //Debug.Log("Y Axis");  
    }
    void Result_Ym(float yaxis)
    {
        //Debug.Log("-Y Axis");
    }
    void Result_Xp(float xaxis)
    {
        //Debug.Log("X Axis");
    }
    void Result_Xm(float xaxis)
    {
       // Debug.Log("-X Axis");
    }

    /// <summary>
    /// 
    /// </summary>
    void reslutRightAxisEvent()
    {
        Debug.Log("Right");
        OnUpdateRightAxisEvent.Invoke();
    }
    /// <summary>
    /// 
    /// </summary>
    void resultLeftAxisEvent()
    {
        Debug.Log("Left");
        OnUpdateLeftAxisEvent.Invoke();
    }

    void reslutUpperAxisEvent()
    {
        Debug.Log("Up");
        OnUpdateUpAxisEvent.Invoke();
    }

    void reslutDownAxisEvent()
    {
        Debug.Log("Down");
        OnUpdateDownAxisEvent.Invoke();
    }

    /// <summary>
    /// 移動中に呼びたいヤツ
    /// </summary>
    public void PointerAnimationStat()
    {
        Debug.Log("pointerAnimationStart");
        _ActionEnebled = true;
    }
    /// <summary>
    /// 
    /// </summary>
    public void PointerAnimationEnd()
    {
        Debug.Log("pointerAnimationEnd");
        _ActionEnebled = false;
        //Reset trigger
        _OnUpdaterightAxisEvent = true;
        _OnUpdateleftAxisEvent = true;
    }
    /// <summary>
    /// This method call by ManipulationHundeler OnManiputationEnded.
    /// </summary>
    public void PointerReset()
    {
        //Pointer Transform Reset
        Debug.Log("PointerReset");
        this.gameObject.transform.localPosition = new Vector3(0, 0, 0);
        this.gameObject.transform.localRotation = new Quaternion(1, 0, 0, 1);
    }
}