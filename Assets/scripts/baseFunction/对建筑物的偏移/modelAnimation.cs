using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 动画管理器
// 用于对建筑物的动画进行管理
// 例如：建筑物的动画播放、暂停、停止等
public class modelAnimation : baseManager<modelAnimation>
{
    // 播放动画
    public void PlayAnimation(string animationName)
    {
        // 在这里实现播放动画的逻辑
    }

    // 拉出楼层
    public void PullOut(GameObject floor, Vector3 position)
    {
        // 在这里实现拉出楼层的逻辑
    }

    // 将楼层放回原位
    public void PushBack(GameObject floor, Vector3 position)
    {
        // 在这里实现将楼层放回原位的逻辑
    }

    // 逐帧动画
    public void FrameAnimation(GameObject floor)
    {
        // 在这里实现逐帧动画的逻辑
    }



}
