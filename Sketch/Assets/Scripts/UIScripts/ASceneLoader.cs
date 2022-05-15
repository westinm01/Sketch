using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ASceneLoader : MonoBehaviour
{
    [SerializeField]
    private Image _progressBar;
    // Start is called before the first frame update
    void Start()
    {
        // start async operation
        StartCoroutine(LoadAsyncOperation());
    }

    IEnumerator LoadAsyncOperation() {

        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(2); //! FIGURE out which index

        while(gameLevel.progress < 1) {
            _progressBar.fillAmount =  gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
