using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EntityType
{
    player, enemy, feed
}

[CreateAssetMenu(fileName = "DefaultStatsData", menuName = "StatsData/default", order = 0)]

public class DefaultStatsSetting :ScriptableObject
{
    [Header("Stats Info")]
    public EntityType entityType;
    public int full_hp;
    public int speed;
}
