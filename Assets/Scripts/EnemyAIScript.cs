using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public Animator SlimeAnim;
    public LayerMask groundLayer;
    public Rigidbody2D slimeRigidBody;
    float xvel = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (xvel < 0)
        {
            if (ExtendedRayCollisionCheck(-2, 0) == false)
            {
                xvel = -xvel;
                SlimeAnim.SetBool("IsRunning", true);
            }
        }
        if (xvel >0)
        {
            if (ExtendedRayCollisionCheck(2, 0) == false)
            {
                xvel = -xvel;
                SlimeAnim.SetBool("IsRunning", true);
            }
        }
            
        
        if (xvel ==0)
        {
            SlimeAnim.SetBool("IsRunning", false);
        }
        slimeRigidBody.linearVelocityX = 1f * xvel * Speed;
    }
       
    


    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        
        float rayLength = 1.0f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayer);

        Color hitColor = Color.purple;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
            hitSomething = true;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position + offset, Vector3.down * rayLength, hitColor);

        return hitSomething;

    }

}
