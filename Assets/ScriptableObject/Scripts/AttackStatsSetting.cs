using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "AttackStatsData", menuName = "StatsData/attack", order = 1)]
public class AttackStatsSetting : DefaultStatsSetting
{
    [Header("Attack Stats Info")]
    public int attack;
    public int defense;
}
