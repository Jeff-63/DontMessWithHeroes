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
    readonly static Vector2 MinMaxRandomEscape = new Vector2(0, 255);
    readonly static Vector2 MinMaxRandomCCandEvade = new Vector2(0, 100);



    public static float Attack(BaseCharacterClass attacker, BaseCharacterClass defender)
    {
        float damageDealt = 0;
        AttackType atkType;
        if (!EvadeAttack())
        {
            atkType = (attacker.isPhysicalAttacker) ? AttackType.Physical : AttackType.Magic;


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
        if (damageDealt < 0)
        {
            damageDealt = 0;
        }

        return damageDealt;
    }

    public static bool CriticalHit()
    {
        return (Random.Range(MinMaxRandomCCandEvade.x, MinMaxRandomCCandEvade.y) <= CriticalHitChance); // same thing as the code above
    }
    public static bool EvadeAttack()
    {
        bool isEvading = false;

        if (Random.Range(MinMaxRandomCCandEvade.x, MinMaxRandomCCandEvade.y) <= EvadeChance) //5% evading an attack, 0 damage if evaded
        {
            isEvading = true;
        }

        return isEvading;
    }
    public static bool RunAwayFromCombat(BaseCharacterClass player, BaseCharacterClass enemy)
    {
        bool isRunningAwayFromCombat = false;
        if ((player.agility * Random.Range(MinMaxRandomEscape.x, MinMaxRandomEscape.y)) < (enemy.agility * Random.Range(MinMaxRandomEscape.x, MinMaxRandomEscape.y) * EnemyNerfValueForEscape)) //Agil
        {
            isRunningAwayFromCombat = true;
        }



        return isRunningAwayFromCombat;
    }
}
