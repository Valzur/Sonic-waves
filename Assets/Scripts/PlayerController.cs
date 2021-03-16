using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{   
    public static PlayerController MainController;
    [SerializeField]
    private VisualEffect SonicWaveEffect;
    public float WaveRate;
    public float WaveLifetime;
    public float Acceleration;
    private Rigidbody rb;
    private float TimeTillNextWave;
    [SerializeField]
    private float SoundSpeed;
    [SerializeField]
    private float MachUpdateRate;
    private float TimeTillNextMachUpdate;

    // Start is called before the first frame update
    void Start()
    {
        if(!MainController)
            MainController = this;

        rb = GetComponent<Rigidbody>();   
        TimeTillNextWave = 0;
        SonicWaveEffect.SetFloat("SoundWave speed", SoundSpeed);
        TimeTillNextMachUpdate = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Motion();
        UpdateWaves();
        UpdateMach();
    }
    private void Motion()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.forward * Acceleration, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.AddForce( - transform.forward * Acceleration, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce( - transform.right * Acceleration, ForceMode.Acceleration);
        }
        if(Input.GetKey(KeyCode.D))
        {
            rb.AddForce(transform.right * Acceleration, ForceMode.Acceleration);
        }
    }
    private void UpdateWaves()
    {
        TimeTillNextWave += Time.deltaTime;
        SonicWaveEffect.SetVector3("Center", this.transform.position);
        SonicWaveEffect.SetFloat("Lifetime", WaveLifetime);
        if(TimeTillNextWave >= 1/WaveRate)
        {
            SonicWaveEffect.Play();
            TimeTillNextWave = 0;
        }
    }
    private void UpdateMach()
    {
        TimeTillNextMachUpdate += Time.deltaTime;
        if(TimeTillNextMachUpdate>= 1/MachUpdateRate)
        {
            UI.Instance.UpdateMachText(rb.velocity.magnitude / SoundSpeed);
            TimeTillNextMachUpdate = 0;
        }
        
    }
}