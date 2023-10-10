using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyUpgrade : MonoBehaviour {

    // основные параметры покупки апгрейдов
    public int price; // Цена апгрейда  
    public static byte count;


    public GameObject BuyOn; // картинка после покупки

    // карты
    public Button Map2; // вторая  
    public Button Map3; // третья  

    // знак блокировки
    public GameObject Map2Lock;
    public GameObject Map3Lock;

    // ссылки на компоненты
    public Bullet Damage;
    public PlayerContoller player;


    private void Start()
    {
        // PlayerPrefs.DeleteAll();       
    }

    private void Update()
    {
        // покупка апгрейдов
        if (PlayerPrefs.GetString("UpgradeDamage") == "Yes" && gameObject.name == "Buy Damage")
        {
            Destroy(gameObject);
            BuyOn.SetActive(true);
        }

        if (PlayerPrefs.GetString("UpgradeHealth") == "Yes" && gameObject.name == "Buy Health")
        {
            Destroy(gameObject);
            BuyOn.SetActive(true);
        }       

    }

    // метод покупки апгрейда на урон
    public void BuyDamage()
    {
        if (PlayerPrefs.GetInt("Money") >= price)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
            Damage.damage += 1.3f;
            PlayerPrefs.SetString("UpgradeDamage","Yes");
        }
        else
        {
            PlayerPrefs.SetString("UpgradeDamage", "No");
        }
    }

    // метод покупки апгрейда на здоровье
    public void BuyHealth()
    {
        if(PlayerPrefs.GetInt("Money") >= price)
        {
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
            player.HP += 0.5f;
            PlayerPrefs.SetString("UpgradeHealth", "Yes");            
        }
        else
        {
            PlayerPrefs.SetString("UpgradeHealth", "No");
        }
    }

    // метод покупки новой арены
    public void BuyArena()
    {

        if (PlayerPrefs.GetInt("Money") >= price)
        {            
            PlayerPrefs.SetInt("NewArena", count++);
        }

        // покупка новой арены

        if (gameObject.name == "Buy Arena")
        {
            if (PlayerPrefs.GetInt("NewArena") == 1)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
                Map2.interactable = true;
                Destroy(Map2Lock);
            }

            if (PlayerPrefs.GetInt("NewArena") == 2)
            {
                PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - price);
                Destroy(gameObject);
                Destroy(Map3Lock);
                Destroy(Map2Lock);
                Map3.interactable = true;
                Map2.interactable = true;
                BuyOn.SetActive(true);
            }

        }

    }
}
