using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float speed;
    public float horizontalInput;
    public Animator playerAnimator;
    public bool grounded;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myRigidBody.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        KeyPress();

        //flip player left and right
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-0.4f, 0.4f, 0.4f);

        playerAnimator.SetBool("run",horizontalInput !=0);
        playerAnimator.SetBool("grounded", grounded);
    }

    // User Input Key Move Player Sprite
    void KeyPress()
    {
        if (Input.GetKeyDown(KeyCode.W) && grounded)
        {
            Jump();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            myRigidBody.linearVelocity = new Vector2(-speed, myRigidBody.linearVelocity.y); // Move left while keeping the y-axis velocity
        }
        else if (Input.GetKey(KeyCode.D))
        {
            myRigidBody.linearVelocity = new Vector2(speed, myRigidBody.linearVelocity.y); // Move right while keeping the y-axis velocity
        }
    }


    private void Jump()
    {
        myRigidBody.linearVelocity = new Vector2(myRigidBody.linearVelocity.x,speed); // Move Up while keeping the x-axis velocity
        playerAnimator.SetTrigger("jump");
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Grounded")
        {
            grounded = true;
        }  
    }

}
