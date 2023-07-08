using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller2D;
    public Transform bulletInstantiate;
    public GameObject bullet;
    float horizMove = 0f;
    public float speed = 40f;
    bool jump = false;
    int damage = 20;
    public  int health = 100;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Character Movement
        horizMove = Input.GetAxisRaw("Horizontal") * speed;
        //
        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
        }

        //Shooting
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletInstantiate.position, bulletInstantiate.rotation);
        }
        //Health Gauge
        if(health<=0)
        {
            Destroy(gameObject);
            Debug.Log("YOU DIED");
        }
    }

    private void FixedUpdate()
    {
        controller2D.Move(horizMove * Time.fixedDeltaTime ,false, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Door"))
        {
            Debug.Log("YOU WIN");
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            health -= damage;
        }
    }
}
