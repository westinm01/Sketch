using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TournamentEndofLevel : MonoBehaviour
{
    private void Awake()
    {
        DataSave.LoadData();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WinGame(collision);
            // GameObject.Find("Canvas").transform.GetChild(13).gameObject.SetActive(true);
        }
    }
    public static void WinGame(Collider2D collision)
    {
        SceneManager.LoadScene(49);
    }
}
