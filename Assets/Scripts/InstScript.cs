using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstScript : MonoBehaviour {
	public GameObject  Empty1, Empty2, InstObject;
	public Vector3 InstObjectPosition;
	private float InstObjectScale, mousex, mousey, mousexnormal, mouseynormal;
    private GameObject inst;
    public float Rotx, Roty, Rotz, CosX, CosY, CosZ;
    private float RotxP, RotyP, RotzP;
    private Quaternion OriginalQuaternion;
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
        OriginalQuaternion = inst.transform.rotation;
        this.transform.rotation = OriginalQuaternion;
    }
	
	// Update is called once per frame
	void Update () {
        InstObjectPosition = new Vector3((Empty1.transform.position.x + Empty2.transform.position.x) / 2, (Empty1.transform.position.y + Empty2.transform.position.y) / 2, (Empty1.transform.position.z + Empty2.transform.position.z) / 2);
        InstObjectScale = Mathf.Sqrt(
            (Empty1.transform.position.x - Empty2.transform.position.x) * (Empty1.transform.position.x - Empty2.transform.position.x) +
            (Empty1.transform.position.y - Empty2.transform.position.y) * (Empty1.transform.position.y - Empty2.transform.position.y) +
            (Empty1.transform.position.z - Empty2.transform.position.z) * (Empty1.transform.position.z - Empty2.transform.position.z)
        );

        CosX =
        (Empty2.transform.position.z - Empty1.transform.position.z) /
        Mathf.Sqrt(
            (Empty2.transform.position.y - Empty1.transform.position.y) * (Empty2.transform.position.y - Empty1.transform.position.y) +
            (Empty2.transform.position.z - Empty1.transform.position.z) * (Empty2.transform.position.z - Empty1.transform.position.z)
        );
        if ((Empty2.transform.position.y - Empty1.transform.position.y) > 0) CosX = CosX * -1;
        Rotx = Mathf.Acos(CosX) * Mathf.Rad2Deg;
        CosY =
        (Empty2.transform.position.x - Empty1.transform.position.x) /
        Mathf.Sqrt(
            (Empty2.transform.position.x - Empty1.transform.position.x) * (Empty2.transform.position.x - Empty1.transform.position.x) +
            (Empty2.transform.position.z - Empty1.transform.position.z) * (Empty2.transform.position.z - Empty1.transform.position.z)
        );
        Roty = Mathf.Acos(CosY) * Mathf.Rad2Deg;
        if ((Empty2.transform.position.z - Empty1.transform.position.z) < 0) Roty = Roty * -1;

        /*if (Rotx != RotxP)
        {
            inst.transform.Rotate(Rotx-RotxP, 0, 0);
            RotxP = Rotx;
        }
        if (Roty != RotyP)
        {
            inst.transform.Rotate(0, Roty - RotyP, 0);
            RotyP = Roty;
        }
        if (Rotz != RotzP)
        {
            inst.transform.Rotate(0, 0, Rotz - RotzP);
            RotzP = Rotz;
        }*/
        Quaternion RotXQuat = Quaternion.AngleAxis(Rotx, Vector3.forward);
        Quaternion RotYQuat = Quaternion.AngleAxis(-Roty, Vector3.up);
        //Quaternion RotZQuat = Quaternion.AngleAxis(-Rotz, Vector3.forward);
        inst.transform.rotation = OriginalQuaternion * RotYQuat * RotXQuat;
        this.transform.rotation = OriginalQuaternion * RotYQuat * RotXQuat;
        inst.transform.position = InstObjectPosition;
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale);
        mousex = Input.mousePosition.x;
        //Empty1.transform.position = new Vector3((mousex - mousexnormal) / 15 , 0, 0);
        mousey = Input.mousePosition.y;
        //Empty2.transform.position = new Vector3((mousey - mouseynormal) / 15 , 0, 0);
    }
}
