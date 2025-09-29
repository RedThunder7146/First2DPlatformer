using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public int health;
    public Text healthBar;
    public GameObject gameOverScreen;
    [ContextMenu("Increase Score")]
    public void addScore(int ScoreToAdd)
    {
        playerScore += ScoreToAdd;
        scoreText.text = playerScore.ToString();
    }

    public void healthDepletion(int healthToAdd)
    {
        health -= healthToAdd;
        healthBar.text = health.ToString();
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}