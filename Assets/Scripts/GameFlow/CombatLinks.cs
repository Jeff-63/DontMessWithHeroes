﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class CombatLinks : MonoBehaviour {

    [Header("Combat UI Setting")]
    public Text playerHp;
    public Text playerMana, ennemiHP, ennemiMana;
    public Image playerHpImage, playerManaImage, ennemiHPImage, ennemiManaImage, playerImage, ennemiImage;
    public Canvas CombatUiCanvas;

    [Header("CombatMachine Setting")]
    public CombatStateMachine csm;
    public CombatUI cUI;
}
