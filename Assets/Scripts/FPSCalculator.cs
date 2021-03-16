using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FPSCalculator : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI FPSText;
    [SerializeField]
    private float FPSUpdateRate;
    private float TimeTillNextUpdate;
    void Start()
    {
        Application.targetFrameRate = 0;
        TimeTillNextUpdate = 0;
    }
    // Update is called once per frame
    void Update()
    {
        TimeTillNextUpdate += Time.deltaTime;
        if(TimeTillNextUpdate >= 1.0/FPSUpdateRate)
        {
            FPSText.text = (int)(1.0/Time.deltaTime) + " FPS";
            TimeTillNextUpdate = 0;
        }
    }
}
