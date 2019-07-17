using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstScript : MonoBehaviour {
	public GameObject  Empty1, Empty2, InstObject;
	public Vector3 InstObjectPosition;
	private float InstObjectScale, mousex, mousey, mousexnormal, mouseynormal;
    private GameObject inst;
    public float Rotx, Roty, Rotz;
    private float RotxP, RotyP, RotzP;
    // Use this for initialization
    void Start () {
		InstObjectPosition = new Vector3((Empty1.transform.position.x + Empty2.transform.position.x) / 2, (Empty1.transform.position.y + Empty2.transform.position.y) / 2, (Empty1.transform.position.z + Empty2.transform.position.z) / 2);
		InstObjectScale = Mathf.Sqrt(
			(Empty1.transform.position.x - Empty2.transform.position.x) * (Empty1.transform.position.x - Empty2.transform.position.x) +
			(Empty1.transform.position.y - Empty2.transform.position.y) * (Empty1.transform.position.y - Empty2.transform.position.y) +
			(Empty1.transform.position.z - Empty2.transform.position.z) * (Empty1.transform.position.z - Empty2.transform.position.z)
		);
        inst = Instantiate(InstObject, InstObjectPosition, Quaternion.identity);
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale);
        mousexnormal = Input.mousePosition.x;
        mouseynormal = Input.mousePosition.y;
    }
	
	// Update is called once per frame
	void Update () {
        InstObjectPosition = new Vector3((Empty1.transform.position.x + Empty2.transform.position.x) / 2, (Empty1.transform.position.y + Empty2.transform.position.y) / 2, (Empty1.transform.position.z + Empty2.transform.position.z) / 2);
        InstObjectScale = Mathf.Sqrt(
            (Empty1.transform.position.x - Empty2.transform.position.x) * (Empty1.transform.position.x - Empty2.transform.position.x) +
            (Empty1.transform.position.y - Empty2.transform.position.y) * (Empty1.transform.position.y - Empty2.transform.position.y) +
            (Empty1.transform.position.z - Empty2.transform.position.z) * (Empty1.transform.position.z - Empty2.transform.position.z)
        );
        if (Rotx != RotxP)
        {
            inst.transform.Rotate(Rotx-RotxP, 0, 0);
            Rotx = RotxP;
        }
        if (Roty != RotyP)
        {
            inst.transform.Rotate(0, Roty - RotyP, 0);
            Roty = RotyP;
        }
        if (Rotz != RotzP)
        {
            inst.transform.Rotate(0, 0, Rotz - RotzP);
            Rotz = RotzP;
        }
        //else arctg = 0;

        inst.transform.position = InstObjectPosition;
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale);
        mousex = Input.mousePosition.x;
        //Empty1.transform.position = new Vector3((mousex - mousexnormal) / 15 , 0, 0);
        mousey = Input.mousePosition.y;
        //Empty2.transform.position = new Vector3((mousey - mouseynormal) / 15 , 0, 0);
    }
}
