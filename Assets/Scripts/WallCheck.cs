using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour
{
    public Player player;
    public bool left;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            if (left)
                player.leftWall = true;
            else
                player.rightWall = true;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            if (left)
                player.leftWall = false;
            else
                player.rightWall = false;

        }
    }
}
