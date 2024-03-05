using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishingLine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if (GameManager.instance.isRaceStarted && !GameManager.instance.isRaceFinished)
        {
            if (other.gameObject.CompareTag("Colorful"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "ColorfulLife";
            }

            if (other.gameObject.CompareTag("Crawler"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "Literally_Crawler";
            }
            
            if (other.gameObject.CompareTag("Lucky"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "Lucky Anyway";
            }
            
            if (other.gameObject.CompareTag("Viper"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "8_Leg_Viper";
            }
            
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = GameObject.Find("InputField").GetComponent<TMP_InputField>().text;
            }

            if (other.gameObject.CompareTag("Spired"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "SpiRed";
            }
            
            if (other.gameObject.CompareTag("Wand8"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "IGot8ofWands";
            }
            
            if (other.gameObject.CompareTag("NetRunner"))
            {
                GameManager.instance.isRaceFinished = true;
                GameManager.instance.winnerName = "NetRunner";
            }
        }
    }
}
