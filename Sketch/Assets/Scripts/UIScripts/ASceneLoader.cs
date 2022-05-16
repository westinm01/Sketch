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

    [SerializeField]
    [Range(0,1)]
    private float speed_multiplyer = .5f;
    // Start is called before the first frame update
    void Start()
    {
        // start async operation
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation() {

        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(20); //! FIGURE out which index
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
