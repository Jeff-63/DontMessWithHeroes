using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager
{

    readonly int nbEnemy = 5;
    List<Enemy> ennemies;

    public void Init()
    {
        ennemies = new List<Enemy>();
        for (int i = 0; i < nbEnemy; i++) //Création des ennemis sur la map
        {
            CreateEnnemi(i, false);
        }
        CreateEnnemi(0, true); //Création du boss sur la map
    }

    public void Update(float dt)
    {
        foreach (Enemy ennemi in ennemies)
        {
            ennemi.UpdateEnnemi(dt);
        }
    }

    public void CreateEnnemi(int i, bool isBoss)
    {
        GameObject enemyObj = new GameObject();
        int enemyType = 0;
        if (!isBoss)
        {
            enemyType = Random.Range(1, 3);
            switch (enemyType)
            {
                case 1:
                    enemyObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Orc"));
                    break;
                case 2:
                    enemyObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Elemental"));
                    break;
                default:
                    Debug.Log("Unhandled value");
                    break;
            }

            enemyObj.transform.position = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/EnnemiSpawn" + i)).transform.position;
        }
        else
        {
            enemyObj = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/Boss"));
            enemyObj.transform.position = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/BossSpawn")).transform.position;
        }
        Enemy enemy = enemyObj.GetComponent<Enemy>();
        enemy.Init(enemyType);
        ennemies.Add(enemy);
    }
}
