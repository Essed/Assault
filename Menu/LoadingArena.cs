using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingArena : MonoBehaviour {

    // выбранные уровни сложности для первой арены
    public Buttons Map1Arena, Map1Normal, Map1Easy, Map1Hard;
    public Buttons Map2Arena, Map2Normal, Map2Easy, Map2Hard;
    public Buttons Map3Arena, Map3Normal, Map3Easy, Map3Hard;

    public float DamageDifficultEasy; // урон на легком уровне сложности 
    public float DamageDifficultNormal; // урон на нормальном уровне сложности 
    public float DamageDifficultHard; // урон на тяжелом уровне сложности 


    public int MoneyKillEasy; // количество денег на легком уровне сложности
    public int MoneyKillNormal; // количество денег на нормальном уровне сложности
    public int MoneyKillHard; // количество денег на тяжелом уровне сложности

    public GameObject Enemy; // противник
    public GameObject AI_Bullet; // урон противника
    public GameObject Bullet; // количество денег за убийство
    public GameObject LoadingImg; // окно загрузки 
    public GameObject Statuette; // статуетка игрока
    

    private bool First, Second, Third; // указатели на арены   


    private void Update()
    {
        LoadFirstArena();      
        LoadSecondArena();
        LoadThirdArena();
    }

    // Загрузка первой арены с разными уровнями сложности

    #region LoadDifficultArena1
       
    // Легкий уровень сложности 
    private void LoadEasyArena1()
    {
        if (Map1Arena.arena_1 && Map1Easy.arena_Easy)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 85f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 5f;
            Enemy.GetComponent<AI_Enemy>().HP = 100f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultEasy;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillEasy;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);            
            SceneManager.LoadScene("Arena 1");
         
        }
    }

    // Нормальный уровень сложности
    private void LoadNormalArena1()
    {
        if (Map1Arena.arena_1 && Map1Normal.arena_Normal)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 85f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 6f;
            Enemy.GetComponent<AI_Enemy>().HP = 170f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultNormal;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillNormal;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 1");
           
        }
    }

    // Тяжелый уровень сложности
    private void LoadHardArena1()
    {
        if(Map1Arena.arena_1 && Map1Hard.arena_Hard)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 85f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 6.5f;
            Enemy.GetComponent<AI_Enemy>().HP = 200f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultHard;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillHard;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 1");            
        }

    }

    // вызов 1 арены на разных сложностях
    private void LoadFirstArena()
    {
        LoadEasyArena1();
        LoadNormalArena1();
        LoadHardArena1();       
    }

    #endregion

    #region LoadDifficultArena2

    private void LoadEasyArena2()
    {
        if (Map2Arena.arena_2 && Map2Easy.arena_Easy)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 125f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 5f;
            Enemy.GetComponent<AI_Enemy>().HP = 100f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultEasy;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillEasy;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 2");
        }
    }
    private void LoadNormalArena2()
    {
        if (Map2Arena.arena_2 && Map2Normal.arena_Normal)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 135f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 6f;
            Enemy.GetComponent<AI_Enemy>().HP = 170f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultNormal;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillNormal;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 2");
        }
    }
    private void LoadHardArena2()
    {
        if (Map2Arena.arena_2 && Map2Hard.arena_Hard)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 145f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 6.5f;
            Enemy.GetComponent<AI_Enemy>().HP = 200f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultHard;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillHard;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 2");
        }

    }
    private void LoadSecondArena()
    {
        LoadEasyArena2();
        LoadNormalArena2();
        LoadHardArena2();
    }

    #endregion

    #region LoadDifficultArena3
    private void LoadEasyArena3()
    {
        if (Map3Arena.arena_3 && Map3Easy.arena_Easy)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 125f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 5f;
            Enemy.GetComponent<AI_Enemy>().HP = 100f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultEasy;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillEasy;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 3");
        }
    }
    private void LoadNormalArena3()
    {
        if (Map3Arena.arena_3 && Map3Normal.arena_Normal)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 135f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 6f;
            Enemy.GetComponent<AI_Enemy>().HP = 170f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultNormal;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillNormal;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 3");
        }
    }
    private void LoadHardArena3()
    {
        if (Map3Arena.arena_3 && Map3Hard.arena_Hard)
        {
            Enemy.GetComponent<AI_Enemy>().AttackDistance = 10f;
            Enemy.GetComponent<AI_Enemy>().radius = 145f;
            Enemy.GetComponent<AI_Enemy>().speedRotation = 6.5f;
            Enemy.GetComponent<AI_Enemy>().HP = 200f;
            AI_Bullet.GetComponent<AI_Bullet>().damage = DamageDifficultHard;
            Bullet.GetComponent<Bullet>().moneys = MoneyKillHard;
            Camera.main.GetComponent<AudioListener>().enabled = false;
            Statuette.SetActive(false);
            LoadingImg.SetActive(true);
            SceneManager.LoadScene("Arena 3");
        }

    }
    private void LoadThirdArena()
    {
        LoadEasyArena3();
        LoadNormalArena3();
        LoadHardArena3();
    }


    #endregion

}
