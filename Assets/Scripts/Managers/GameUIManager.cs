using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIManager
{
    GameUI gameUI;
    public void Init()
    {
        gameUI = GameFlow.gl.gui;
        gameUI.Initialize();
    }

    public void Update(float dt)
    {
        gameUI.UpdateUI(dt);
    }

}
