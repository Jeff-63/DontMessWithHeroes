using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType { Physical, Magic }
public class CombatLogics : BaseCharacterClass
{
    readonly float EnemyNerfValueForEscape = 0.9f;
    readonly float CriticalHitChance = 8;
    readonly float EvadeChance = 5;
    readonly float CritRatio = 2;
    readonly float BlockReduction = 2;



    public float Attack(BaseCharacterClass attacker, BaseCharacterClass defender, AttackType atkType)
    {
        float damageDealt = 0;
        if (!EvadeAttack())
        {
            if (atkType == AttackType.Physical)
            {
                if (CriticalHit())
                {
                    damageDealt = (attacker.strenght - defender.endurance) * CritRatio;
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
                    damageDealt = (attacker.intelligence - defender.intelligence) * CritRatio;
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

                damageDealt = (attacker.strenght - defender.endurance) / BlockReduction;
            }
            else
            {
                damageDealt = (attacker.intelligence - defender.intelligence) / BlockReduction;
            }
        }



        return damageDealt;
    }
    public bool CriticalHit()
    {
        bool isCCHit = false;

        if (Random.Range(0, 100) <= CriticalHitChance) // 8% chance to crit, if you crit x2 damage
        {
            isCCHit = true;
        }


        return isCCHit;
    }
    public bool EvadeAttack()
    {
        bool isEvading = false;

        if (Random.Range(0, 100) <= EvadeChance) //5% evading an attack, 0 damage if evaded
        {
            isEvading = true;
        }

        return isEvading;
    }
    public bool RunAwayFromCombat(BaseCharacterClass player, BaseCharacterClass enemy)
    {
        bool isRunningAwayFromCombat = false;
        if ((player.agility * Random.Range(0, 255)) < (enemy.agility * Random.Range(0, 255) * EnemyNerfValueForEscape)) //Agil
        {
            isRunningAwayFromCombat = true;
        }



        return isRunningAwayFromCombat;
    }
}
