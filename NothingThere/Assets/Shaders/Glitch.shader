Shader "Hidden/Glitch"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _DistortTex ("Distoration Texture", 2D) = "black" {}
        _Force ("Force", Range(0, 1)) = 0.2
        _Scale ("Scale", Float) = 1
        _TimeDisplacement ("Time Displacement", Vector) = (0, 0, 0, 0)
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _MainTex;
            sampler2D _DistortTex;
            float _Force, _Scale;
            float2 _TimeDisplacement;

            fixed4 frag(v2f i) : SV_Target
            {
                half4 displace = tex2D(_DistortTex, i.uv * _Scale + _TimeDisplacement.xy * _Time.y);
                half4 origin = tex2D(_MainTex, i.uv + displace.xy * _Force);
                return origin;
            }
            ENDCG
        }
    }
}
