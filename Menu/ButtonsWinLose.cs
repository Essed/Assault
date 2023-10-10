using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class ButtonsWinLose : MonoBehaviour {

    private static int AdvCount = 0;
    public static int death;

    public GameObject LoadingFrame; // окно загрузки

    private void Start()
    {
        if (PlayerPrefs.GetString("NoAds") != "yes")
        {
            if (Advertisement.isSupported)
                Advertisement.Initialize("2704025", false);


            else Debug.Log("Platform is not supported");
        }
    }

	public void Access()
    {
        AdvCount++;
        death++;

        if (PlayerPrefs.GetInt("Death") <= death) PlayerPrefs.SetInt("Death", PlayerPrefs.GetInt("Death") + 1);
        else PlayerPrefs.SetInt("Death", PlayerPrefs.GetInt("Death") + 1);


        if (PlayerPrefs.GetString("NoAds") != "yes")
        {
            if (Advertisement.IsReady() && AdvCount % 3 == 0)
            {
                Advertisement.Show();
            }
        }

        LoadingFrame.SetActive(true);

        SceneManager.LoadScene("Menu");
    }
}
