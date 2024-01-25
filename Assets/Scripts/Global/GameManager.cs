using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /*
    Object 스탯 사용 방법 : GameManager.instance.  을 이용해서 가져오기
    Object 스탯 수정 방법 : Project - ScriptableObject - Data 에서 원하는 Object 스탯 수정.
    Object 스탯 플레이 중 수정 방법 : Hierachy - GameManger에서 수정
    Object 충돌 설정 중 ..
     */

    //-----------------------------------------------------------------------------------------------
    //사용되는 변수들. public이 아니더라도 Header와 연관되어 있다면 Header 안에 작성.
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
    //GameOver 시 나타나는 UI
    public GameObject gameOverBoard;
    public Text killEnemy;
    private int kill_count;
    public Text playTime;
    private float play_time;
    public Text totalScore;
    private int total_score;


    //-----------------------------------------------------------------------------------------------
    //GameManager 에서 사용될 Component
    

    //-----------------------------------------------------------------------------------------------
    //GameManager 싱글턴 설정 및 Component 받아오기

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
    //Game 초기화
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

        //점수 계산
        total_score = kill_count + (int)play_time;

        //UI 보여주기
        killEnemy.text = kill_count.ToString();
        playTime.text = play_time.ToString("N2");
        totalScore.text = total_score.ToString();
    }


    //-----------------------------------------------------------------------------------------------
    //GameObject stats 설정
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
    //GameObject 충돌 설정
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
