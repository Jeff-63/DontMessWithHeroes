using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceState : MonoBehaviour
{
   

    public void OnClickAttackChoice()
    {
        float damage = CombatLogics.Attack(CombatFlow.cl.PlayerCharacter, CombatFlow.cl.EnemyCharacter);
        CombatFlow.cl.EnemyCharacter.currentHP = CombatFlow.cl.EnemyCharacter.currentHP - (int)damage;
        OmniEnemy.Instance.currentHP = CombatFlow.cl.EnemyCharacter.currentHP;
        CombatFlow.cl.csm.currentState = CombatStateMachine.BattleStates.ENEMYCHOICE;
    }
    public void OnClickDefenseChoice()
    {
        CombatFlow.cl.csm.isDefending = true;
        CombatFlow.cl.csm.currentState = CombatStateMachine.BattleStates.ENEMYCHOICE;
    }
    public void OnClickEscapeChoice()
    {
        bool isEscaping = false;
        isEscaping = CombatLogics.RunAwayFromCombat(CombatFlow.cl.PlayerCharacter, CombatFlow.cl.EnemyCharacter);
        if(isEscaping)
        {
            CombatFlow.cl.csm.currentState = CombatStateMachine.BattleStates.ESCAPE;
        }
        else
        {
            CombatFlow.cl.csm.currentState = CombatStateMachine.BattleStates.ENEMYCHOICE;
        }

    }


}
