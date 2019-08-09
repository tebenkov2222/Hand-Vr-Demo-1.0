using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorGameObject : MonoBehaviour {
    [SerializeField]
    Color start;
    [SerializeField]
    Color end;
    [SerializeField]
    Color EmissionColor;
    Color currentColor;
    // Изменяйте эту интенсивность где угодно, хоть в Update, хоть из внешнего скрипта
    private float intensity = 2.04f;
    static float NormalIntensity = 2.04f;
    public GameObject FaceThis;
    private bool Active = false;
    Vector3 PastPosition;
    private byte alpha = 0;
	// Use this for initialization
	void Start () {
        PastPosition = transform.position;
        currentColor = start;
    }
	public void InstantiatedObject()
    {
        Active = true;
        Color baseColor = Color.red; //Replace this with whatever you want for your base color at emission level '1'

        Color finalColor = baseColor * intensity;
        FaceThis.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", finalColor);
    }
    private float PPongFlaot = 0;
	// Update is called once per frame
    void FixedUpdate () {
		if (Active)
        {
            Color currentColor = Color.Lerp(start, end, PPongFlaot);
            Color finalColor = EmissionColor * intensity;
            FaceThis.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", finalColor);
            Color32 StColor = this.GetComponent<MeshRenderer>().material.color;
            FaceThis.GetComponent<MeshRenderer>().material.color = currentColor;
            this.GetComponent<MeshRenderer>().material.color = new Color32(StColor.r, StColor.g, StColor.b, alpha);
             if (alpha <255) alpha += 5;
            if (intensity > 0) intensity = intensity - 0.04f;
            if (PPongFlaot != 1) PPongFlaot = PPongFlaot + (1f / 51f);
        }
        if (Mathf.Abs(this.transform.position.x - PastPosition.x) > 0.01f
    || Mathf.Abs(this.transform.position.y - PastPosition.y) > 0.01f
    || Mathf.Abs(this.transform.position.z - PastPosition.z) > 0.01f)
        {
            intensity = NormalIntensity;
;
            PastPosition = transform.position;
        }
    }

}
