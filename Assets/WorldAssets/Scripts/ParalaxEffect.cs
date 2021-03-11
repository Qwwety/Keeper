using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxEffect : MonoBehaviour
{
    private float lenth;
    private float StartTops;
    [SerializeField] private GameObject Camera;
    [SerializeField] private float paralaxEffect;

    void Start()
    {
        StartTops = transform.position.x;
        lenth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        float Temp = (Camera.transform.position.x*(1-paralaxEffect));
        float Dist= (Camera.transform.position.x *  paralaxEffect);

        transform.position = new Vector3(StartTops + Dist, transform.position.y, transform.position.x);

        if (Temp>StartTops+lenth) 
        {
            StartTops += lenth;
        }else if (Temp<StartTops- lenth) 
        {
            StartTops -= lenth;
        }
    }


}
