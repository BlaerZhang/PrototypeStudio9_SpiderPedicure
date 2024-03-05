using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using KnobsAsset;
using UnityEngine;
using Random = UnityEngine.Random;

public class LegLengthManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioController audioController;
    public List<GameObject> legPivots;
    public List<GameObject> legSliders;
    [Range(0, 1)] public List<float> legLengths;

    private List<Rigidbody> allRigidbodys;

    void Start()
    {
        allRigidbodys = FindObjectsOfType<Rigidbody>().ToList();
        audioController = GameObject.Find("Audio Manager").GetComponent<AudioController>();
        foreach (var rigidbody in allRigidbodys)
        {
            rigidbody.isKinematic = true;
        }

        foreach (var slider in legSliders)
        {
            slider.GetComponent<SliderKnob>().enabled = false;
            slider.GetComponent<SliderKnob>().AmountMoved = Random.Range(0f,4f);
            slider.GetComponent<SliderKnob>().enabled = true;
        }

    }
    
    void Update()
    {

        for (int i = 0; i < legPivots.Count; i++)
        {
            legPivots[i].transform.localScale = new Vector3(1, legLengths[i] * 1.4f + 0.1f, 1);
        }

        if (CheckIfAnySliderGrabbed()) audioController.SetVolume(1);
        else audioController.SetVolume(0);
    }

    private void OnDisable()
    {
        foreach (var slider in legSliders)
        {
            slider.SetActive(false);
        }
        Invoke("StartRace", 3f);
    }

    private bool CheckIfAnySliderGrabbed()
    {
        foreach (var slider in legSliders)
        {
            if (slider.GetComponent<SliderKnob>().grabbed)
            {
                return true;
            }
        }
        return false;
    }

    void StartRace()
    {
        foreach (var rigidbody in allRigidbodys)
        {
            rigidbody.isKinematic = false;
        }

        foreach (var pivot in legPivots)
        {
            pivot.transform.DetachChildren();
        }
    }
}
