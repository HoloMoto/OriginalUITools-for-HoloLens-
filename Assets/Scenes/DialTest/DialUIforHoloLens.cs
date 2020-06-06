using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.UI;

[RequireComponent(typeof(Interactable))]
public class DialUIforHoloLens: MonoBehaviour
{
    [Header("OnUpdateEvent")]
    /// <summary>
    /// The event that occurs when the target is moved to the right
    /// </summary>
    public UnityEvent OnUpdateRightAxisEvent;

    public UnityEvent OnUpdateLeftAxisEvent;

    public UnityEvent OnUpdateUpAxisEvent;

    public UnityEvent OnUpdateDownAxisEvent;

    [Header("OnRereasedEvent")]

    public UnityEvent OnRereasedRightAxisEvent;

    public UnityEvent OnRereasedLeftAxisEvent;

    public UnityEvent OnRereasedUpAxisEvent;

    public UnityEvent OnRereasedDownAxisEvent;

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
    //Action States
    bool _Updatexp =false;
    bool _Updateyp = false;
    bool _Updatexm = false;
    bool _Updateym = false;
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
                UpdateStatus(false, false, false, false);
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
        UpdateStatus(true,false,false,false);
    }
    void Result_Ym(float yaxis)
    {
        UpdateStatus(false, true, false, false);
    }
    void Result_Xp(float xaxis)
    {
        UpdateStatus(false, false, true, false);
    }
    void Result_Xm(float xaxis)
    {
        UpdateStatus(false, false, false, true);
    }
    /// <summary>
    /// 現在のアクションのステータスをbool型で格納
    /// </summary>
    /// <param name="yp">Y＝up</param>
    /// <param name="ym">-Y=down</param>
    /// <param name="xp">x=right</param>
    /// <param name="xm">-x=left</param>
    void UpdateStatus(bool yp,bool ym,bool xp,bool xm)
    {
         _Updateyp = yp;
         _Updateym = ym;
         _Updatexp = xp;
         _Updatexm = xm;
    }
    /// <summary>
    /// 
    /// </summary>
    void reslutRightAxisEvent()
    {
        //Debug.Log("Right");
        OnUpdateRightAxisEvent.Invoke();
    }
    /// <summary>
    /// 
    /// </summary>
    void resultLeftAxisEvent()
    {
        //Debug.Log("Left");
        OnUpdateLeftAxisEvent.Invoke();
    }

    void reslutUpperAxisEvent()
    {
        //Debug.Log("Up");
        OnUpdateUpAxisEvent.Invoke();
    }

    void reslutDownAxisEvent()
    {
       // Debug.Log("Down");
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
        if (_Updateyp)
        {
            OnRereasedUpAxisEvent.Invoke();
        }
        if (_Updateym)
        {
            OnRereasedDownAxisEvent.Invoke();
        }
        if (_Updatexp)
        {
            OnRereasedRightAxisEvent.Invoke();
        }
        if (_Updatexm)
        {        
            OnRereasedLeftAxisEvent.Invoke();
        }
        //Reset trigger
        _OnUpdaterightAxisEvent = true;
        _OnUpdateleftAxisEvent = true;
        _OnUpdateupperAxisEvent = true;
        _OnUpdatedownAxisEvent = true;
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