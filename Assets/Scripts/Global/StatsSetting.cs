using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EntityType
{
    player, enemy
}

public class StatsSetting : MonoBehaviour
{
    public EntityType entityType;
    public int full_hp;
    public int speed;
}
