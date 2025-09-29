using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBarScript : MonoBehaviour
{

    public Text healthBar;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.health == 3)
        {
            GetComponent<Text>().color = Color.green;
        }
        else if (logic.health == 2)
        {
            GetComponent<Text>().color = Color.orange;
        }
        else if (logic.health == 1)
        {
            GetComponent<Text>().color = Color.red;
        }


    }
}
