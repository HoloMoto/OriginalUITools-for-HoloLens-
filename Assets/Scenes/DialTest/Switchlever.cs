using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchlever : MonoBehaviour
{
    //Hold Status
    public bool _ActionEnebled = false;

    public void leverHoldStat()
    {
        Debug.Log("leverActionStart");
        _ActionEnebled = true;
    }
    public void leverHoldEnd()
    {
        Debug.Log("leverActionEnd");
        _ActionEnebled = false;
    }

}
