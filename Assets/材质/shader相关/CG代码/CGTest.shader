Shader "Unlit/NewUnlitShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag


            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;// 顶点着色器在代码中的使用
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

 
            /// 顶点着色器 定位
            v2f vert (appdata v)
            {
                v2f o;
                return o;
            }

            // 片元着色器 定位函数
            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col;
                // apply fog

                return col;
            }
            ENDCG


            // CGPROGRAM
            // #pragma //声明编译指令； 实现顶点片元着色器代码的函数名称
            // // #pragma vertex name // 顶点着色器 的函数名
            // // #pragma fragment name // 片元着色器 的函数名（之后在这两个函数中  写 shader）

            // ENDCG
        }
    }
}
