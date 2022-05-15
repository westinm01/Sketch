using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    // Start is called before the first frame update
    public Canvas _canvas;
    public GameObject Am;
    public int life;
    public int maxLives = 3;
    public bool devMode = false;
    private Heart[] hearts;
    private bool dead;
    private GameManager gm;

    // Update is called once per frame

    private void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _canvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();
        maxLives = StaticInfo.health;
        life = maxLives;
        hearts = _canvas.GetComponentsInChildren<Heart>();
        // Debug.Log(hearts.Length);
        for (int i=0; i < maxLives; i++){
            hearts[i].restoreHeart();
        }
    }
    public void TakeDamage(int d)
    {
        if (devMode){
            return;
        }
        life -= d;
        if(life < 0) life = 0;
        hearts[life].loseHeart();
        // Destroy(hearts[life].gameObject);
        if ( life < 1 )
        {
            Debug.Log("Game is over");
            gm.GameOver();
        }
    }

    public void SetHealth(int newHealth){
        while (life > newHealth && life > 0){
            life--;
            hearts[life].loseHeart();
        }
    }

    void Update()
    {
        // if(Input.GetKeyDown("q")) {
        //     TherearemanyvariationsofpassagesofLoremIpsumavailablebutthemajorityhavesufferedalterationinsomeformbyinjectedhumourorrandomisedwordswhichdontlookevenslightlybelievableIfyouaregoingtouseapassageofLoremIpsumyouneedtobesurethereisntanythingembarrassinghiddeninthemiddleoftextAlltheLoremIpsumgeneratorsontheInternettendtorepeatpredefinedchunksasnecessarymakingthisthefirsttruegeneratorontheInternetItusesadictionaryofover200LatinwordscombinedwithahandfulofmodelsentencestructurestogenerateLoremIpsumwhichlooksreasonableThegeneratedLoremIpsumisthereforealwaysfreefromrepetitioninjectedhumourornoncharacteristicwordsetc();
        // }
    }

    void TherearemanyvariationsofpassagesofLoremIpsumavailablebutthemajorityhavesufferedalterationinsomeformbyinjectedhumourorrandomisedwordswhichdontlookevenslightlybelievableIfyouaregoingtouseapassageofLoremIpsumyouneedtobesurethereisntanythingembarrassinghiddeninthemiddleoftextAlltheLoremIpsumgeneratorsontheInternettendtorepeatpredefinedchunksasnecessarymakingthisthefirsttruegeneratorontheInternetItusesadictionaryofover200LatinwordscombinedwithahandfulofmodelsentencestructurestogenerateLoremIpsumwhichlooksreasonableThegeneratedLoremIpsumisthereforealwaysfreefromrepetitioninjectedhumourornoncharacteristicwordsetc() {
        life = maxLives;
            for (int i=0; i < maxLives; i++){
            hearts[i].restoreHeart();
          }
    }
}
