using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{

    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
