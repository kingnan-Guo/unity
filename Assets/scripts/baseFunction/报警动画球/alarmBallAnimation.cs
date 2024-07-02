using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarmBallAnimation : MonoBehaviour
{

    public int speed = 100;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        // 
        // this.gameObject.transform.

        // 缩放动画
        // this.gameObject.transform.localScale = new Vector3(1, 1, 1);
        // this.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        // 旋转动画
        // this.gameObject.transform.Rotate(new Vector3(0, 0, 1), 100 * Time.deltaTime);

        // 透明度动画
        this.gameObject.AddComponent<SpriteRenderer>();
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Time time = Time
        // Debug.Log(Time.deltaTime);

        time += Time.deltaTime;
        if ( time < 1)
        {
            this.gameObject.transform.localScale = new Vector3(time, time, time);     
        }  else {
            time = 0;
        }

        // 缩放动画
        



    }
}
