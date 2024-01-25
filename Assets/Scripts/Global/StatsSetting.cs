using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EntityType
{
    player, enemy
}

public class StatsSetting : MonoBehaviour
{
    protected EntityType entityType;
    protected int full_hp;
    protected int speed;
}
