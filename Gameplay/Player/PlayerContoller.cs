using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

    // основные параметры
    public float moveSpeed; // скорость передвижения
    public float gravityForce; // сила гравитации
    public float speed; // скорость полета пуль 
    public float speedRotation; // скорость поворота 
    public float HP; // очки здоровья   
    public float radius; // область действия игрока    
    public GameObject[] enemy;

    // основные параметры геймплея для персонажа 
    [HideInInspector]
    public Vector3 MoveVector; // направление движения персонажа  
    public Transform bullet; // пуля
    [HideInInspector]
    public Transform BulletInstance; // позиция пули
    private Transform bulletSpot; // место спавна пули
    [SerializeField]
    private LayerMask mask; // маска для луча     



    // ссылки на компоненты
    private CharacterController ch_contoller;
    private Animator ch_animator;
    private MobileController m_contoller;
    private Shoting ch_shot; // Нажатие кнопки выстрела
    public Weapon weapon; // характеристика оружия
    private Image HpImg; // шкала здоровья
    [SerializeField]
    private Image ImgOver;
    public GameObject LoseOpen;
    public AudioClip AudioClp;
    AudioSource playerAudio;
    private GameObject HPForDel;
    private GameObject PauseForDel,UpBorder;
    public GameObject Combo, comboTxt;

    private void Awake()
    {
        // подключение ссылок

        ch_contoller = GetComponent<CharacterController>();
        ch_animator = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        // Подключение ссылок у найденых объектов 

        ch_shot = GameObject.Find("Trigger").GetComponent<Shoting>();
        m_contoller = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileController>();
        bulletSpot = GameObject.Find("Bullet Spot").transform;
        HpImg = GameObject.Find("HP Bar").GetComponent<Image>();
        ImgOver = GameObject.Find("Overh").GetComponent<Image>();
        HPForDel = GameObject.Find("HP");
        PauseForDel = GameObject.Find("Pause");
        UpBorder = GameObject.Find("RawImage");    

    }


    private void Update()
    {
        CharacterMove();
        GamingGravity();
        TakingDamage();        
        Overheating_Of_Weapons();

        if (HpImg.fillAmount == 0)
        {
            GameOver();
        }

        if(Time.timeScale == 0f)
        {
            m_contoller.enabled = false;
            ch_shot.enabled = false;
        }
        else
        {
            m_contoller.enabled = true;
            ch_shot.enabled = true;
        }
    }

    // метод перемещения персонажа
    private void CharacterMove()
    {
        // перемещние по поверхности 
        MoveVector = Vector3.zero;
        MoveVector.x = m_contoller.Horizontal() * moveSpeed;
        MoveVector.z = m_contoller.Vertical() * moveSpeed;


        // анимация передвижения персонажа 
        AnimatedCharacterMove();
        AnimatedCharacterShot();


        if (Vector3.Angle(Vector3.forward, MoveVector) > 1f || Vector3.Angle(Vector3.forward, MoveVector) == 0)
        {
            Vector3 direct = Vector3.RotateTowards(transform.forward, MoveVector, speedRotation, 0.0f);
            transform.rotation = Quaternion.LookRotation(direct);
        }

        MoveVector.y = gravityForce;
        ch_contoller.Move(MoveVector * Time.deltaTime); // метод передвижения по направлению
    }

    // метод гравитации
    private void GamingGravity()
    {
        if (!ch_contoller.isGrounded) gravityForce -= 20f * Time.deltaTime;
        else gravityForce = -1f;
    }

    // метод анимации передвижения   
    private void AnimatedCharacterMove()
    {

        if (MoveVector.x != 0 || MoveVector.z != 0 && !ch_shot.shot)
        {
            ch_animator.SetBool("Move", true);
        }
        else ch_animator.SetBool("Move", false);

    }

    // метод анимации стрельбы
    private void AnimatedCharacterShot()
    {
        // стрельба из положения стоя
        if (MoveVector.x == 0 && MoveVector.z == 0 && ch_shot.shot)
        {
            ch_animator.SetBool("Fire", true);
            Shoting();
            if (PlayerPrefs.GetString("Music") != "no")
                PlayAudioShot();

        }
        else { ch_animator.SetBool("Fire", false); }

        // стрельба в движении 
        if (ch_shot.shot && (MoveVector.x != 0 || MoveVector.z != 0))
        {
            ch_animator.SetBool("Move", true);
            Shoting();
            if (PlayerPrefs.GetString("Music") != "no")
                PlayAudioShot();
        }
    }

    // метод стрельбы 
    private void Shoting()
    {
        RaycastHit hit;
        if (Physics.Raycast(bulletSpot.position, bulletSpot.forward, out hit, weapon.range, mask))
        {            
           BulletInstance = Instantiate(bullet, bulletSpot.position, Quaternion.identity);
           BulletMove();
            
        }
    }
    // метод полета пули 
    private void BulletMove()
    {
        BulletInstance.GetComponent<Rigidbody>().AddForce(bulletSpot.forward * speed);
    }

    // метод получения урона
    private void TakingDamage()
    {
        HpImg.fillAmount = HP;
    }   

    // метод поражения
    private void GameOver()
    {
        DeleteAll();
        HPForDel.SetActive(false);
        PauseForDel.SetActive(false);
        UpBorder.SetActive(false);
        Combo.SetActive(false);
        comboTxt.SetActive(false);
        LoseOpen.SetActive(true);        
    }

    // проверка состояния
    private void CheckingState()
    {
        // если игрока убили
        if (HpImg.fillAmount == 0)
        {
            GameOver();
        }              
    }
    // перегрев оружия
    private void Overheating_Of_Weapons()
    {
        if (ch_shot.shot)
        {
            ImgOver.fillAmount += 0.0025f;            
        }
        else ImgOver.fillAmount -= 0.003f;

        if (ImgOver.fillAmount > 0.999f)
        {
            ch_shot.shot = false;           
        }        

    }
    
    // метод уничтожения противников
    private void DeleteAll()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");

        for(int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i]);
        }
    }
    
    // метод проигрывание звука выстрела
    private void PlayAudioShot()
    {
        playerAudio.PlayOneShot(AudioClp);
    }

    // метод восстановления хп между волнами
    public void RegenHp()
    {
        string timeValueString = GetComponent<WavesTimer>().Timer();       

        if(timeValueString == "1" && PlayerPrefs.GetString("Supergrades") != "yes")
        {
            HP = 1f;
        }

        if (timeValueString == "1" && PlayerPrefs.GetString("Supergrades") == "yes")
        {
            HP = 6.5f;
        }


    }

}

