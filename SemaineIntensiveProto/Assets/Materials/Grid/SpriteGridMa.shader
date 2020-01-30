Shader "Custom/SpriteGridMat"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_BothTilling("_BothTilling", Float) = 1.67
		_TillingX ("_TillingX", Float) = 1
		_TillingY ("_TillingY", Float) = 1
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
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
			float _TillingX;
			float _TillingY;
			float _BothTilling;

            v2f vert (appdata v)
            {
                v2f o;
				_MainTex_ST.x = _TillingX * _BothTilling;
				_MainTex_ST.y = _TillingY * _BothTilling;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
				col.rgb *= col.a;
                return col;
            }
            ENDCG
        }
    }
}
