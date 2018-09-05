using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceState : MonoBehaviour
{


    public void OnClickAttackChoice()
    {
        Debug.Log("ATTACK");
        float damage = CombatLogics.Attack(CombatFlow.cl.PlayerCharacter, CombatFlow.cl.EnemyCharacter);

        CombatFlow.cl.EnemyCharacter.currentHP = CombatFlow.cl.EnemyCharacter.currentHP - (int)damage;
        OmniEnemy.Instance.currentHP = CombatFlow.cl.EnemyCharacter.currentHP;
        
    }

}
