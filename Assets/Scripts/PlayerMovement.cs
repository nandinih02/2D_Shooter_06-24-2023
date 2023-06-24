using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller2D;
    float horizMove = 0f;
    public float speed = 40f;
    bool jump = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizMove = Input.GetAxisRaw("Horizontal") * speed;
        //
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        controller2D.Move(horizMove * Time.fixedDeltaTime ,false, jump);
        jump = false;
    }
}
