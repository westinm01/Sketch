using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeduSpawnEnemy : MonoBehaviour
{
    public GameObject robot;

    public void spawnEnemy()
    {
        var temp = Instantiate(robot, new Vector2(-12, -3), Quaternion.identity);
        var temp2 = Instantiate(robot, new Vector2(12, 3), Quaternion.identity);
    }
}
