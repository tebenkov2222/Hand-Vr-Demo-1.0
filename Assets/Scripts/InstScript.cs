using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class InstScript : MonoBehaviour {
	public GameObject  Empty1, Empty2, InstObject; // объекты: 1 и 2 точки и префаб кубика
	public Vector3 InstObjectPosition; // центральная точка, где должен быть кубик
	private float InstObjectScale, mousex, mousey, mousexnormal, mouseynormal; // скейл, мышьХ,мышьУ и начальные точки мыши(не актуально
    public GameObject inst; // сам кубик при инстанте сюда присваивается
    public float Rotx, Roty, Rotz, CosX, CosY, CosZ; // углы и коссинусы поворотов
    private float RotxP, RotyP, RotzP; // предыдущие значения углов
    // Use this for initialization
    void Start () {
        //находится центральная точка
		InstObjectPosition = new Vector3((Empty1.transform.position.x + Empty2.transform.position.x) / 2, (Empty1.transform.position.y + Empty2.transform.position.y) / 2, (Empty1.transform.position.z + Empty2.transform.position.z) / 2);
        // находится скейл
        InstObjectScale = Mathf.Sqrt(
			(Empty1.transform.position.x - Empty2.transform.position.x) * (Empty1.transform.position.x - Empty2.transform.position.x) +
			(Empty1.transform.position.y - Empty2.transform.position.y) * (Empty1.transform.position.y - Empty2.transform.position.y) +
			(Empty1.transform.position.z - Empty2.transform.position.z) * (Empty1.transform.position.z - Empty2.transform.position.z)
		);
        //создаем объект
        inst = Instantiate(InstObject, InstObjectPosition, Quaternion.identity);
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale);
        //для упарвления мышью
        mousexnormal = Input.mousePosition.x;
        mouseynormal = Input.mousePosition.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        // тот же самый код что в начале
        InstObjectPosition = new Vector3((Empty1.transform.position.x + Empty2.transform.position.x) / 2, (Empty1.transform.position.y + Empty2.transform.position.y) / 2, (Empty1.transform.position.z + Empty2.transform.position.z) / 2);
        InstObjectScale = Mathf.Sqrt(
            (Empty1.transform.position.x - Empty2.transform.position.x) * (Empty1.transform.position.x - Empty2.transform.position.x) +
            (Empty1.transform.position.y - Empty2.transform.position.y) * (Empty1.transform.position.y - Empty2.transform.position.y) +
            (Empty1.transform.position.z - Empty2.transform.position.z) * (Empty1.transform.position.z - Empty2.transform.position.z)
        );
        // енд старт код
        // находим коссинус Х
        CosX =
        (Empty2.transform.position.z - Empty1.transform.position.z) /
        Mathf.Sqrt(
            (Empty2.transform.position.y - Empty1.transform.position.y) * (Empty2.transform.position.y - Empty1.transform.position.y) +
            (Empty2.transform.position.z - Empty1.transform.position.z) * (Empty2.transform.position.z - Empty1.transform.position.z)
        );
        // находим угол Х
        Rotx =  Mathf.Asin(CosX) * Mathf.Rad2Deg;
        // находим коссинус У
        CosY =
        (Empty2.transform.position.x - Empty1.transform.position.x) /
        Mathf.Sqrt(
            (Empty2.transform.position.x - Empty1.transform.position.x) * (Empty2.transform.position.x - Empty1.transform.position.x) +
            (Empty2.transform.position.z - Empty1.transform.position.z) * (Empty2.transform.position.z - Empty1.transform.position.z)
        );
        //Так же находим угол (с минусом стабильнее)
        Roty = Mathf.Asin(CosY) * Mathf.Rad2Deg;
        if ((Empty2.transform.position.z - Empty1.transform.position.z) > 0) Roty = Roty * -1;
         //находим коссинус Z
         CosZ =
        (Empty2.transform.position.y - Empty1.transform.position.y) /
        Mathf.Sqrt(
            (Empty2.transform.position.x - Empty1.transform.position.x) * (Empty2.transform.position.x - Empty1.transform.position.x) +
            (Empty2.transform.position.y - Empty1.transform.position.y) * (Empty2.transform.position.y - Empty1.transform.position.y)
        );
        //в свою очередь и угол тоже
        Rotz = Mathf.Asin(CosZ) * Mathf.Rad2Deg;

        inst.transform.position = InstObjectPosition; // присваиваем позицию
        inst.transform.localScale = new Vector3(InstObjectScale, InstObjectScale, InstObjectScale); // присваиваем скейл
        inst.GetComponent<RotationScriptInst>().RotationInst(Rotx, Roty, Rotz); // изменяем угол
        // код для упраавления мышью
        mousex = Input.mousePosition.x;
        //Empty1.transform.position = new Vector3((mousex - mousexnormal) / 15 , 0, 0);
        mousey = Input.mousePosition.y;
        //Empty2.transform.position = new Vector3((mousey - mouseynormal) / 15 , 0, 0);
    }
}
