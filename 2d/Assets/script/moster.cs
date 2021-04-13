using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moster : MonoBehaviour
{
    private float speed = 2f;
    public LayerMask layer;
    public Transform headPoint;
    public Transform rightUp;
    public Transform rightDown;

    private bool _collided; //绘制一个竖线来检测碰撞
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();


    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 move = new Vector3(speed, _rigidbody.velocity.y, 0);
        transform.position += move*Time.deltaTime;
        _collided = Physics2D.Linecast(rightUp.position,rightDown.position,layer); //绘制一个竖线来检测碰撞

        if(_collided)
        {
            Debug.DrawLine(rightUp.position, rightDown.position,Color.red);
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y,0);
            speed = -speed;
        }
        else
        {
            Debug.DrawLine(rightUp.position, rightDown.position, Color.green);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            float height = collision.contacts[0].point.y - headPoint.position.y; //第一个碰撞点减去自定义头部的y值
            if(height>0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 8.0f, ForceMode2D.Impulse);
                speed = 0;
                _boxCollider.enabled = false;
                _rigidbody.bodyType = RigidbodyType2D.Kinematic;
                Destroy(gameObject, 1f);
            }
        }
    }
}
