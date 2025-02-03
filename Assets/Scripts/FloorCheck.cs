using UnityEngine;
using UnityEngine.TextCore.Text;

public class FloorCheck : MonoBehaviour
{
    Player player;
    void Start()
    {
        player = transform.parent.GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            player.onFloor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            player.onFloor = false;
        }
    }
}
