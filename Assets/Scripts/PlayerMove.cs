using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public GameManager manager;

    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    public GameObject scanObject;

    void Awake()
    {
        //Application.targetFrameRate = 30;
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update(){
        //Jump
        if(Input.GetButtonDown("Jump")){
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            manager.Action(scanObject);
        }

        //Stop speed
        if(Input.GetButtonUp("Horizontal")){
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);//단위를 구할때 normalized쓴다.
        }
    }

    void FixedUpdate()
    {
        //Move speed
        //Move By Control
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid.velocity.x > maxSpeed) // Right maxspeed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if(rigid.velocity.x < maxSpeed*(-1)) // Left maxspeed
            rigid.velocity = new Vector2(maxSpeed*(-1), rigid.velocity.y);
    }
}
