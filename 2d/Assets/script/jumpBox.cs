using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpBox : MonoBehaviour
{
    [Range(10, 30)] public float jumpVelority = 20f;
    public LayerMask mask;
    public float boxHeight;
    private Animator _animator;
    private Vector2 playerSize;
    private Vector2 boxSize;
    private bool jumpRequest = false;
    private bool grounded = true;

    private Rigidbody2D _rigidbody2D;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        playerSize = GetComponent<SpriteRenderer>().bounds.size;
        boxSize = new Vector2(playerSize.x * 0.8f, boxHeight);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Jump")&&grounded)
        {
            jumpRequest = true;
        }
    }

    private void FixedUpdate()
    {
        if(jumpRequest)
        {
            _animator.SetBool("jump", true);
            _rigidbody2D.AddForce(Vector2.up * jumpVelority, ForceMode2D.Impulse);
            jumpRequest = false;
           
        }else
        {
            _animator.SetBool("jump", false);
            Vector2 boxCenter = (Vector2)transform.position + (Vector2.down) * playerSize.y*0.5f;
            if(Physics2D.OverlapBox(boxCenter,boxSize,0,mask)!=null) //与图层重叠 检测是否与地面接触 防止空中起跳
            {
                grounded = true;
                
            }else
            {
                grounded = false;
                
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(grounded)
        {
            Gizmos.color= Color.red;
        }else
        {
            Gizmos.color = Color.green;
        }
        Vector2 boxCenter = (Vector2)transform.position + (Vector2.down) * playerSize.y * 0.5f;
        Gizmos.DrawWireCube(boxCenter, boxSize);
    }
}
