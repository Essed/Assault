using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour {

   

    // координаты крайних точек объекта
    private float maxX;
    private float minX;
    private float maxZ;
    private float minZ;

    // случайные координаты респавна
    private float newX;
    private float newZ;
    private float newY;
       

    // количество противников на респавне
    [SerializeField]
    private int countEnemy;
    public float maxEnemy;
    public float minEnemy;

    // ссылки на компоненты    
    public GameObject enemy; 
    Renderer Renderer;
    private WavesTimer timer;
   

    private void Awake() {

        Renderer = GetComponent<Renderer>();

    }

    private void Start()
    {       
        countEnemy = (int)Random.Range(minEnemy, maxEnemy);

        minX = Renderer.bounds.min.x;
        maxX = Renderer.bounds.max.x;
        minZ = Renderer.bounds.min.z;
        maxZ = Renderer.bounds.max.z;

        timer = GameObject.Find("Player").GetComponent<WavesTimer>();

        if(timer.StringTimer != "0")
        {
            enabled = false;
        }
        else
        {
            enabled = true;
        }


    }

    private void Update() {

        newX = Random.Range(minX, maxX);
        newZ = Random.Range(minZ, maxZ);
        newY = transform.position.y;


        Spawn_Enemy();
    }

    private void Spawn_Enemy()
    {       
         for (int i = 0; i <= countEnemy; i++)
            {
               Instantiate(enemy, transform.position, enemy.transform.rotation);
               enemy.transform.position = new Vector3(newX, newY, newZ);
               enemy.transform.position = new Vector3(newX, 0f, newZ);
               if (i == countEnemy) enabled = false;
         }
    }

}
