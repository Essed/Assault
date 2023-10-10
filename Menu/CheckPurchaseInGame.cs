using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPurchaseInGame : MonoBehaviour {

    public GameObject player,bullet;



	private void Start () {

        player = GameObject.FindGameObjectWithTag("Player");
        SuperDamage();
        SuperHP();
    }


   private void SuperDamage()
    {
        if (PlayerPrefs.GetString("Supergrades") == "yes")
        {           
            bullet.GetComponent<Bullet>().damage = 5f;
        }           
    }

    private void SuperHP()
    {
        if (PlayerPrefs.GetString("Supergrades") == "yes")
        {
            player.GetComponent<PlayerContoller>().HP = 6.5f;
        }
    }
}
