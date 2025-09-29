using UnityEngine;

public class CameraFollowPlayerScript : MonoBehaviour
{
    public Transform player;

    void Update()
    {
        transform.position = new Vector3(player.position.x + 6, 0, -10);
    }
}