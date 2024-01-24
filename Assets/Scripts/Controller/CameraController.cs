using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private GameObject player;

    void Update()
    {
        player = GameManager.instance.player;
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }
}
