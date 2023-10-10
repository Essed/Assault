using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI_Enemy : MonoBehaviour
{

    // основные параметры
    public float radius = 16f; // область видимости AI 
    public float distance; // дистанция между врагом и игроком
    public float speed; // скорость полета пуль
    public float speedRotation; // скорость поворота   
    public float AttackDistance; // дистанции атаки
    public float HP; // очки здоровья    
    public bool tagged; // метка 
    private static bool combo_of;

    // основные параметры  геймплея AI
    private GameObject player; // игрок  
    public LayerMask mask; // маска для луча
    public Transform bullet; // пуля  
    public Transform Ragdoll; // кукла смерти AI





    // ссылки на компоненты     
    private NavMeshAgent nav;
    [HideInInspector]
    public Transform BulletInstance;
    [SerializeField]
    private Transform bulletSpot;
    public Weapon weapon;
    private Animator animator;
    [SerializeField]
    private RespawnEnemy RespawnEnemyCount;
    private PlayerContoller pl_control;
    public AudioClip AudioClp;
    AudioSource playerAudio;   




    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        playerAudio = GetComponent<AudioSource>();
    }

    private void Start()
    {
        player = GameObject.Find("Player");

        bulletSpot = transform.GetChild(2);

        RespawnEnemyCount = GameObject.FindGameObjectWithTag("Respawn").GetComponent<RespawnEnemy>();

        pl_control = GameObject.Find("Player").GetComponent<PlayerContoller>();        

    }

    private void FixedUpdate()
    {      
        MoveToPlayer();

        if (pl_control.HP <= 0)
        {
            StopAction();
        }

        if (HP <= 0)
        {
            Death();
        }
    }

    // метод движения AI к игроку
    private void MoveToPlayer()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance > radius)
        {
            nav.enabled = false;
            animator.SetBool("Fire", false);
            animator.SetBool("Runnig", false);
        }

        if (distance < radius)
        {
            nav.enabled = true;
            animator.SetBool("Fire", false);
            animator.SetBool("Runnig", true);

            nav.SetDestination(player.transform.position);
        }

        if (distance <= AttackDistance)
        {
            nav.enabled = false;
            animator.SetBool("Runnig", false);
            AI_RotateToPlayer();
            Shot();

            if (PlayerPrefs.GetString("Music") != "no")
                PlayAudioShot();
        }

    }

    // метод выстрела AI
    private void Shot()
    {
        RaycastHit hit;

        if (Physics.Raycast(bulletSpot.position, bulletSpot.forward, out hit, weapon.range, mask))
        {
            animator.SetBool("Fire", true);

            BulletInstance = Instantiate(bullet, bulletSpot.position, Quaternion.identity);

            AIBulletMove();
        }
    }

    // метод движения пули
    private void AIBulletMove()
    {
        BulletInstance.GetComponent<Rigidbody>().AddForce(bulletSpot.forward * speed);
    }

    // метод поворота AI к игроку
    private void AI_RotateToPlayer()
    {
        Vector3 rotationToPlayer = player.transform.position - transform.position;

        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rotationToPlayer), speedRotation * Time.deltaTime);
    }

    // метод смерти AI
    private void Death()
    {
        GetComponent<CharacterController>().enabled = false;

        GetComponent<Collider>().enabled = false;

        Instantiate(Ragdoll, transform.position, transform.rotation);


        if (PlayerPrefs.GetInt("Combo") <= 0)
        {
            PlayerPrefs.SetInt("Combo", PlayerPrefs.GetInt("Combo") + 1);            
                  
        }

        else
        {
            PlayerPrefs.SetInt("Combo", PlayerPrefs.GetInt("Combo") + 1);
        }

        Destroy(gameObject);
    }

    // прекращение стрельбы если игрок умер
    private void StopAction()
    {
        enabled = false;
        nav.enabled = false;
    }

    private void PlayAudioShot()
    {
        playerAudio.PlayOneShot(AudioClp);
    }   

   

}
    
