using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreTable : MonoBehaviour
{
    private Transform EntryContainer;
    private Transform EntryTemplate;
    private void Awake()
    {
        EntryContainer = transform.Find("HighScoreEntryContainer");
        EntryTemplate = EntryContainer.Find("HighScoreEntryTemplate");

        EntryTemplate.gameObject.SetActive(false);
        float TemplateHeight = 20f;
        for(int i= 0;i<10;i++)
        {
            Transform EntryTransform = Instantiate(EntryTemplate, EntryContainer);
            RectTransform EntryRecTransform = EntryTransform.GetComponent<RectTransform>();
            EntryRecTransform.anchoredPosition = new Vector2(0, -TemplateHeight*i);
            EntryTransform.gameObject.SetActive(true);

        }
    }
}
