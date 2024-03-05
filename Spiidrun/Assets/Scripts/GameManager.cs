using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using KnobsAsset;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> rivalPrefabs;
    public TextMeshProUGUI subText;
    public bool isRaceStarted;
    public bool isRaceFinished;
    public float raceTime;
    public string winnerName;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        isRaceStarted = false;
        isRaceFinished = false;
    }
    
    void Update()
    {
        if (isRaceStarted && raceTime >= 0 && !isRaceFinished)
        {
            raceTime -= Time.deltaTime;
            subText.text = raceTime.ToString("F");
        }

        if (raceTime <= 0)
        {
            subText.text = "Time Out! No Winner!\nLeft Click to Restart";
            if (Input.GetMouseButton(0)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (isRaceFinished)
        {
            subText.text = winnerName + " Wins\nLeft Click to Restart";
            if (Input.GetMouseButton(0)) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnRaceStart()
    {
        for (int i = 0; i < rivalPrefabs.Count; i++)
        {
            GameObject rival = Instantiate(rivalPrefabs[i]);
            LegLengthManager rivalLegLengthManager = rival.GetComponentInChildren<LegLengthManager>();
            // for (int j = 0; j < rivalLegLengthManager.legSliders.Count; j++)
            // {
            //     rivalLegLengthManager.legSliders[j].GetComponent<SliderKnob>().enabled = false;
            //     rivalLegLengthManager.legSliders[j].GetComponent<SliderKnob>().AmountMoved = Random.Range(0f,4f);
            //     rivalLegLengthManager.legSliders[j].GetComponent<SliderKnob>().enabled = true;
            // }

            StartCoroutine(DisableLegLengthManager(rivalLegLengthManager));
        }

        Sequence countDown = DOTween.Sequence();
        countDown
            .Append(subText.DOText("3", 0))
            .AppendInterval(1)
            .Append(subText.DOText("2", 0))
            .AppendInterval(1)
            .Append(subText.DOText("1", 0))
            .AppendInterval(1)
            .OnComplete((() => { isRaceStarted = true; }));

        countDown.Play();
    }

    IEnumerator DisableLegLengthManager(LegLengthManager rivalLegLengthManager)
    {
        yield return new WaitForSeconds(0.01f);
        rivalLegLengthManager.enabled = false;
    }
}
