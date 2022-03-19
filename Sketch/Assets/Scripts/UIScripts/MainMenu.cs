using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        int totalLevelsDone = 0;
        for (int i=0; i < 12; i++){
            totalLevelsDone += StaticInfo.levelInt[i];
            if (StaticInfo.bossBool[i] == true) ++totalLevelsDone;
        }
        
        if (totalLevelsDone == 0){      // If no levels have been done, load the tutorial
            SceneManager.LoadScene(2);
        }
        else{
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit Successful");
        Application.Quit();
    }
}
