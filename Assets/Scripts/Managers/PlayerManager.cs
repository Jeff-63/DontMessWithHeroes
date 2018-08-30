using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager {
    Player player;
    Vector3 startingPos = new Vector3();

    public void Init()
    {
        CreatePlayer();
    }
    public void Update()
    {

    }
    public void CreatePlayer()
    {
        GameObject playerObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Player")); //crée instance joueur
        player.transform.position = startingPos;
        player = playerObj.GetComponent<Player>();
        player.Init();
    }

    
}
