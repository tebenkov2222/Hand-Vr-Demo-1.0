using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScriptInst : MonoBehaviour {
	// Use this for initialization
	void Start () {

    }
    public void RotationInst(Vector3 point1, Vector3 point2)
    {
        transform.rotation = Quaternion.LookRotation(point1, point2);
    }
}
