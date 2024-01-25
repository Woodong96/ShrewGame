using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    Object 스탯 사용 방법 : GameManager.instance.  을 이용해서 가져오기
    Object 스탯 수정 방법 : ObjectStatsConroller.cs 에 있는 SetStats() 에 맞는 EntityType 의 Stats을 수정.
    Object 스탯 플레이 중 수정 방법 : Hierachy - GameManger에서 수정
    Object 충돌 설정 중 ..
     */

    //-----------------------------------------------------------------------------------------------
    //사용되는 변수들. public이 아니더라도 Header와 연관되어 있다면 Header 안에 작성.
    [Header("Character")]
    public GameObject player;
    public float player_hp;
    public int player_speed;
    public int player_attack;
    public int player_defense;

    [Header("Enemy")]
    public GameObject enemy;
    public int enemy_hp;
    public int enemy_speed;
    public int enemy_attack;
    public int enemy_defense;

    [Header("UI")]

    //-----------------------------------------------------------------------------------------------
    //GameManager 에서 사용될 Component
    private ObjectStatsController statsController;

    //-----------------------------------------------------------------------------------------------
    //GameManager 싱글턴 설정 및 Component 받아오기

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
        statsController = GetComponent<ObjectStatsController>();
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


    //-----------------------------------------------------------------------------------------------
    //GameObject stats 설정
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

    //-----------------------------------------------------------------------------------------------
    //GameObject 충돌 설정
    public void CollisionPlayerToEnemy()
    {
        enemy_hp -= (int)(player_attack - (enemy_defense * 0.1f));
    }

    public void CollisionEnemyToPlayer() 
    {
        player_hp -= enemy_attack - (player_defense * 0.5f);
    }

    public void CollisonPlayerToFeed()
    {
        player_hp += 5; //Feed에 설정해둔 체력 증가
        //Destory FeedObject;
    }
}
