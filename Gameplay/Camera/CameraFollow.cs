using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    // основные параметры
    public float speed; // скорость передвижения
    public float offsetX; // смещение по оси X
    public float offsetZ; // смещение по оси Z   


    // параметры геймплея камеры
    private GameObject player; // игрок
    private float movementX; // позиция камеры по оси X
    private float movementZ; // позиция камеры по оси Z 



    private void Start () {

        player = GameObject.Find("Player");
        
	}
	
	private void LateUpdate () {

        movementX = player.transform.position.x + offsetX - transform.position.x;
        movementZ = player.transform.position.z + offsetZ - transform.position.z;
        

        transform.position += new Vector3(movementX * speed * Time.deltaTime,0, movementZ * speed * Time.deltaTime);
    }
}
