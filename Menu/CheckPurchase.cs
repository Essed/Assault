using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CheckPurchase : MonoBehaviour {

    public GameObject player,bullet,removeadsButton,supergradesButton;


    public GameObject  Map2Lock, Map3Lock, BuyOn, BuyOff;
    public Button Map2, Map3;


    private void Start()
    {
      //  PlayerPrefs.DeleteAll();
    }

   private void Update()
    {

        CheckSupergrades();      
        CheckNoAds();


        if(PlayerPrefs.GetInt("NewArena") == 1 )
        {
            Map2.interactable = true;
            Destroy(Map2Lock);
        }

        if (PlayerPrefs.GetInt("NewArena") == 2 )
        {
            Destroy(BuyOff);
            Destroy(Map3Lock);
            Destroy(Map2Lock);
            Map3.interactable = true;
            Map2.interactable = true;
            BuyOn.SetActive(true);
        }


    }

    private void CheckSupergrades()
    {
        if (PlayerPrefs.GetString("Supergrades") == "yes")
        {
            supergradesButton.GetComponent<Button>().interactable = false;
        }
    }

    private void CheckNoAds()
    {
        if (PlayerPrefs.GetString("NoAds") == "yes")
        {                
            removeadsButton.GetComponent<Button>().interactable = false;
        }
    }

}
