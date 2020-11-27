using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public static AnimatorController instance;

    Animator myAnim;

    //Combat
    public int health = 3;
    public float invincibleTimeAfterDamage = 2;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  
   // public void TriggerHurt
   // {
   // StartCoroutine(HurtBlinker)    }

    IEnumerator HurtBlinker(float hurtTime)
    {
        //ignore collisions between enemies and players
        int enemyLayer = LayerMask.NameToLayer("Enemy");
        int playerLayer = LayerMask.NameToLayer("Player");
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer);


        //start looping blink
        myAnim.SetLayerWeight(1, 1);

        //wait for invincible to be done
        yield return new WaitForSeconds(hurtTime);
        //stop blink and collision again
        Physics2D.IgnoreLayerCollision(enemyLayer, playerLayer, false);
        myAnim.SetLayerWeight(1, 0);
    }

    //Combat

    void Hurt()
    {
        health--;
        if (health <= 0)
            Application.LoadLevel(Application.loadedLevel);
        //else
         //   myAnim.TriggerHurt(invincibleTimeAfterDamage);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController enemy = collision.collider.GetComponent<EnemyController>();
        if (enemy != null)
        {
            Hurt();
        }
    }
}
