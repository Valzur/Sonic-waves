using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    public static UI Instance;
    [SerializeField]
    private TextMeshProUGUI MachNoText;
    [SerializeField]
    private Camera MainCam;
    [Header("Properties")]
    [SerializeField]
    private Property WaveRate;
    [SerializeField]
    private Property WaveLifetime;
    [SerializeField]
    private Property CameraOffset;
    [SerializeField]
    private Property Acceleration;
    
    // Start is called before the first frame update
    void Start()
    {
        if(!Instance)
            Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateMachText(float M)
    {
        MachNoText.text = "Current Velocity: " + M + " Mach";
    }
    public void WaveRateSlideCallBack(float progress)
    {
        float Rate = Mathf.Lerp(WaveRate.MinValue,WaveRate.MaxValue,progress);
        //Update Text
        WaveRate.Text.text = "Wave spawn rate: " + Rate + "/s";
        //Update the Actual variable;
        PlayerController.MainController.WaveRate = Rate;
    }
    public void WaveLifetimeSliderCallBack(float progress)
    {
        float Rate = Mathf.Lerp(WaveLifetime.MinValue,WaveLifetime.MaxValue,progress);
        //Update Text
        WaveLifetime.Text.text = "Wave Lifetime: " + Rate + "s";
        //Update the Actual variable;
        PlayerController.MainController.WaveLifetime = Rate;
    }
    public void CameraOffsetSliderCallBack(float progress)
    {
        float Rate = Mathf.Lerp(CameraOffset.MinValue,CameraOffset.MaxValue,progress);
        //Update Text
        CameraOffset.Text.text = "Camera offset: " + Rate;
        //Update the Actual variable;
        MainCam.transform.localPosition = new Vector3(0,Rate,0);
    }

    public void AccelerationSliderCallBack(float progress)
    {
        float Rate = Mathf.Lerp(Acceleration.MinValue,Acceleration.MaxValue,progress);
        //Update Text
        Acceleration.Text.text = "Acceleration: " + (Rate/4.0) + "M/s";
        //Update the Actual variable;
        PlayerController.MainController.Acceleration = Rate;
    }
    public void ExitButtonCallBack()
    {
        Application.Quit();
    }
}