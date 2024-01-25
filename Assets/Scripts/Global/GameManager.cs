using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Character")]
    public GameObject player;
    [SerializeField] private float player_hp;
    [SerializeField] private int player_speed;
    [SerializeField] private int player_attack;
    [SerializeField] private int player_defense;

    [Header("Enemy")]
    [SerializeField] private int enemy_hp;
    [SerializeField] private int enemy_speed;
    [SerializeField] private int enemy_attack;
    [SerializeField] private int enemy_defense;

    [Header("UI")]

    

    private StatsSettingController statsController;


    private void Awake()
    {
        instance = this;
        statsController = GetComponent<StatsSettingController>();
    }

    private void Start()
    {
        PlayerStats();
        EnemyStats();
    }

    private void Update()
    {
        player_hp -= Time.deltaTime;
        
        if (player_hp < 0)
        {
            Time.timeScale = 0;

            //GameOver UI
        }
    }

    private void PlayerStats()
    {
        statsController.SetStats(EntityType.player);
        player_hp = statsController.GetFullHp();
        player_speed = statsController.GetSpeed();
        player_attack = statsController.GetAttack();
        player_defense = statsController.GetDefense();
    }

    private void EnemyStats()
    {
        statsController.SetStats(EntityType.enemy);
        enemy_hp = statsController.GetFullHp();
        enemy_speed = statsController.GetSpeed();
        enemy_attack = statsController.GetAttack();
        enemy_defense = statsController.GetDefense();
    }
}
