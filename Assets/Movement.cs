using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 150f;
    public bool isJumping = false;

    private float moveInput;
    private Rigidbody2D rb2d;
    bool facingRight = true;

    Animator anim;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = Input.GetAxis("Horizontal");

        // ??????????????-???
        rb2d.linearVelocity = new Vector2(moveInput * speed, rb2d.linearVelocity.y);

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        if (moveInput == 0)
        {
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Run", true);
        }

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.AddForce(new Vector2(rb2d.linearVelocity.x, jumpForce));
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        if (other.gameObject.CompareTag("Ground"))
        {

            isJumping = false;

        }

    }//OnCollisionEnter2D

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {

            isJumping = true;

        }

    }//OnCollisionExit2D
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
