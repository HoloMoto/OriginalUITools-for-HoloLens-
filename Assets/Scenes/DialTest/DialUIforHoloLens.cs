using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;

public class DialUIforHoloLens: MonoBehaviour
{
    //target interactable.cs
    Interactable inter;

    //Action On/Off
    bool _ActionEnebled;
    //transform
    Vector3 dpos;

    public Theme InteractableStates;

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

            
            bool result = System.Math.Abs(dpos.y) > System.Math.Abs(dpos.x);
            bool resulty = dpos.y>0;
            bool resultx = dpos.x> 0;
               if(result && resulty)
               {
                     Result_Yp();
               }
               if (result && !resulty)
               {
                    Result_Ym();
               }
               if (!result && resultx)
               {
                    Result_Xp();
               }
               if(!result && !resultx )
               {
                    Result_Xm();
               }
            


        }

    }

    void Result_Yp()
    {
        Debug.Log("Y Axis");
    }
    void Result_Ym()
    {
        Debug.Log("-Y Axis");
    }
    void Result_Xp()
    {
        Debug.Log("X Axis");
    }
    void Result_Xm()
    {
        Debug.Log("-X Axis");
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