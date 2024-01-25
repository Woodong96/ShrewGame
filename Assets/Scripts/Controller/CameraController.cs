using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private float position_x;
    private float position_y;

    void Update()
    {
        player = GameManager.instance.player.transform;

        if(player.position.x < -52 || player.position.x > 52)
        {
            position_x = 52 * ((player.position.x > 0) ? 1: -1);
        }
        else
        {
            position_x = player.position.x;
        }
        if(player.position.y < -35 || player.position.y > 35)
        {
            position_y = 35 * ((player.position.y > 0) ? 1 : -1);
        }
        else
        {
            position_y = player.position.y;
        }

        transform.position = new Vector3(position_x, position_y, transform.position.z);
    }
}
