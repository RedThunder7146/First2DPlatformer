using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    public float mPSpeed;
    public LayerMask mPmoveLayer;
    public Rigidbody2D mPRigidBody;
    float mPxvel = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (mPxvel < 0)
        {
            if (mPExtendedRayCollisionCheck(-2, 0) == false)
            {
                mPxvel = -mPxvel;
                
            }
        }
        if (mPxvel > 0)
        {
            if (mPExtendedRayCollisionCheck(2, 0) == false)
            {
                mPxvel = -mPxvel;
                
            }
        }
        mPRigidBody.linearVelocityX = 1f * mPxvel * mPSpeed;

    }
    public bool mPExtendedRayCollisionCheck(float xoffs, float yoffs)
    {

        float rayLength = 1.0f; // length of raycast
        bool hitSomething = false;

        // convert x and y offset into a Vector3 
        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        //cast a ray downward 
        RaycastHit2D hit;


        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, mPmoveLayer);

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