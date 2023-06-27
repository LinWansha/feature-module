using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    Vector3 dir= Vector3.zero;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        dir=new Vector3(h,0,v);
        if (dir != Vector3.zero)
        {
            transform.LookAt(dir+transform.position);
            transform.Translate(Vector3.forward * 3 * Time.deltaTime);
        }
    }
}
