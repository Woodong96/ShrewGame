using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Character")]
    public GameObject player;
    private int player_hp;
    private int player_speed;


    private StatsSettingController statsController;


    private void Awake()
    {
        instance = this;
        statsController = GetComponent<StatsSettingController>();
    }

    private void Start()
    {
        player_hp -= (int)Time.deltaTime;
    }

    private void PlayerStats()
    {
        statsController.SetStats(EntityType.player);
        player_hp = statsController.GetFullHp();
        player_speed = statsController.GetSpeed();
    }
}
