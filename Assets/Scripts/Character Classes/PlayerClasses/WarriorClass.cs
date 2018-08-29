﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorClass : BaseCharacterClass
{


    public WarriorClass()
    {
        characterClass = "Warrior";
        characterClassDescription = "The Warrior is skilled in combat, and usually can make use of some of the most powerful heavy armor and weaponry in the game. As such, the warrior is a well-rounded physical combatant.";

        characterLevel = 1;
        experience = 0;
        maxExperience = 100;
        strenght = 16;
        endurance = 14;
        intelligence = 8;
        agility = 9;
        currentHP = 100;
        maxHP = 100;
    }




}