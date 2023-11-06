using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontrol : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float horizontalInput;
    public float verticalInput;

    [SerializeField]
    public float speed = 1f;

    private bool onGround = false;
    private Vector2 lookLeft, lookRight;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _rb.freezeRotation = true;
        
        lookLeft = new Vector2 (0, 0);
        lookRight = new Vector2 (0, 0);
    }

    void FixedUpdate()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
       
        float hMove = horizontalInput * speed * Time.deltaTime;
        float vMove = verticalInput * speed * Time.deltaTime;

        _rb.velocity = new Vector2(vMove, _rb.velocity.y);
        _rb.velocity = new Vector2(hMove, _rb.velocity.x);
        

        if(horizontalInput < 0)
        {
            gameObject.transform.localScale = new Vector2((float)0.05, (float)0.05);
        }
        else
        {
            gameObject.transform.localScale = new Vector2((float)-0.05, (float)0.05);
        }

        if(verticalInput < 0)
        {
        }
        else
        {
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Wall")
        {
            _rb.velocity = Vector2.zero;
            onGround = true;
        }

        if (collision.gameObject.name == "Ghost")
        {
            GetComponent<playercontrol>().enabled = false;
            _rb.velocity = Vector2.zero;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Wall")
        {
            onGround = false;
        }
    }



}
