using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField]
    private float Force;
    [SerializeField]
    private GameObject BulletPrefab;
    [SerializeField]
    private Transform ShootPosition;
    [SerializeField]
    private Animator TurretAnimator;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        TurretAnimator.SetBool("shoot", true);
        //
       //GameObject Bullet = Instantiate(BulletPrefab,ShootPosition);
      // Bullet.GetComponent<Rigidbody>().AddForce(Force*Bullet.transform.forward, ForceMode.Impulse);
    }
}
