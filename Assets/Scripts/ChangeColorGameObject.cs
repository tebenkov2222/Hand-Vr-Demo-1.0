﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorGameObject : MonoBehaviour {
    [SerializeField]
    Color start;
    [SerializeField]
    Color end;
    
    // Изменяйте эту интенсивность где угодно, хоть в Update, хоть из внешнего скрипта
    private float intensity = 1000f;
    public GameObject FaceThis;
    private bool Active = false;
    Vector3 PastPosition;
    private byte alpha = 0;
	// Use this for initialization
	void Start () {
        PastPosition = transform.position;

    }
	public void InstantiatedObject()
    {
        Active = true;
        Color baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * intensity;
        FaceThis.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", finalColor);
    }
	// Update is called once per frame
	void Update () {
		if (Active)
        {
            Color baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'

            Color finalColor = baseColor * intensity;
            FaceThis.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", finalColor);
            Color32 StColor = this.GetComponent<MeshRenderer>().material.color;
            this.GetComponent<MeshRenderer>().material.color = new Color32(StColor.r, StColor.g, StColor.b, alpha);
             if (alpha <255) alpha += 15;
            if (intensity > 400) intensity = intensity - 300;
            else
            {
                if (intensity > 100) intensity = intensity - 100;
                else {
                    if (intensity > 40) intensity = intensity - 30;
                    else if (intensity > 1) intensity = intensity - 1;
                }
            }
        }
        if (Mathf.Abs(this.transform.position.x - PastPosition.x) > 0.01f)
        {
            intensity = 20;
            PastPosition = transform.position;
        }
        if (Mathf.Abs(this.transform.position.y - PastPosition.y) > 0.01f)
        {
            intensity = 20;
            PastPosition = transform.position;
        }
        if (Mathf.Abs(this.transform.position.z - PastPosition.z) > 0.01f)
        {
            intensity = 20;
            PastPosition = transform.position;
        }
    }
}
