using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainEntry : MonoBehaviour {

    public FlowType flowTypeInitial; //type de flux
    FlowManager flowManager;

    private void Awake()
    {
        flowManager = new FlowManager(); //création du manager de flux
    }

    private void Start()
    {
        flowManager.InitializeFlow(flowTypeInitial); //initialisation du flux 
    }

    //Update du flux
    private void Update()
    {
        flowManager.UpdateFlow(Time.deltaTime);
    }

    //FixedUpdate du flux
    private void FixedUpdate()
    {
        flowManager.FixedUpdateFlow(Time.deltaTime);
    }
}
