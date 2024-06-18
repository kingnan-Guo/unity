using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum E_UI_Layer
{
    Bottom,
    Middle,
    Top,
    System
}


public class UIManager : baseManager<UIManager>
{
    public Dictionary<string, BasePanel> PanelDict = new Dictionary<string, BasePanel>();
    private Transform canvas;

    private Transform bottom;
    private Transform middle;
    private Transform top;
    private Transform system;
    public UIManager(){
       
        // 找到 canvas 对象  
        GameObject gameObject = ResourcesMgr.getInstance().Load<GameObject>("baseProject/UI/Canvas");
        canvas = gameObject.transform;
        // 过场景不移除
        GameObject.DontDestroyOnLoad(gameObject);

        bottom = canvas.Find("Bottom");
        middle = canvas.Find("Middle");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        
            
        // 找到 EventSystem 对象
        gameObject =ResourcesMgr.getInstance().Load<GameObject>("baseProject/UI/EventSystem");
            // 过场景不移除
        GameObject.DontDestroyOnLoad(gameObject);
    }


    //// <summary>
    /// 显示 面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="PlaneName">面板名称</param>
    /// <param name="layer">图层</param>
    /// <param name="callback">当面板预设体 创建 成功后 ，获取到脚本 回调</param>
    /// <returns></returns>
    public void ShowPanel<T>(string PlaneName, E_UI_Layer layer = E_UI_Layer.Middle, UnityAction<T> callback = null) where T: BasePanel
    {

        if(PanelDict.ContainsKey(PlaneName)){
            
            PanelDict[PlaneName].Show();
            if (callback != null)
            {
                callback(PanelDict[PlaneName] as T);
            }
            return;
        }
        ResourcesMgr.getInstance().LoadAsync<GameObject>(PlaneName, (obj) => {
            //做为 canvas 的子对象
            //并且  要设置它的相对位置
            Transform father = bottom;
            switch (layer)
            {
                case E_UI_Layer.Bottom:
                    father = bottom;
                    break;
                case E_UI_Layer.Middle:
                    father = middle;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
                default:
                    father = middle;
                    break;
            }

            // 设置 父对象
            obj.transform.SetParent(father);
            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;


            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;


            // 得到预设体上的 面板 脚本
            T panel = obj.GetComponent<T>();
            // 处理 面板 调用后的逻辑
            // 回调  
            if (callback != null)
            {
                callback(panel);
            }


            panel.Show();
            // 存入 脚本 ；方便 调用
            PanelDict.Add(PlaneName, panel);

        });
            
    }


    /// <summary>
    /// 隐藏 面板
    /// </summary>
    /// <param name="PlaneName">面板名称</param>
    public void HidePanel(string PlaneName){
        if (PanelDict.ContainsKey(PlaneName))
        {
            PanelDict[PlaneName].Hide();
            GameObject.Destroy(PanelDict[PlaneName].gameObject);
            PanelDict.Remove(PlaneName);
            return;
        }
    }

    public void DestroyPanel(string PlaneName){

    }
}
