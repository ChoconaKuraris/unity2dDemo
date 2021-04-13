using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controller : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    private float x; //水平移动判定
    private float y;
    private float moveSpeed=3.0f;
    


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal"); //默认水平方向是 ad键
        
  
        if(Input.GetKeyDown(KeyCode.H))
        {
            _animator.SetBool("blink", true);
        }
        if (Input.GetKeyUp(KeyCode.H))
        {
            _animator.SetBool("blink",false);
        }

        Vector3 move = new Vector3(x, y, 0);
        walk(move);
        
        death();



    }

    private void death()
    {
        if(transform.position.y<-4)
        {
            gameController.Instance.showGameoverPanel();
            gameObject.SetActive(false);
        }
    }

    private void walk(Vector3 dir)
    {
        
        
        if (Mathf.Abs(x) > 0.01f )
        {
            _rigidbody2D.transform.position += dir * moveSpeed * Time.deltaTime;
            _animator.SetBool("run", true);
            //改变scale实现左右反转
            if (x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }

        }else
        {
            _animator.SetBool("run", false);
        }


    }
}
