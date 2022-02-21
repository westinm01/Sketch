using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduSpawnEnemy : MonoBehaviour
{
    public GameObject robot;

    public void spawnEnemy()
    {
        RobotMovement leftBot = Instantiate(robot, new Vector2(-12, 4), Quaternion.identity).GetComponent<RobotMovement>();
        RobotMovement rightBot = Instantiate(robot, new Vector2(12, 4), Quaternion.identity).GetComponent<RobotMovement>();
        leftBot.moveDistance = 20;
        rightBot.moveDistance = 20;
        // rightBot.direction = -1;

    }
}
