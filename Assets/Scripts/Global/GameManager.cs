using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    Object ���� ��� ��� : GameManager.instance.  �� �̿��ؼ� ��������
    Object ���� ���� ��� : ObjectStatsConroller.cs �� �ִ� SetStats() �� �´� EntityType �� Stats�� ����.
    Object ���� �÷��� �� ���� ��� : Hierachy - GameManger���� ����
    Object �浹 ���� �� ..
     */

    //-----------------------------------------------------------------------------------------------
    //���Ǵ� ������. public�� �ƴϴ��� Header�� �����Ǿ� �ִٸ� Header �ȿ� �ۼ�.
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
    //GameManager ���� ���� Component
    private ObjectStatsController statsController;

    //-----------------------------------------------------------------------------------------------
    //GameManager �̱��� ���� �� Component �޾ƿ���

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
    //GameObject stats ����
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
    //GameObject �浹 ����
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
        player_hp += 5; //Feed�� �����ص� ü�� ����
        //Destory FeedObject;
    }
}
