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
        int currIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currIndex - 52);
        StaticTournamentData.bossBool[currIndex - 52] = true;
        StaticTournamentData.health = GameObject.FindGameObjectWithTag("Player").GetComponent<HeartSystem>().life;
        
        bool isComplete = true;
        foreach (bool boss in StaticTournamentData.bossBool){
            if (!boss){
                isComplete = false;
            }
        }
        if (isComplete){
            StaticTournamentData.WinTournament();
        }

        SceneManager.LoadScene(51);
    }
}
