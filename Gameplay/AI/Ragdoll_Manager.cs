using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll_Manager : MonoBehaviour {


    public float timing; // время исчезновения

    private void Update()
    {        
        timing -= 0.1f;
        if (timing <= 0) Destroy(gameObject);
    }
}
