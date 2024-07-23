using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : Enemy
{
    
    [Header("Snail±‰¡ø")]
    public bool isHide;

    protected override void Awake()
    {
        base.Awake();
        patrolState = new SnailWalkState();
        hideState = new SnailHideState();
    }
    public override void OnTakeDamage(Transform attackTrans)
    {
        if (!isHide)
        {
            base.OnTakeDamage(attackTrans);
        }
        else
        {
            attacker = attackTrans;
            Vector2 dir = new Vector2(transform.position.x - attackTrans.position.x, 0).normalized;
            StartCoroutine(OnHurt(dir));
        }
    }

}
