using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    public static ProjectileManager instance;

    [SerializeField] private GameObject testobj;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ShootBullet(Vector2 startPosition, Vector2 direction, AttackStatsSetting attackData)
    {
        GameObject obj = Instantiate(testobj);

        obj.transform.position = startPosition;
        RangedAttackController attackController = obj.GetComponent<RangedAttackController>();
        attackController.InitializeAttack(direction, attackData, this);

        obj.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
