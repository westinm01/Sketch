using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class TournamentSelect : LevelSelector
{
    protected override void Start(){
        // DO nothing
    }
    private void OnEnable()
    {
        DataSave.LoadData();

        if (StaticTournamentData.bossBool[0] == true) GameObject.Find("Othal").GetComponent<Image>().color = OthalCompletionColor;

        if (StaticTournamentData.bossBool[1] == true) GameObject.Find("Roc").GetComponent<Image>().color = RocCompletionColor;

        if (StaticTournamentData.bossBool[2] == true) GameObject.Find("Medu").GetComponent<Image>().color = MeduCompletionColor;

        if (StaticTournamentData.bossBool[3] == true) GameObject.Find("Pitu").GetComponent<Image>().color = PituCompletionColor;

        if (StaticTournamentData.bossBool[4] == true) GameObject.Find("Ippoc").GetComponent<Image>().color = IppocCompletionColor;

        if (StaticTournamentData.bossBool[5] == true) GameObject.Find("Dal").GetComponent<Image>().color = DalCompletionColor;

        if (StaticTournamentData.bossBool[6] == true) GameObject.Find("Tempra").GetComponent<Image>().color = TempraCompletionColor;

        if (StaticTournamentData.bossBool[7] == true) GameObject.Find("Wer").GetComponent<Image>().color = WerCompletionColor;

        if (StaticTournamentData.bossBool[8] == true) GameObject.Find("Thala").GetComponent<Image>().color = ThalaCompletionColor;

        if (StaticTournamentData.bossBool[9] == true) GameObject.Find("Ine").GetComponent<Image>().color = IneCompletionColor;

        if (StaticTournamentData.bossBool[10] == true) GameObject.Find("Occi").GetComponent<Image>().color = OcciCompletionColor;

        if (StaticTournamentData.bossBool[11] == true) GameObject.Find("Po").GetComponent<Image>().color = PoCompletionColor;
    }

    public override void goBack()
    {
        SceneManager.LoadScene(1);
    }
}
