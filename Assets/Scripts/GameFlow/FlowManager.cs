using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FlowType { None, GameFlow, CombatFlow, MainMenuFlow }

public class FlowManager{

    FlowType currentActiveFlowType; //type de flux actif
    Flow currentFlow; //flux actif

    // Initialisation du flux de type donné en paramètre
    public void InitializeFlow(FlowType _initializeFlowType)
    {

        if (_initializeFlowType == FlowType.None)
        {
            Debug.Log("Cannot Initialize flowType");
            return;
        }

        if (_initializeFlowType == currentActiveFlowType)
        {
            Debug.Log("Flow already initialized");
            return;
        }

        if (currentFlow != null) 
        {
            currentFlow.EndFlow(); //Si un flux est déja ouvert, le fermer
            currentFlow = null;
            currentActiveFlowType = FlowType.None;
        }

        switch (_initializeFlowType) // Initialisation du nouveau flux
        {
            case FlowType.GameFlow:
                currentFlow = new GameFlow();
                break;

            case FlowType.CombatFlow:
                currentFlow = new CombatFlow();
                break;

            case FlowType.MainMenuFlow:
                currentFlow = new MainMenuFlow();
                break;

            default:
                Debug.Log("Unhandeled switch : " + _initializeFlowType);
                break;
        }

        currentFlow.InitializeFlow();

    }

    //Update du flux actuel
    public void UpdateFlow(float dt)
    {
        if (currentFlow != null)
        {
            currentFlow.Update(dt);
        }
    }

    //FixedUpdate du flux actuel
    public void FixedUpdateFlow(float dt)
    {
        if (currentFlow != null)
        {
            currentFlow.FixedUpdate(dt);
        }
    }

}

