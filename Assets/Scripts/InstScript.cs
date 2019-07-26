using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstScript : MonoBehaviour
{
    public GameObject Empty1, Empty2, InstObject; // объекты: 1 и 2 точки и префаб кубика
    public Vector3 InstObjectPosition; // центральная точка, где должен быть кубик
    private float InstObjectScale, mousex, mousey, mousexnormal, mouseynormal; // скейл, мышьХ,мышьУ и начальные точки мыши(не актуально
    public GameObject inst; // сам кубик при инстанте сюда присваивается
    public float Rotx, Roty, Rotz, CosX, CosY, CosZ; // углы и коссинусы поворотов
    private float RotxP, RotyP, RotzP; // предыдущие значения углов
    private bool ActiveInstantiateBool;
    // Use this for initialization
    void Start()
    {
        NormalPositionAndScale();
        ActiveInstantiateBool = true;
        //создаем объект
        inst = Instantiate(InstObject, InstObjectPosition, Quaternion.identity);
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale);
        //для упарвления мышью
        mousexnormal = Input.mousePosition.x;
        mouseynormal = Input.mousePosition.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ExitFromInstantiate();
        if (Input.GetKeyDown(KeyCode.E)) EnterFromInstantiate();
        ActiveInstantiate();
    }
    private void ActiveInstantiate()
    {
        if (ActiveInstantiateBool == true) {
            NormalPositionAndScale();
            // енд старт код
            RotateVoid();
            inst.transform.position = InstObjectPosition; // присваиваем позицию
            inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale); // присваиваем скейл
        }
    }
    private void NormalPositionAndScale()
    {
        //находится центральная точка
        InstObjectPosition = new Vector3((Empty1.transform.position.x + Empty2.transform.position.x) / 2, (Empty1.transform.position.y + Empty2.transform.position.y) / 2, (Empty1.transform.position.z + Empty2.transform.position.z) / 2);
        // находится скейл
        InstObjectScale = Mathf.Sqrt(
            (Empty1.transform.position.x - Empty2.transform.position.x) * (Empty1.transform.position.x - Empty2.transform.position.x) +
            (Empty1.transform.position.y - Empty2.transform.position.y) * (Empty1.transform.position.y - Empty2.transform.position.y) +
            (Empty1.transform.position.z - Empty2.transform.position.z) * (Empty1.transform.position.z - Empty2.transform.position.z)
        );
    }
    private void RotateVoid()
    {
        inst.GetComponent<RotationScriptInst>().RotationInst(Empty1.transform.position, Empty2.transform.position); // изменяем угол
    }
    public void ExitFromInstantiate()
    {
        Debug.Log("EXIT");
        ActiveInstantiateBool = false;
        inst.GetComponent<Rigidbody>().useGravity = true;
    }
    public void EnterFromInstantiate()
    {
        Debug.Log("Enter");
        ActiveInstantiateBool = true;
        NormalPositionAndScale();
        inst = Instantiate(InstObject, InstObjectPosition, Quaternion.identity);
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale);
    }

}
