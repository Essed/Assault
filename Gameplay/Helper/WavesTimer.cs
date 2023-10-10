using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WavesTimer : MonoBehaviour {

    public bool Spawn; // создать волну
    [SerializeField]
    private float time; // время между волнами   
    public float timer; // значение в инспекторе
    public string StringTimer; // значения таймера для текста  
       
    public GameObject combo, comboTxt;

    // ссылки на компоненты 
    [HideInInspector]
    public Text txt; // текст таймера
    private GameObject[] RespawnEnemys; // массив с противниками
    public PlayerContoller PlayerComponent; // ссылка на игрока
    
   

    private void Start()
    {        
        RespawnEnemys = GameObject.FindGameObjectsWithTag("Respawn");
        txt = GameObject.Find("Timer").GetComponent<Text>();
        PlayerComponent = GetComponent<PlayerContoller>();      

        time = timer;
    
    }

    private void FixedUpdate()
    {
        // при окончании таймера начинается респавн противников
        if (Timer() == "0." || Timer() == "0")
        {            
            time = timer;

            txt.text = "";

            combo.SetActive(true);

            comboTxt.SetActive(true);

            enabled = false;

            RespawnOn();
        }

        else
        {
            PlayerComponent.RegenHp();

            RespawnOff();            
        }       

    }

    // метод таймера
    public string Timer()
    {
        time -= Time.deltaTime;
        StringTimer = time.ToString();

        if (timer < 10f)
        {
            StringTimer = StringTimer.Substring(0, 1);           
            txt.text = "Next wave: " + StringTimer;
            return StringTimer;
        }
        else
        {
            StringTimer = StringTimer.Substring(0, 2);
            txt.text = "Next wave: " + StringTimer;
            return StringTimer;
        }
    }    
    
    // методы респавна
    private void RespawnOn()
    {
        for (int i = 0; i < RespawnEnemys.Length; i++)
        {
            RespawnEnemys[i].GetComponent<RespawnEnemy>().enabled = true;           
        }
    }
    private void RespawnOff()
    {
        for (int i = 0; i < RespawnEnemys.Length; i++)
        {
            RespawnEnemys[i].GetComponent<RespawnEnemy>().enabled = false;
        }
    }

 

}
