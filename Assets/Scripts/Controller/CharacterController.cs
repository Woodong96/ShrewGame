using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action<AttackStatsSetting> OnAttackEvent;

    private float _timeSinceLastAttack = float.MaxValue;
    protected bool IsAttacking { get; set; }
    // Start is called before the first frame update

    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        if (_timeSinceLastAttack <= GameManager.instance.playerAttackStats.delay)
        {
            _timeSinceLastAttack += Time.deltaTime;
        }

        else if (IsAttacking && _timeSinceLastAttack > GameManager.instance.playerAttackStats.delay)
        {
            _timeSinceLastAttack = 0;
            CallAttackEvent(GameManager.instance.playerAttackStats);
        }
    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }

    public void CallAttackEvent(AttackStatsSetting attackData)
    {
        OnAttackEvent?.Invoke(attackData);
    }
}
