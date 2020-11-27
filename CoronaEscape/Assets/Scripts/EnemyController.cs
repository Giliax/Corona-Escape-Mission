using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Emily")
        {
            if(other.GetComponent<Rigidbody2D> ().velocity.y <= 0f)
            {
                ScoreScript.scoreValue += 1;
                Destroy(transform.parent.gameObject);
            }    
        }
    }


}
