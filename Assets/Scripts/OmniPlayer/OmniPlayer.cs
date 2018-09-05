using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmniPlayer : MonoBehaviour {

    public static OmniPlayer Instance;
    public CharacterClasses characterClass;
    public int characterLevel;
    public int experience;
    public int maxExperience; // will increase for each level up (1.5x current xp?)
    public int strenght; // physical attack power
    public int endurance; // physical defense 
    public int intelligence; //magic attack power and magic defense
    public int agility; // affects critical hits, accuracy of attacks and possibility of evading an attack
    public int currentHP; // value of health at the current moment
    public int maxHP; // max value for health, can increase with the levels
    public int currentMana; // value of mana at the current moment
    public int maxMana; // max value of mana, can be increased with the levels
    public Vector2 position;//keep position for when we change scene

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}
