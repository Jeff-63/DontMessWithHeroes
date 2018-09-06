using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux de combat
public class CombatFlow : Flow
{

    CombatUIManager uiManager;
    public static CombatLinks cl;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        cl = GameObject.FindObjectOfType<CombatLinks>(); //récupérations de tous les liens de la scene
        uiManager = new CombatUIManager();
        uiManager.Init();
    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
        uiManager.Update(dt);
    }

    //Fermeture du flux
    public override void EndFlow()
    {
        base.EndFlow();
    }
}
