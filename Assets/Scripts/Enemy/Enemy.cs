using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    
    int orc = 1;
    int elemental = 2;
    public BaseCharacterClass bcc;

    public void Init(int enemyType)
    {
        if (enemyType == orc)
        {
            bcc = new Orc();
        }
        else if(enemyType == elemental)
        {
            bcc = new Elemental();
        }
        else
        {
            bcc = new Boss();
        }
    }


    public void SaveEnemy()
    {
        OmniEnemy.Instance.characterClass = bcc.characterClass;
        OmniEnemy.Instance.characterLevel = bcc.characterLevel;
        OmniEnemy.Instance.experience = bcc.experience;
        OmniEnemy.Instance.maxExperience = bcc.maxExperience;
        OmniEnemy.Instance.strenght = bcc.strenght;
        OmniEnemy.Instance.endurance = bcc.endurance;
        OmniEnemy.Instance.intelligence = bcc.intelligence;
        OmniEnemy.Instance.agility = bcc.agility;
        OmniEnemy.Instance.currentHP = bcc.currentHP;
        OmniEnemy.Instance.maxHP = bcc.maxHP;
        OmniEnemy.Instance.currentMana = bcc.currentMana;
        OmniEnemy.Instance.maxMana = bcc.maxMana;
    }
}
