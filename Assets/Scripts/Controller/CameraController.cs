using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform player;
    private float position_x;
    private float position_y;

    void Update()
    {
        player = GameManager.instance.player.transform;

        if(player.position.x < -52 || player.position.x > 54)
        {
            if (player.position.x < 0)
            {
                position_x = -52;
            }
            else
            {
                position_x = 54;
            }
        }
        else
        {
            position_x = player.position.x;
        }
        if(player.position.y < -38 || player.position.y > 35)
        {
            if (player.position.y < 0)
            {
                position_y = -38;
            }
            else
            {
                position_y = 35;
            }
        }
        else
        {
            position_y = player.position.y;
        }

        transform.position = new Vector3(position_x, position_y, transform.position.z);
    }
}
