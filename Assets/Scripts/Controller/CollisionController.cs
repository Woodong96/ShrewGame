using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    WaitForSeconds delay = new WaitForSeconds(1f);
    //반복문에서 값형은 new 괜찮고 참조형은 new 빼주기


    //첫번째 부딪치면 인식
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            StartCoroutine(AttackPlayer());
        }
    }

    //첫번째 부딪혔을때 실행이지만 무한 루프로 인하여 계속 실행.
    //invoke -> 다른곳에서 가져오는 거기 때문에 무한루프를 사용하면 break가 안됨. 
    //while문이 끝나야 while 안에 있던 처리들이 한꺼번에 진행이 됨.
    IEnumerator AttackPlayer()
    {
        while (true)
        {
            GameManager.instance.CollisionEnemyToPlayer();
            //while 끝나기 전이라도 딜레이를 줄 수 있음
            yield return delay; //코루틴에서만 가능
        }
    }

    //무한루프 스탑시켜줌
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
}
