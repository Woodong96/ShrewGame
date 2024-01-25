using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Character")]
    public GameObject player;
    private float player_hp;
    private int player_speed;

    [Header("Enemy")]
    private int enemy_hp;
    private int enemy_speed;

    //[Header("UI")]


    //private StatsSettingController statsController;


    private void Awake()
    {
        instance = this;
        //statsController = GetComponent<StatsSettingController>();
    }

    //private void Start()
    //{
    //    PlayerStats();
    //    EnemyStats();
    //}

    //private void Update()
    //{
    //    player_hp -= Time.deltaTime;
    //}

    //private void PlayerStats()
    //{
    //    statsController.SetStats(EntityType.player);
    //    player_hp = statsController.GetFullHp();
    //    player_speed = statsController.GetSpeed();
    //}

    //private void EnemyStats()
    //{
    //    statsController.SetStats(EntityType.enemy);
    //    enemy_hp = statsController.GetFullHp();
    //    enemy_speed = statsController.GetSpeed();
    //}
}
