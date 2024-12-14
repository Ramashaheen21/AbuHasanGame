using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScroll : MonoBehaviour
{

    private Transform abuhasan;
    // Start is called before the first frame update
    void Start()
    {
        abuhasan = GameObject.FindWithTag("AbuHasan").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // set the camera position x axis to be the palyer position
        Vector3 cameraPos = transform.position;
        cameraPos.x = Mathf.Max(cameraPos.x , abuhasan.position.x);
        transform.position = cameraPos;
    }
}
