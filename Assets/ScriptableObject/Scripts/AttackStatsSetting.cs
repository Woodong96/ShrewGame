using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackStatsData", menuName = "StatsData/attack", order = 1)]
public class AttackStatsSetting : DefaultStatsSetting
{
    [Header("Attack Stats Info")]
    public string bulletNameTag;
    public int attack;
    public int defense;
    public float delay;
    public int projectileSpeed;
    public LayerMask target;
}
