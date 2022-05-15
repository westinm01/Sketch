using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EncyclopediaDetailedView : MonoBehaviour
{
    public Image[] enemies;
    public Text[] names;
    public string[] entries;

    public Image[] stages;

    public Text nameText;
    public TextMeshProUGUI entryText;
    public Image enemySprite;

    public GameObject scrollList;

    private int index = 0;
    private void Start()
    {
        for (int i = 0; i < entries.Length; i++)
        {
            entries[i] = entries[i].Replace("\\n", "\n");
        }
    }
    public void IncreaseIndexPosition()
    {
        index = (index + 1) % names.Length;

        checkVolcano1();
        updateStages();
        nameText.text = names[index].text;
        entryText.text = entries[index];
        enemySprite.sprite = enemies[index].sprite;
    }

    public void DecreaseIndexPosition()
    {
        --index;
        if (index < 0) index = names.Length - 1;

        checkVolcano1();
        updateStages();
        nameText.text = names[index].text;
        entryText.text = entries[index];
        enemySprite.sprite = enemies[index].sprite;
    }

    public void updateStages()
    {
        int offset = index / 3;

        stages[0].sprite = enemies[offset * 3].sprite;
        stages[1].sprite = enemies[offset * 3 + 1].sprite;
        stages[2].sprite = enemies[offset * 3 + 2].sprite;
    }

    public void checkVolcano1()
    {
        if (index == 48) nameText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-655, 55);
        else nameText.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(-655, 78);
    }

    public void updateList()
    {
        checkVolcano1();
        updateStages();
        nameText.text = names[index].text;
        entryText.text = entries[index];
        enemySprite.sprite = enemies[index].sprite;
    }

    public void detailedView(int i)
    {
        scrollList.SetActive(false);
        gameObject.SetActive(true);
        index = i;
        updateList();
    }
}
