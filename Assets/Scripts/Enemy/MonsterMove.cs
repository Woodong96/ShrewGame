using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
   
    public float CreateTime = 0.0f; // �����ǰ� �� �� ���ʰ� ��������
    public float speed = 0.05f; // ������ �̵��ϴ� �ӵ�
    public float deleteTIme = 3.0f; // ���� ������ ������ �ð�
    public float moveTIme = 0.1f; // ���� ������ �����̱� �����ϴ� �ð�
    public bool canmove = false; // �����̴� �Ұ�
    public bool candelete = false; // �����Ǵ� �Ұ�

    public GameObject target; // �̵��� ��ġ ������ ������Ʈ

    private void Awake() // Start���� ����� ����
    {
        target = GameObject.FindGameObjectWithTag("Player"); // ������ ������� ���� Tag�� ������Ʈ�� target�� �־���
    }
    private void Update()
    {
        CreateTime += Time.deltaTime; // �����ǰ� �� ���� �ð��� ������
        if (CreateTime >= moveTIme) // ������ �ð��� ������ �� �ִ� �ð����� �������� canmove true
            canmove = true;

        if (CreateTime >= deleteTIme) // ������ �ð��� �����ð����� �������� candelete true
            candelete = true;

        if (canmove) // canmove = true
            transform.position = Vector2.MoveTowards(gameObject.transform.position, target.transform.position,speed);
        //�� ������Ʈ�� ��ġ�� Vector2���� ��� �־� target.transform.position���� �̵���Ŵ �ӵ��� speed�� ���� ũ��� �̵�
        if (candelete) // candelete = true
            Destroy(gameObject); // �� ���ӿ�����Ʈ �ı�
    }
}
