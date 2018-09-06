using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class GameLinks : MonoBehaviour {

    [Header ("Camera Setting")]
    public CinemachineVirtualCamera vcam;
    [Header("Player UI Setting")]
    public GameUI gui;
    public Text level;
    public Text hp, strength, endurance, intelligence, agility, experience;
}
