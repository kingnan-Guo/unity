// 基础 数据类型
Shader "Unlit/CGDataBaseType"
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

            // 基础数据类型
            struct test{
                int i;
                float f;
            }

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);

                // 基础数据类型
                uint a = 1;
                int b = -2;
                float c = 3.0f;// 32位浮点数 
                bool d = true;
                fixed e = 4.0;// 12 位 浮点数
                half f = 5.0h;// 16位 浮点数
                fixed4 g = 6.0;
                half4 h = 7.0;
                float4 i = 8.0;
                float4x4 j = 9.0;
                float3x3 k = 10.0;
                float2x2 l = 11.0;

                sample sam ;// 纹理对象句柄 贴图； 处理不同纬度 类型的 纹理
                sampler2D Sam2D; // 处理 2维图像


                float arrayf[3] = {1,2,3};

                float arrff[2][2] = {{1, 2}, {2, 3}}
                // arrff.length
                // arrff[0].length

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);



                fixed2 f2 = fixed2(1.2, 2.5);

                float3 f3 = float3(1.2, 2.5, 3.6);

                // 矩阵  不大于 4  不小于 11
                int2x3 mint2x3 = {
                    1,2,3,
                    4,5,6
                };


                // bool 类型同样可以 用于 如同 向量一样声明
                // bool3 a = bool3(true, false, true);
                float3 a = float (1, 2, 3);
                float3 b = float (4, -5, 6);

                bool c = a < b;

                // 运算后 向量c 的结果 bool3(true, false, true);


                return col;
            }
            ENDCG
        }
    }
}
