using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathScript : MonoBehaviour
{
    public LogicScript logic;
    public Animator playerAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            logic.healthDepletion(1);
            playerAnim.SetBool("IsHurt", true);
        }
        else
        {
            playerAnim.SetBool("IsHurt", false);
        }
    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            playerAnim.SetBool("IsHurt", true);
        }
        else
        {
            playerAnim.SetBool("IsHurt", false);
        }
    }


    
}
