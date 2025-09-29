using Unity.VisualScripting;
using UnityEngine;

public class enemyChaseAI : MonoBehaviour
{

    public Transform Player;
    public float distance;
    public float Speed;
    public float distanceBetween;
    public Animator SlimeAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        Vector2 direction = Player.transform.position - transform.position;





        if (distance <= distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, Player.transform.position, Speed * Time.deltaTime);
            SlimeAnim.SetBool("IsRunning", true);

        }
    }
}
