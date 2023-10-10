using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stats : MonoBehaviour {
     
    // их отображение в тексте 
    public Text KillsTxt;
    public Text TotalDamageTxt;
    public Text MoneyTxt;
    public Text RecordTxt;
    public Text DeathTxt;

    private void Update()
    { 
        // сама запись статистики      
         KillsTxt.text = PlayerPrefs.GetInt("Kills").ToString();      

     
         MoneyTxt.text = PlayerPrefs.GetInt("Money").ToString();


         TotalDamageTxt.text = PlayerPrefs.GetInt("TotalDamage").ToString();
        

         DeathTxt.text = PlayerPrefs.GetInt("Death").ToString();


         RecordTxt.text = PlayerPrefs.GetInt("Record").ToString();        

    }  
}
