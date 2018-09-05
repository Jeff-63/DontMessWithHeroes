using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum AttackType { Physical, Magic }
public enum ActionEnCombat { Attack, Defense, Escape }
public class CombatLogics
{
    readonly static float EnemyNerfValueForEscape = 0.9f;
    readonly static float CriticalHitChance = 8;
    readonly static float EvadeChance = 5;
    readonly static float CritRatio = 2;



    public static float Attack(BaseCharacterClass attacker, BaseCharacterClass defender)
    {
        float damageDealt = 0;
        AttackType atkType;
        Debug.Log("Is evading atk : " + EvadeAttack());
        if (!EvadeAttack())
        {
            atkType = (attacker.isPhysicalAttacker) ? AttackType.Physical: AttackType.Magic;


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

    public static bool CriticalHit()
    {



       // bool isCCHit = false;
       //
       // if (Random.Range(0, 100) <= CriticalHitChance) // 8% chance to crit, if you crit x2 damage
       // {
       //     isCCHit = true;
       // }
       //
       //
       // return isCCHit;

        return (Random.Range(0, 100) <= CriticalHitChance); // same thing as the code above
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
