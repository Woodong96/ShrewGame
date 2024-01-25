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
                attack = 10;
                defense = 15;
                break;
            case EntityType.enemy:
                full_hp = 30;
                speed = 1;
                attack = 5;
                defense = 3;
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

    public int GetAttack()
    {
        return attack;
    }

    public int GetDefense()
    {
        return defense;
    }
}
