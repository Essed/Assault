using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{

    public float damage; // урон 

    public static int money, kills, totalDamage, record; // статистические значения

    public int moneys; // значение денег
    public int DamageForShot; // урон за выстрел для статистики


    private void OnTriggerEnter(Collider other)
    {
        // уничтожение пули при попадании
        if (other.name != "Bullet Spot")
        {
            if (other.tag == "Enemy")
            {   
                // Общий урон для статистики                
                if (other.gameObject.GetComponent<AI_Enemy>().HP >= 0)
                {
                    totalDamage += DamageForShot;
                    other.gameObject.GetComponent<AI_Enemy>().HP -= damage;

                    if (PlayerPrefs.GetInt("TotalDamage") <= totalDamage)  PlayerPrefs.SetInt("TotalDamage", totalDamage);
                    else
                    {
                        PlayerPrefs.SetInt("TotalDamage", PlayerPrefs.GetInt("TotalDamage") + totalDamage);                        
                    }

                    // количество убийств, общий счет очков, заработанное количество денег
                    if (other.gameObject.GetComponent<AI_Enemy>().HP <= 0)
                    {
                        kills++;
                        money += moneys;
                        record += 300;

                        if (PlayerPrefs.GetInt("Kills") <= kills) PlayerPrefs.SetInt("Kills", kills);
                        else PlayerPrefs.SetInt("Kills", PlayerPrefs.GetInt("Kills") + 1);

                        if (PlayerPrefs.GetInt("Money") <= money) PlayerPrefs.SetInt("Money", money);
                        else PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") + moneys);

                        if (PlayerPrefs.GetInt("Record") <= record) PlayerPrefs.SetInt("Record", record);
                        else PlayerPrefs.SetInt("Record", PlayerPrefs.GetInt("Record") + 925);

                    }
                     Destroy(gameObject);
                }
               Destroy(gameObject);   
            }
            Destroy(gameObject);

        }        
    }  

}

   
   


