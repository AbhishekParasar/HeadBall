using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    public float speed ;
    public float jumpForce;
    public bool isGrounded = false;
    Rigidbody2D rb;
    Animator anim;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            MoveRight();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        else if (Input.GetKeyDown(0))
        {
            anim.SetTrigger("kick");
        }
        else
        {
            //speed = 0;
            anim.SetFloat("speed", speed);
        }
    }

    public void MoveLeft()
    {
        
        anim.SetFloat("speed", speed);
        Vector2 targetPos = new Vector2(transform.position.x - 1, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
    public void MoveRight()
    {
       
        anim.SetFloat("speed", speed);
        Vector2 targetPos = new Vector2(transform.position.x + 1, transform.position.y);
        transform.position = Vector2.Lerp(transform.position, targetPos, speed * Time.deltaTime);
    }
    public void Jump()
    {
        if (isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "terreno")
        {
            isGrounded = true;
        }
    }
}
