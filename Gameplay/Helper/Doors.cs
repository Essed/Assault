using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour {

    private bool enter; // открытие и закрытие двери
    private Animator dr_animator;

    private void Start()
    {
        dr_animator = GetComponent<Animator>();
    }

    // входе открывается дверь, а при выходе закрывается
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy") enter = true;       
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Enemy") enter = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy") enter = false;      
    }

    private void Update()
    {
        if (enter)
        {
            dr_animator.SetBool("Open",true);
        }
        else dr_animator.SetBool("Open", false);
    }

}
