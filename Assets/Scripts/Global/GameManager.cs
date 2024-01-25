using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    Object ���� ��� ��� : GameManager.instance.  �� �̿��ؼ� ��������
    Object ���� ���� ��� : Project - ScriptableObject - Data ���� ���ϴ� Object ���� ����.
    Object ���� �÷��� �� ���� ��� : Hierachy - GameManger���� ����
    Object �浹 ���� �� ..
     */

    //-----------------------------------------------------------------------------------------------
    //���Ǵ� ������. public�� �ƴϴ��� Header�� �����Ǿ� �ִٸ� Header �ȿ� �ۼ�.
    [Header("Character")]
    public GameObject player;
    public AttackStatsSetting playerAttackStats;
    public float player_hp;
    public int player_speed;
    public int player_attack;
    public int player_defense;

    [Header("Enemy")]
    public GameObject enemy;
    public AttackStatsSetting enemyAttackStats;
    public int enemy_hp;
    public int enemy_speed;
    public int enemy_attack;
    public int enemy_defense;

    [Header("Feed")]
    public GameObject feed;
    public DefaultStatsSetting feedStats;
    public int feed_plus_hp;
    private int feed_count;

    [Header("UI")]
    public Image playerHP;


    //-----------------------------------------------------------------------------------------------
    //GameOver �� ��Ÿ���� UI
    public GameObject gameOverBoard;
    public Text killEnemy;
    private int kill_count;
    public Text playTime;
    private float play_time;
    public Text totalScore;
    private int total_score;


    //-----------------------------------------------------------------------------------------------
    //GameManager ���� ���� Component
    

    //-----------------------------------------------------------------------------------------------
    //GameManager �̱��� ���� �� Component �޾ƿ���

    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    private void Update()
    {
        player_hp -= Time.deltaTime;
        play_time += Time.deltaTime;
        if (player_hp < 0)
        {
            EndGame();
        }
    }

    //-----------------------------------------------------------------------------------------------
    //Game �ʱ�ȭ
    private void StartGame()
    {
        PlayerStats();
        EnemyStats();
        FeedStats();
        kill_count = 0;
        play_time = 0.0f;
        total_score = 0;
    }

    //-----------------------------------------------------------------------------------------------
    //GameOver
    private void EndGame()
    {
        Time.timeScale = 0;
        gameOverBoard.SetActive(true);

        //���� ���
        total_score = kill_count + (int)play_time;

        //UI �����ֱ�
        killEnemy.text = kill_count.ToString();
        playTime.text = play_time.ToString("N2");
        totalScore.text = total_score.ToString();
    }


    //-----------------------------------------------------------------------------------------------
    //GameObject stats ����
    private void PlayerStats()
    {
        player_hp = playerAttackStats.full_hp;
        player_speed = playerAttackStats.speed;
        player_attack = playerAttackStats.attack;
        player_defense = playerAttackStats.defense;
    }

    private void EnemyStats()
    {
        enemy_hp = enemyAttackStats.full_hp;
        enemy_speed = enemyAttackStats.speed;
        enemy_attack = enemyAttackStats.attack;
        enemy_defense = enemyAttackStats.defense;
    }

    private void FeedStats()
    {
        feed_plus_hp = feedStats.full_hp;
    }

    //-----------------------------------------------------------------------------------------------
    //GameObject �浹 ����
    public void CollisionPlayerToEnemy()
    {
        enemy_hp -= (int)(player_attack - (enemy_defense * 0.1f));
        if(enemy_hp < 0)
        {
            Destroy(enemy);
            kill_count++;
        }
    }

    public void CollisionEnemyToPlayer() 
    {
        player_hp -= enemy_attack - (player_defense * 0.5f);
    }

    public void CollisionPlayerToFeed()
    {
        player_hp += feed_plus_hp;
        Destroy(feed);
    }
}
