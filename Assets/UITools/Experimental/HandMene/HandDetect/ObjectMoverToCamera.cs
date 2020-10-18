using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoverToCamera : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    [SerializeField]
    GameObject homingObj;
    public float Speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(Player.transform.position.x, Player.transform.position.y,Player.transform.position.z), Speed * Time.deltaTime);
        this.transform.rotation = new Quaternion(Player.transform.localRotation.x, Player.transform.localRotation.y, Player.transform.localRotation.z, Player.transform.localRotation.w);
    }
}
