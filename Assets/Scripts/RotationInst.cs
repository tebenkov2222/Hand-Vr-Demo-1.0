using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationInst : MonoBehaviour
{
    Vector3 firstPoint, secondPoint, center, InstObjectScale;
    public GameObject InstObject, Cube, Rectangle, UVSphere, LeftSphere, RightSphere;
    public bool position = true,
                scale = true, 
                rotation = true,
                ActiveInstantiateBool = false;
    private void FixedUpdate()
    {
        KeyboardScript();
    }
    private void KeyboardScript()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ExitFromInstantiate();
        if (Input.GetKeyDown(KeyCode.E)) EnterFromInstantiateCube();
        if (Input.GetKeyDown(KeyCode.R)) EnterFromInstantiateRectangle();
        ActiveInstantiate();
    }
    private void ActiveInstantiate()
    {
        if (ActiveInstantiateBool)
        {
            firstPoint = LeftSphere.transform.position;
            secondPoint = RightSphere.transform.position;

            PositionControl();
            InstObject.transform.position = center;
            ScaleControl();
            InstObject.transform.localScale = InstObjectScale;
            RotationControl();
        }
    }
    void NormalPositionAndScale()
    {
        PositionControl();
        ScaleControl();
    }
    void PositionControl()
    {
        center = new Vector3((firstPoint.x + secondPoint.x) / 2, (firstPoint.y + secondPoint.y) / 2, (firstPoint.z + secondPoint.z) / 2);
    }

    void ScaleControl()
    {
        float spaceBetween = Mathf.Sqrt
        (
            Mathf.Pow(firstPoint.x - secondPoint.x, 2) +
            Mathf.Pow(firstPoint.y - secondPoint.y, 2) +
            Mathf.Pow(firstPoint.z - secondPoint.z, 2)
        );
        if (InstObject.tag != "Rectangle")
            InstObjectScale = new Vector3(spaceBetween, spaceBetween, spaceBetween);
        else InstObjectScale = new Vector3(0.4f, 0.2f, spaceBetween);
    }

    void RotationControl()
    {
        InstObject.transform.LookAt(RightSphere.transform);
    }
    public void ExitFromInstantiate()
    {
        Debug.Log("EXIT");
        ActiveInstantiateBool = false;
        InstObject.GetComponent<Rigidbody>().useGravity = true;
    }
    public void EnterFromInstantiateCube()
    {
        Debug.Log("Enter");
        ActiveInstantiateBool = true;
        InstObject = Instantiate(Cube, center, Quaternion.identity);
        ActiveInstantiate();

    }
    public void EnterFromInstantiateRectangle()
    {
        ActiveInstantiateBool = true;
        Debug.Log("Enter");
        InstObject = Instantiate(Rectangle, center, Quaternion.identity);
        ActiveInstantiate();
    }
}
