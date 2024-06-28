// Shader "Custom/OutlineShader"
// {
//     Properties
//     {
//         _MainTex ("Texture", 2D) = "white" {}
//         _OutlineColor ("Outline Color", Color) = (1,1,1,1)
//         _OutlineWidth ("Outline Width", Range(0, 1)) = 0.1
//     }
//     SubShader
//     {
//         // 在不透明物体之后渲染
//         Tags { "Queue"="Transparent" "RenderType"="Transparent" }
//         LOD 100
 
//         Pass
//         {
//             // 使用透明度渲染
//             Blend SrcAlpha OneMinusSrcAlpha
 
//             CGPROGRAM
//             #pragma vertex vert
//             #pragma fragment frag
 
//             #include "UnityCG.cginc"
 
//             struct appdata
//             {
//                 float4 vertex : POSITION;
//                 float2 uv : TEXCOORD0;
//             };
 
//             struct v2f
//             {
//                 float2 uv : TEXCOORD0;
//                 float4 vertex : SV_POSITION;
//                 float4 screenPos : TEXCOORD1;
//             };
 
//             sampler2D _MainTex;
//             float4 _MainTex_ST;
//             fixed4 _OutlineColor;
//             float _OutlineWidth;
 
//             v2f vert (appdata v)
//             {
//                 v2f o;
//                 o.vertex = UnityObjectToClipPos(v.vertex);
//                 o.uv = TRANSFORM_TEX(v.uv, _MainTex);
//                 o.screenPos = ComputeScreenPos(o.vertex);
//                 return o;
//             }
 
//             fixed4 frag (v2f i) : SV_Target
//             {
//                 // 获取屏幕空间下的颜色
//                 float4 screenColor = tex2D(_MainTex, i.uv);
 
//                 // 检查当前像素与相邻像素的差异
//                 float diff = abs(dot(ddx(screenColor), ddy(screenColor)));
 
//                 // 如果像素与相邻像素颜色或法线方向有较大差异，则认为是边缘
//                 fixed4 finalColor = lerp(_OutlineColor, screenColor, step(diff, _OutlineWidth));
 
//                 return finalColor;
//             }
//             ENDCG
//         }
//     }
// }



Shader "Custom/OutlineShader"
{
    Properties
    {
        _MainTex("渲染纹理",2D)="white"{}
        _SecondTex("",2D)="white"{}
        _BlurArea("模糊范围",float)=1.0
    }
    SubShader
    {
        //类似C++的头文件，可以减少重复代码    
        CGINCLUDE
        #include "UnityCG.cginc"

        sampler2D _MainTex;
        float4 _MainTex_TexelSize;
        float _BlurArea;

        struct a2v
        {
            float4 vertex:POSITION;
            float2 texcoord:TEXCOORD0;
        };

        struct v2f
        {
            float4 pos:SV_POSITION;
            float2 uv[5]:TEXCOORD0;
        };

        v2f vertVertical(a2v v)
        {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            //将纹理坐标计算放在顶点着色器中，由于传递是线性插值，所以并不会影响结果
            o.uv[0] = v.texcoord;
            o.uv[1] = v.texcoord + float2(0, _MainTex_TexelSize.y * 1.0) * _BlurArea;
            o.uv[2] = v.texcoord - float2(0, _MainTex_TexelSize.y * 1.0) * _BlurArea;
            o.uv[3] = v.texcoord + float2(0, _MainTex_TexelSize.y * 2.0) * _BlurArea;
            o.uv[4] = v.texcoord - float2(0, _MainTex_TexelSize.y * 2.0) * _BlurArea;

            return o;
        }

        v2f vertHorizontal(a2v v)
        {
            v2f o;
            o.pos = UnityObjectToClipPos(v.vertex);
            //注意这里是x方向的偏移
            o.uv[0] = v.texcoord;
            o.uv[1] = v.texcoord + float2(_MainTex_TexelSize.x * 1.0, 0) * _BlurArea;
            o.uv[2] = v.texcoord - float2(_MainTex_TexelSize.x * 1.0, 0) * _BlurArea;
            o.uv[3] = v.texcoord + float2(_MainTex_TexelSize.x * 2.0, 0) * _BlurArea;
            o.uv[4] = v.texcoord - float2(_MainTex_TexelSize.x * 2.0, 0) * _BlurArea;

            return o;
        }

        fixed4 frag_Blur(v2f i):SV_Target
        {
            float weight[3] = {0.4026, 0.2442, 0.0545};
            fixed3 color = tex2D(_MainTex, i.uv[0]) * weight[0];
            //权重计算
            for (int j = 1; j < 3; j++)
            {
                color += tex2D(_MainTex, i.uv[j * 2 - 1]) * weight[j];
                color += tex2D(_MainTex, i.uv[j * 2]) * weight[j];
            }
            return fixed4(color, 1);
        }
        ENDCG

        //用于横向模糊
        Pass
        {
            NAME "GAUSSIAN_VERTICAL"
            CGPROGRAM
            #pragma vertex vertHorizontal
            #pragma fragment frag_Blur
            ENDCG
        }
        //用于纵向模糊
        Pass
        {
            NAME "GAUSSIAN_HORIZONTAL"
            CGPROGRAM
            #pragma vertex vertVertical
            #pragma fragment frag_Blur
            ENDCG
        }
        //用于提取模糊后的边缘
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //存放着模糊后的纹理
            sampler2D _SecondTex;
            struct a2v_1
            {
                float4 vertex:POSITION;
                float2 texcoord:TEXCOORD0;
            };

            struct v2f_1
            {
                float4 pos:SV_POSITION;
                float2 uv:TEXCOORD0;
            };
            v2f_1 vert(a2v_1 v)
            {
                v2f_1 o;
                o.pos=UnityObjectToClipPos(v.vertex);
                o.uv=v.texcoord;
                return o;
            }
            fixed4 frag(v2f_1 i):SV_Target
            {
                fixed3 texResult1=tex2D(_MainTex,i.uv);
                fixed3 texResult2=tex2D(_SecondTex,i.uv);
                return fixed4(texResult2-texResult1,1);
            }
            ENDCG
        }
        //用于混合原图像
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            //存放着提取后的纹理
            sampler2D _SecondTex;
            struct a2v_1
            {
                float4 vertex:POSITION;
                float2 texcoord:TEXCOORD0;
            };

            struct v2f_1
            {
                float4 pos:SV_POSITION;
                float2 uv:TEXCOORD0;
            };
            v2f_1 vert(a2v_1 v)
            {
                v2f_1 o;
                o.pos=UnityObjectToClipPos(v.vertex);
                o.uv=v.texcoord;
                return o;
            }
            fixed4 frag(v2f_1 i):SV_Target
            {
                fixed3 texResult1=tex2D(_MainTex,i.uv);
                fixed3 texResult2=tex2D(_SecondTex,i.uv);
                return fixed4(texResult2+texResult1,1);
            }
            ENDCG
            
        }
    }
}