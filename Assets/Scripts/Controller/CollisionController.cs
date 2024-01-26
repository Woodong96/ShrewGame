using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    WaitForSeconds delay = new WaitForSeconds(1f);
    //�ݺ������� ������ new ������ �������� new ���ֱ�


    //ù��° �ε�ġ�� �ν�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            StartCoroutine(AttackPlayer());
        }
    }

    //ù��° �ε������� ���������� ���� ������ ���Ͽ� ��� ����.
    //invoke -> �ٸ������� �������� �ű� ������ ���ѷ����� ����ϸ� break�� �ȵ�. 
    //while���� ������ while �ȿ� �ִ� ó������ �Ѳ����� ������ ��.
    IEnumerator AttackPlayer()
    {
        while (true)
        {
            GameManager.instance.CollisionEnemyToPlayer();
            //while ������ ���̶� �����̸� �� �� ����
            yield return delay; //�ڷ�ƾ������ ����
        }
    }

    //���ѷ��� ��ž������
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
}
