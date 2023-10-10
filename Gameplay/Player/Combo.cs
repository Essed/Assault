using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combo : MonoBehaviour {

     
    private Text  txt;   
   

    private void Awake()
    {
        txt = GetComponent<Text>();
    }


    private void Start()
    {
        
        PlayerPrefs.SetInt("Combo", 0);

    }

    private void Update()
    {
        txt.text = PlayerPrefs.GetInt("Combo").ToString();
        print(PlayerPrefs.GetInt("Combo"));
    }

}
