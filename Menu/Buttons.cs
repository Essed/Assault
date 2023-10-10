using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class Buttons : MonoBehaviour {

    // Окно профиля
    public GameObject statistics;     // окно профиля 
    public GameObject Profile_Close;  // кнопка закрытия профиля   
    public GameObject Profile_Open;   // кнопка открытия профиля    

    // Окно магазина
    public GameObject UpGradesFrame;  // окно магазина
    public GameObject UpGrades_Open;  // кнопка открытия  окна магазина
    public GameObject UpGrades_Close; // кнопка закрытия окна магазина    

    // Окно play
    public GameObject PlayFrame;      // окно play
    public GameObject Play_Open;      // кнопка открытие окна play
    public GameObject Play_Close;     // кнопка закрытия окна play 

    // Окно настроек
    public GameObject OptionsFrame;   // окно настроек
    public GameObject Options_Open;   // кнопка открытия окна настроек
    public GameObject Options_Close;  // кнопка закрытия окна настроек
    public GameObject Music_On;       // кнопка выключения звука
    public GameObject Music_Off;      // кнопка включения  звука 

    // Окно донатного магазина
    public GameObject LuxorFrame;     // окно донатного магазина
    public GameObject Luxor_Open;     // кнопка открытия магазина
    public GameObject Luxor_Close;    // кнопка закрытия магазина

    // арены
    public GameObject ArenaFrame;
    public GameObject Arena1;
    public GameObject Arena2;
    public GameObject Arena3;

    // название арены
    public Text Name_Arena;             // ссылка на компонент
    public GameObject Name_ArenaFrame;  // окно названия карты

    // Окно сложности 
    public GameObject DifficultyFrame; // окно выбора сложности
    public GameObject DifficultyFrame_2; // окно выбора сложности для второй карты
    public GameObject DifficultyFrame_3; // окно выбора сложности для третьей карты  


    // Окно паузы
    public GameObject PauseFrame; // окно паузы
    public GameObject Pause; // кнопка паузы


    private void Start()
    {       

        if (gameObject.name == "Music on" || gameObject.name == "Music off")
        {
            if (PlayerPrefs.GetString("Music") == "no")
            {
                Music_On.SetActive(false);
                Music_Off.SetActive(true);
            }
            else
            {
                Music_On.SetActive(true);
                Music_Off.SetActive(false);
            }
        }       

    }

    // cписок уровней сложности, арен, и условий для перехода
    #region Booling

    public bool arena_1;
    public bool arena_2;
    public bool arena_3;

    public bool arena_Easy;
    public bool arena_Normal;
    public bool arena_Hard;

  

    #endregion Booling

    // все функции кнопок меню и интерфейса
    #region ButtonsFunctions

    // метод открытия окна play
    public void Maps_Opened()
    {
        Play_Open.SetActive(false);
        PlayFrame.SetActive(true);      
        Play_Close.SetActive(true);

        Profile_Open.GetComponent<Button>().interactable = false;
        UpGrades_Open.GetComponent<Button>().interactable = false;
        Options_Open.GetComponent<Button>().interactable = false;
    }

    // метод закрытия окна play и окна выбора сложности
    public void Maps_Closed()
    {
        PlayFrame.SetActive(false);
        Play_Close.SetActive(false);
        Play_Open.SetActive(true);

        DifficultyFrame.SetActive(false);
        DifficultyFrame_2.SetActive(false);
        DifficultyFrame_3.SetActive(false);

        Name_ArenaFrame.SetActive(false);
        ArenaFrame.SetActive(false);

        Profile_Open.GetComponent<Button>().interactable = true;
        UpGrades_Open.GetComponent<Button>().interactable = true;
        Options_Open.GetComponent<Button>().interactable = true;
    }

    // метод открытия окна профиля
    public void Profile_Opened()
    {
        Profile_Open.SetActive(false);
        Profile_Close.SetActive(true);
        statistics.SetActive(true);

        Play_Open.GetComponent<Button>().interactable = false;
        UpGrades_Open.GetComponent<Button>().interactable = false;
        Options_Open.GetComponent<Button>().interactable = false;
    }

    // метод закрытия окна профиля
    public void Profile_Closed()
    {
        Profile_Close.SetActive(false);
        Profile_Open.SetActive(true);
        statistics.SetActive(false);

        Play_Open.GetComponent<Button>().interactable = true;
        UpGrades_Open.GetComponent<Button>().interactable = true;
        Options_Open.GetComponent<Button>().interactable = true;
    }

    // метод открытия окна улучшений
    public void Upgrades_Opened()
    {
        UpGrades_Open.SetActive(false);
        UpGrades_Close.SetActive(true);
        UpGradesFrame.SetActive(true);

        Play_Open.GetComponent<Button>().interactable = false;        
        Options_Open.GetComponent<Button>().interactable = false;
        Profile_Open.GetComponent<Button>().interactable = false;

    }

    // метод закрытия окна улучшений
    public void Upgrades_Closed()
    {
        UpGrades_Close.SetActive(false);       
        UpGrades_Open.SetActive(true);
        UpGradesFrame.SetActive(false);

        Luxor_Open.SetActive(true);
        Luxor_Close.SetActive(false);
        LuxorFrame.SetActive(false);


        Play_Open.GetComponent<Button>().interactable = true;       
        Options_Open.GetComponent<Button>().interactable = true;
        Profile_Open.GetComponent<Button>().interactable = true;

    }

    // метод открытия окна настроек
    public void Options_Opened()
    {
        Options_Open.SetActive(false);
        OptionsFrame.SetActive(true);        
        Options_Close.SetActive(true);

        Play_Open.GetComponent<Button>().interactable = false;
        UpGrades_Open.GetComponent<Button>().interactable = false;
        Profile_Open.GetComponent<Button>().interactable = false;

    }

    // метод закрытия окна настроек
    public void Options_Closed()
    {  
        Options_Close.SetActive(false);
        Options_Open.SetActive(true);
        OptionsFrame.SetActive(false);

        Play_Open.GetComponent<Button>().interactable = true;
        UpGrades_Open.GetComponent<Button>().interactable = true;
        Profile_Open.GetComponent<Button>().interactable = true;
    }
      
    // метод включения и выключения музыки
    public void Music()
    {
        if(PlayerPrefs.GetString("Music") != "no")
        {
            PlayerPrefs.SetString("Music", "no");
            Music_On.SetActive(false);
            Music_Off.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetString("Music", "yes");
            Music_On.SetActive(true);
            Music_Off.SetActive(false);
        }
    }

    // метод открытия магазина
    public void Luxor_Opened()
    {
        LuxorFrame.SetActive(true);
        Luxor_Open.SetActive(false);
        Luxor_Close.SetActive(true);
    }

    // метод закрытия магазина
    public void Luxor_Closed()
    {
        LuxorFrame.SetActive(false);
        Luxor_Open.SetActive(true);
        Luxor_Close.SetActive(false);
    }

    // метод отражения 1 арены
    public void Arena_1()
    {
        DifficultyFrame.SetActive(true);
        DifficultyFrame_2.SetActive(false);
        DifficultyFrame_3.SetActive(false);

        ArenaFrame.SetActive(true);        
        Arena1.SetActive(true);
        Arena2.SetActive(false);
        Arena3.SetActive(false);

        Name_Arena.text = "Core";
        Name_ArenaFrame.SetActive(true);
    }  

    // метод отражения 2 арены    
    public void Arena_2()
    {
        DifficultyFrame_2.SetActive(true);
        DifficultyFrame.SetActive(false);
        DifficultyFrame_3.SetActive(false);

        ArenaFrame.SetActive(true);
         Arena2.SetActive(true);
         Arena1.SetActive(false);
         Arena3.SetActive(false);

        Name_Arena.text = "Area";
        Name_ArenaFrame.SetActive(true);

    }

    // метод отражения 2 арены    
    public void Arena_3()
    {
        DifficultyFrame_3.SetActive(true);
        DifficultyFrame.SetActive(false);
        DifficultyFrame_2.SetActive(false);

        ArenaFrame.SetActive(true);
         Arena3.SetActive(true);
         Arena1.SetActive(false);
         Arena2.SetActive(false);

         Name_Arena.text = "Between";
         Name_ArenaFrame.SetActive(true);
    }
    
    // включение паузы
    public void PauseEnabled()
    {
        gameObject.SetActive(false);
        PauseFrame.SetActive(true);
        Camera.main.GetComponent<TimePause>().PauseOn();

    }

    // выключение паузы
    public void PauseDisabled()
    {
        Pause.SetActive(true);
        PauseFrame.SetActive(false);
        Camera.main.GetComponent<TimePause>().PauseOff();
    }  

    #endregion ButtonsFunctions

    // установка уровня сложности арены
    #region SetupLevelDifficultyArena
    public void ArenaEasyTrue()
    {
        arena_Easy = true;
        arena_Hard = false;
        arena_Normal = false;
    }
    public void ArenaNormalTrue()
    {
        arena_Normal = true;
        arena_Easy = false;
        arena_Hard = false;
    }
    public void ArenaHardTrue()
    {
        arena_Hard = true;
        arena_Easy = false;
        arena_Normal = false;
    }    

    #endregion SetupArena

    // Установка условаия для запуска первой арены
    public void Arena1InMenuTrue()
    {
        arena_1 = true;

    }    
    public void Arena2InMenuTrue()
    {
        arena_2 = true;
    }
    public void Arena3InMenuTrue()
    {
        arena_3 = true;
    }
}
