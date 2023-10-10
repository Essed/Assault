using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveEnemy : MonoBehaviour {

    public GameObject[] enemy; // живые противники

    // ссылки на компоненты
    [SerializeField]
    private WavesTimer timer;  // таймер

    private void Start()
    {
        timer = GameObject.Find("Player").GetComponent<WavesTimer>();      // берем компонет таймера через игрока 
    }
    	
   private  void Update ()
    {
        Enemy();       	
	}

    // метод включения таймера между волнами
    private void Enemy()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemy.Length == 0)
        {           
            timer.enabled = true;
        }
        else
        {           
            timer.txt.text = "";
            timer.enabled = false;
        }
    }
}
