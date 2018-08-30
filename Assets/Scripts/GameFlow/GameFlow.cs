﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Flux du jeu
public class GameFlow : Flow {

    public static GameLinks gl;
    PlayerManager playerManager;

    public override void InitializeFlow() //initialisation de tous éléments du flux
    {
        base.InitializeFlow();
        gl = GameObject.FindObjectOfType<GameLinks>(); //récupérations de tous les liens du jeu
        playerManager = new PlayerManager();


        playerManager.Init();// initialisation du joueur

    }

    //Update de tous éléments du flux
    public override void Update(float dt)
    {
        base.Update(dt);
        playerManager.Update();
    }

    //FixedUpdate de tous éléments du flux
    public override void FixedUpdate(float dt)
    {
        base.FixedUpdate(dt);
    }

    //Fermeture du flux
    public override void EndFlow()
    {
        base.EndFlow();
    }
}
