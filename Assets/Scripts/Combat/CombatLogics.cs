﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType { Physical, Magic }
public enum ActionEnCombat { Attack, Defense, Escape }
public class CombatLogics : BaseCharacterClass
{
    readonly static float EnemyNerfValueForEscape = 0.9f;
    readonly static float CriticalHitChance = 8;
    readonly static float EvadeChance = 5;
    readonly static float CritRatio = 2;
    readonly static float BlockReduction = 2;



    public static float Attack(BaseCharacterClass attacker, BaseCharacterClass defender, AttackType atkType)
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
    public static bool DefendingAttack()
    {
        bool isBlocking = true;

        return isBlocking;

    }
    public static bool CriticalHit()
    {
        bool isCCHit = false;

        if (Random.Range(0, 100) <= CriticalHitChance) // 8% chance to crit, if you crit x2 damage
        {
            isCCHit = true;
        }


        return isCCHit;
    }
    public static bool EvadeAttack()
    {
        bool isEvading = false;

        if (Random.Range(0, 100) <= EvadeChance) //5% evading an attack, 0 damage if evaded
        {
            isEvading = true;
        }

        return isEvading;
    }
    public static bool RunAwayFromCombat(BaseCharacterClass player, BaseCharacterClass enemy)
    {
        bool isRunningAwayFromCombat = false;
        if ((player.agility * Random.Range(0, 255)) < (enemy.agility * Random.Range(0, 255) * EnemyNerfValueForEscape)) //Agil
        {
            isRunningAwayFromCombat = true;
        }



        return isRunningAwayFromCombat;
    }
}
