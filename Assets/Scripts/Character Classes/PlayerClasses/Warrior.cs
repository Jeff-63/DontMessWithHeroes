using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : BaseCharacterClass
{
    
    public Warrior()
    {
        characterClass = CharacterClasses.Warrior;
        characterClassDescription = "The Warrior is skilled in combat, and usually can make use of some of the most powerful heavy armor and weaponry in the game. As such, the warrior is a well-rounded physical combatant.";

        characterLevel = 1;
        experience = 0;
        maxExperience = 25;
        strenght = 35;
        endurance = 14;
        intelligence = 8;
        agility = 9;
        currentHP = 100;
        maxHP = 100;
        isPhysicalAttacker = true;
    }




}
