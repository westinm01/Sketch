using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
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
        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel <= 37)
        {
            StaticInfo.levelBool[currentLevel - 2] = true;
        }
        else if (currentLevel == 38)
        {
            StaticInfo.bossBool[0] = true;
        }

        DataSave.SaveData();

        // Time.timeScale = 0;

        // collision.gameObject.GetComponent<Am_Movement>().enabled = false;
        // collision.gameObject.GetComponent<ChangePencilMode>().enabled = false;
        // collision.gameObject.GetComponent<AmCombat>().enabled = false;
        // collision.gameObject.GetComponent<HeartSystem>().enabled = false;
        // collision.gameObject.GetComponent<AmAbyss>().enabled = false;
        // collision.gameObject.GetComponent<Animator>().enabled = false;
        // collision.gameObject.GetComponentInChildren<Ground_Check>().enabled = false;
        // collision.gameObject.GetComponentInChildren<Shape_Creation>().enabled = false;
        // collision.gameObject.GetComponentInChildren<Shape_Erase>().enabled = false;
        SceneManager.LoadScene(1);
    }
}