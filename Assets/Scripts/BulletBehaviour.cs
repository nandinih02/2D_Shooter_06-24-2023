using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;
    public int damage = 40;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
        if(enemy!=null)
        {
            enemy.TakeDamage(damage);
            //score += 50;
            Destroy(gameObject);
            //Debug.Log("Score: " + score);
        }
        

        if (collision.gameObject.CompareTag("Barrier"))
        {
            Destroy(this.gameObject);
        }
    }

}
