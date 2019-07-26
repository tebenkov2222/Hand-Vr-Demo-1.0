using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScriptInst : MonoBehaviour {
    Quaternion originQuternion;
	// Use this for initialization
	void Start () {
        originQuternion = transform.rotation;

    }
    public void RotationInst(Vector3 point1, Vector3 point2)
    {
        transform.rotation = Quaternion.LookRotation(point1, point2);
    }
}
