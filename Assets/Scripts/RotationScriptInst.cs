using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationScriptInst : MonoBehaviour {
    Quaternion originQuternion;
	// Use this for initialization
	void Start () {
        originQuternion = transform.rotation;

    }
    public void RotationInst(float RotX,float RotY,float RotZ)
    {
        // преобразоывание градусов в эйлеры
        Quaternion RotYQuat = Quaternion.AngleAxis(RotY, Vector3.up);
        Quaternion RotXQuat = Quaternion.AngleAxis(RotX, Vector3.right);
        Quaternion RotZQuat = Quaternion.AngleAxis(RotZ, Vector3.forward);
        // преобразоывание градусов в эйлеры \\
        //this.transform.rotation = originQuternion * RotXQuat * RotYQuat * RotZQuat; // использую эйлеры
        this.transform.rotation = Quaternion.Euler(RotX, RotY, RotZ); // использую градусы
    }
}
