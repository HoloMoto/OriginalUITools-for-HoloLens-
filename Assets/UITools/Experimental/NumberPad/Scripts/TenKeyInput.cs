using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TenKeyInput : MonoBehaviour
{
    [Serializable] public class MyEvent : UnityEvent<string> { }
    [SerializeField] MyEvent _tenKyeevent;

    [SerializeField] string _numberField;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //通常の数値を入力する。
    public void KeyInput(float number)
    {
        _numberField += number.ToString() ;
        _tenKyeevent.Invoke(_numberField);
    }
    //.やxなどの文字を入力するとき
    public void AtherKeyInput(string number)
    {
        _numberField += number;
        _tenKyeevent.Invoke(_numberField);
    }
    public void BackSpace()
    {
        int _num =_numberField.Length;
        Debug.Log(_num);
        string _newNumberField = _numberField.Remove(_num -1 );

        _numberField = _newNumberField;
        _tenKyeevent.Invoke(_numberField);
    }
    public void KeyEnter()
    {
        try
        {
            //整数の場合
            int num = int.Parse(_numberField);
            Debug.Log("整数です：" + num);
        }
        catch
        {
            //小数の場合
            float num = float.Parse(_numberField);
            Debug.Log("小数です：" + num);
        }

    }
}
