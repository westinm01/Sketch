using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduSpawnEnemy : MonoBehaviour
{
    public GameObject robot;

    public void spawnEnemy()
    {
        int botSpawned = Random.Range(0, 2);
        switch (botSpawned){
            case 0:
                RobotMovement leftBot = Instantiate(robot, new Vector2(-18, 5), Quaternion.identity).GetComponent<RobotMovement>();
                leftBot.direction = 1;
                leftBot.moveDistance = 20;
                break;
            case 1:
                RobotMovement rightBot = Instantiate(robot, new Vector2(18, 5), Quaternion.identity).GetComponent<RobotMovement>();
                rightBot.direction = -1;
                rightBot.moveDistance = 20;
                break;
        }
    }
}
