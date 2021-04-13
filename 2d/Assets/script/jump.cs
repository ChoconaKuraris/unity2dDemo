using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    private float jumpVelocity = 10f;
    private Rigidbody2D _rigidbody2D;
    private bool jumpRequest = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Jump"))
        {
            jumpRequest = true;
            
        }
    }
   

    private void FixedUpdate() //物理引擎的更新
    {
        if(jumpRequest)
        {
            _rigidbody2D.AddForce(Vector2.up * jumpVelocity, ForceMode2D.Impulse); //不断叠加
            jumpRequest = false;
        }

    }
}
