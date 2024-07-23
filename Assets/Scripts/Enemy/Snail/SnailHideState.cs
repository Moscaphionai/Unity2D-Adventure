using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnailHideState : BaseState
{
    private float introHealth;
    public override void OnEnter(Enemy enemy)
    {
        currentEnemy = enemy;
        introHealth = currentEnemy.character.currentHealth;
        //currentEnemy.hurtForce /= 3;
        currentEnemy.currentSpeed = 0;
        currentEnemy.anim.SetBool("hide", true);
        (currentEnemy as Snail).isHide = true;
    }

    public override void LogicUpdate()
    {
        if (currentEnemy.lostTimeCounter <= 0)
        {
            currentEnemy.SwitchState(NPCState.Patrol);
        }
        currentEnemy.character.currentHealth = introHealth;

    }

    public override void PhysicsUpdate()
    {
        
    }

    public override void OnExit()
    {
        currentEnemy.lostTimeCounter = currentEnemy.lostTime;
        //currentEnemy.hurtForce *= 3;
        currentEnemy.anim.SetBool("hide", false);
        (currentEnemy as Snail).isHide = false;
    }
}
