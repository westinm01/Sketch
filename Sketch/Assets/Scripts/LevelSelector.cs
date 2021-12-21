using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelSelector : MonoBehaviour
{
    public GameObject currSelected;

    public void selectMap(GameObject selected){
        if (currSelected != null){
            currSelected.SetActive(false);
        }
        currSelected = selected;
        currSelected.SetActive(true);
    }
    public void LoadLevel(string levelName){
        SceneManager.LoadScene(levelName);
    }
}
