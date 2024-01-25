using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsSettingController : StatsSetting
{
    public void SetStats(EntityType entityType)
    {
        switch (entityType)
        {
            case EntityType.player:
                full_hp = 100;
                speed = 5;
                break;
            case EntityType.enemy:
                full_hp = 100;
                speed = 5;
                break;
        }
    }

    public int GetFullHp()
    {
        return full_hp;
    }

    public int GetSpeed()
    {
        return speed;
    }
}
