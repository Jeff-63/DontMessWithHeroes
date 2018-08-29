using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass {

    public string characterClass; // for player : spellcaster or warrior -- for ennemies : enemy type 
    public string characterClassDescription;

    //stats
    public int characterLevel;
    public int experience;
    public int maxExperience; // will increase for each level up (1.5x current xp?)
    public int strenght; // physical attack power
    public int endurance; // physical defense 
    public int intellienge; //magic attack power and magic defense
    public int agility; // affects critical hits, accuracy of attacks and possibility of evading an attack
    public int currentHP; // value of health at the current moment
    public int maxHP; // max value for health, can increase with the levels

}
