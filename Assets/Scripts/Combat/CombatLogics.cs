using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType { Physical, Magic }
public class CombatLogics : BaseCharacterClass
{
    readonly float EnemyNerfValueForEscape = 0.9f;
    readonly float CriticalHitChance = 8;
    readonly float EvadeChance = 5;



    public float Attack(BaseCharacterClass attacker, BaseCharacterClass defender, AttackType atkType)
    {
        float damageDealt = 0;
        if (!EvadeAttack())
        {
            if (atkType == AttackType.Physical)
            {
                if (CriticalHit())
                {
                    damageDealt = (attacker.strenght - defender.endurance) * 2;
                }
                else
                {
                    damageDealt = (attacker.strenght - defender.endurance);
                }

            }
            else
            {
                if (CriticalHit())
                {
                    damageDealt = (attacker.intelligence - defender.intelligence) * 2;
                }
                else
                {
                    damageDealt = (attacker.intelligence - defender.intelligence);
                }

            }
        }




        return damageDealt;
    }
    public float DefendingAttack(BaseCharacterClass attacker, BaseCharacterClass defender, AttackType atkType)
    {
        float damageDealt = 0;
        if (!EvadeAttack())
        {
            if (atkType == AttackType.Physical)
            {

                damageDealt = (attacker.strenght - defender.endurance) / 2;
            }
            else
            {
                damageDealt = (attacker.intelligence - defender.intelligence) / 2;
            }
        }



        return damageDealt;
    }
    public bool CriticalHit()
    {
        bool isCCHit = false;

        if (Random.Range(0, 100) <= CriticalHitChance)
        {
            isCCHit = true;
        }


        return isCCHit;
    }
    public bool EvadeAttack()
    {
        bool isEvading = false;

        if (Random.Range(0, 100) <= EvadeChance)
        {
            isEvading = true;
        }

        return isEvading;
    }
    public bool RunAwayFromCombat(BaseCharacterClass player, BaseCharacterClass enemy)
    {
        bool isRunningAwayFromCombat = false;
        if ((player.agility * Random.Range(0, 255)) < (enemy.agility * Random.Range(0, 255) * EnemyNerfValueForEscape))
        {
            isRunningAwayFromCombat = true;
        }



        return isRunningAwayFromCombat;
    }
}
