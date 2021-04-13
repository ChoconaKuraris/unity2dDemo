using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Better_jump : MonoBehaviour
{
    public float fallMaltiplier = 2.5f;
    public float lowMaltiplier = 2.0f;
    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FIxUpdate()
    {
        if (_rigidbody2D.velocity.y < 0) //下降
        {
            _rigidbody2D.gravityScale = +fallMaltiplier;

        }
        else if (_rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            _rigidbody2D.gravityScale = lowMaltiplier;
        }else
        {
            _rigidbody2D.gravityScale = 1f;
        }
    }


}
