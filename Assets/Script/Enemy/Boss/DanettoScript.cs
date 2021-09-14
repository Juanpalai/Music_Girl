using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanettoScript : MonoBehaviour
{
    public GameObject Bullet;
    [SerializeField]
    private float bulletInterval_min = 1.0f;
    [SerializeField]
    private float bulletInterval_max = 1.0f;
    private float count = 0.0f;


    void Update()
    {
        count += Time.deltaTime;

        //弾--------------------------------------------------------------------
        if (count >= Random.Range(bulletInterval_min, bulletInterval_max))
        {
            GameObject _bullet = Bullet;

            Instantiate(_bullet, transform.position + new Vector3(-4.0f, -3.5f, 0f), transform.rotation);


            _bullet = null;
            count = 0.0f;
        }
        //-----------------------------------------------------------------------
    }
}
