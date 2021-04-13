using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    private float moveSpeed = 4;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(-9, -3.5f, 0);
;    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x<8)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }else
        {
            transform.position = new Vector3(-9, -3.5f, 0);
        }
    }
}
