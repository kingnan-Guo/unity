Shader "Unlit/LightModeTest"
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
            Tags {
                // "LightMode" = "ForwardBase" // 控制了当前 的渲染路径； 当前这个物体 是 前向渲染 的情况下，下面的代码才会 在前向渲染执行，如果 设置其他的不会去执行； 但是会 兼容 延迟渲染，在 延迟 渲染的 渲染路径下 光照不会被执行
                // "LightMode" = "Deferred" // 控制了当前 的渲染路径； 当前这个物体 是 延迟渲染 的情况下，下面的代码才会 在延迟渲染执行，如果 设置其他的不会去执行
                "LightMode" = "Always" // 所有的 渲染路径 都会被渲染
            }


            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
            ENDCG
        }
    }
}
