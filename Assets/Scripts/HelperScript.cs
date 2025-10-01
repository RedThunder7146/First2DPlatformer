using UnityEngine;
using UnityEngine.SceneManagement;

public class HelperScript : MonoBehaviour
{

    public void DoFlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }

    public void HelloWorld()
    {
        print("Hello World");
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
    public void ResetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
