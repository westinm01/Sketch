using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASceneLoader : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    private float tafini = 0;
    public static int nextScene;
    public static string nextScene_str;
    public static bool is_str = false;

    [SerializeField]
    [Range(0,1)]
    private float speed_multiplyer = .5f;
    // Start is called before the first frame update
    void Start()
    {
        // start async operation
        StartCoroutine(LoadAsyncOperation());
    }

    public static void LoadScene(int index) { // must be used to load scene
        ASceneLoader.nextScene = index;
        ASceneLoader.is_str = false;
        SceneManager.LoadScene(64);
    }

    public static void LoadScene(string name) {
        ASceneLoader.nextScene_str = name;
        ASceneLoader.is_str = true;
        SceneManager.LoadScene(64);
    }

    IEnumerator LoadAsyncOperation() {
        AsyncOperation gameLevel;
        if(ASceneLoader.is_str) {
            gameLevel = SceneManager.LoadSceneAsync(nextScene_str); 
        } else {
            gameLevel = SceneManager.LoadSceneAsync(nextScene); 
        }
        
      gameLevel.allowSceneActivation = false;
        while(gameLevel.progress < 1) {
            tafini = Mathf.MoveTowards(tafini, gameLevel.progress/.9f, speed_multiplyer*Time.deltaTime);
            _progressBar.fillAmount =  tafini;
            if(_progressBar.fillAmount >= 1) {
                gameLevel.allowSceneActivation = true;
            }
            yield return new WaitForEndOfFrame();
        }

        
    }
}
