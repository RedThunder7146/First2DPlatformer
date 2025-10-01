using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerMoveScript : MonoBehaviour
{
    HelperScript helper;
    public Rigidbody2D myRigidbody;
    public float playerSpeedY;
    public float playerSpeedX;
    public bool onGround = false;
    public Animator playerAnim;
    public LayerMask groundLayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.H))
        {
            helper.HelloWorld();
        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
        {
            helper.ResetGame();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            helper.ResetScene();
        }

        if (Input.GetKey(KeyCode.Space)&&IsGrounded())
        {


            myRigidbody.linearVelocityY = 1f * playerSpeedY;
        }
        
        if (Input.GetKey(KeyCode.A))
        {

            helper.DoFlipObject(true);
            myRigidbody.linearVelocityX = -1f * playerSpeedX;
            
            if (IsGrounded())
            {
                playerAnim.SetBool("ISRunning", true);
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {

            helper.DoFlipObject(false);
            myRigidbody.linearVelocityX = 1f * playerSpeedX;

            if (IsGrounded())
            {
                playerAnim.SetBool("ISRunning", true);
            }


        }
        
        else
        {
            playerAnim.SetBool("ISRunning", false);
            

        }

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Sprint();
        }

        else
        {
            playerAnim.SetBool("IsSprinting", false);
        }

        if (IsGrounded())
        {
            playerAnim.SetBool("IsJumping", false);
        }
        else
        {
            playerAnim.SetBool("IsJumping", true);
        }

    }

    bool IsGrounded()
    {

        float distance = 0.1f;
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down * distance;
        
        Debug.DrawRay(position, direction, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(position, direction, distance, groundLayer);
        if (hit.collider != null)
        {
            return true;
        }

        return false;
        
    }
    public void Sprint()
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded())
        {


            myRigidbody.linearVelocityY = 1f * playerSpeedY;
        }
        if (Input.GetKey(KeyCode.A))
        {


            myRigidbody.linearVelocityX = -2f * playerSpeedX;
            if (IsGrounded())
            {
                playerAnim.SetBool("IsSprinting", true);
            }

        }
        else if (Input.GetKey(KeyCode.D))
        {


            myRigidbody.linearVelocityX = 2f * playerSpeedX;

            if (IsGrounded())
            {
                playerAnim.SetBool("IsSprinting", true);
            }
        }
        else
        {
            playerAnim.SetBool("IsSprinting", false);

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerAnim.SetBool("IsHurt", true);
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        { 
            playerAnim.SetBool("IsHurt", true);
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            playerAnim.SetBool("IsHurt", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerAnim.SetBool("IsHurt", false);
    }

}
