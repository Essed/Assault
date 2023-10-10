using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AI_Bullet : MonoBehaviour {

    public float damage; // урон  

    private void FixedUpdate()
    {
        Vector3 curPos = gameObject.transform.position;

        // Уничтожение если позици по осям x,z больше или меньше

        if (curPos.z > 50f || curPos.z < -50f) Destroy(gameObject);
        if (curPos.x > 50f || curPos.x < -50f) Destroy(gameObject);
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // уничтожение пули при попадании
        if (other.name != "AI Bullet")
        {
            if (other.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerContoller>().HP -= damage;
                Destroy(gameObject);
            }
            else Destroy(gameObject);
        }
                           
    }
}
