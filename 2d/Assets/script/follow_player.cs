using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class follow_player : MonoBehaviour
{
    private Transform m_playerTransform;
    private Transform backgroundTransform;
    private Renderer backgroundRenderer;
    private float left_boundary;
    private float right_boundary;

    //设定一个角色能看到的最远值
    private float Ahead = 5f;

    //设置一个摄像机要移动到的点
    private Vector3 targetPos;

    //设置一个缓动速度插值
    private float smooth = 6.5f;

    // Start is called before the first frame update
    void Start()
    {
        //获取当前角色的transform
        m_playerTransform = GameObject.Find("player").GetComponent<Transform>();

        //获取场景边界
        backgroundTransform = GameObject.Find("Background").GetComponent<Transform>();
        backgroundRenderer = GameObject.Find("Background").GetComponent<Renderer>();
        float width = backgroundRenderer.bounds.size.x;
        left_boundary = backgroundTransform.position.x - width / 2;
        right_boundary = backgroundTransform.position.x + width / 2;
        

    }

    // Update is called once per frame
    void Update()
    {
        targetPos = new Vector3(m_playerTransform.position.x, m_playerTransform.transform.position.y, gameObject.transform.position.z);

        if (m_playerTransform.position.x < (left_boundary))
        {
            targetPos = new Vector3(m_playerTransform.position.x + Ahead, m_playerTransform.transform.position.y, gameObject.transform.position.z);
        } 
        if(m_playerTransform.position.x> (left_boundary))
        {
            targetPos = new Vector3(m_playerTransform.position.x - Ahead, m_playerTransform.transform.position.y, gameObject.transform.position.z);
        }
       

        transform.position = Vector3.Lerp(transform.position, targetPos, smooth * Time.deltaTime); //平滑移动
    }
}
