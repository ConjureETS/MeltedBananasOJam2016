	Shader "Custom/PostEffectShader"
{
	Properties
	{
		_Blindness("Blindness", Float) = 0.6 
		_MainTex("Texture", 2D) = "white" {}
	
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
				float4 position : POSITION;

				float4 screenPos : TEXCOORD0;
			};

			v2f vert (appdata v)
			{
				v2f o;

				o.position = mul(UNITY_MATRIX_MVP, v.vertex);

				o.screenPos = o.position;

				return o;
			}
			
			sampler2D _MainTex;
			float _Blindness;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 screenPos = i.screenPos.xy / i.screenPos.w;
				float depth = _Blindness*0.0025;
				
				screenPos.x = (screenPos.x + 1) * 0.5;

				screenPos.y = 1 - (screenPos.y + 1) * 0.5;

				half4 sum = half4(0.0h, 0.0h, 0.0h, 0.0h);
				sum += tex2D(_MainTex, float2(screenPos.x - 3.0 * depth, screenPos.y + 3.0 * depth)) * 0.09;
				sum += tex2D(_MainTex, float2(screenPos.x + 3.0 * depth, screenPos.y - 3.0 * depth)) * 0.09;

				sum += tex2D(_MainTex, float2(screenPos.x - 2.0 * depth, screenPos.y + 2.0 * depth)) * 0.12;
				sum += tex2D(_MainTex, float2(screenPos.x + 2.0 * depth, screenPos.y - 2.0 * depth)) * 0.12;

				sum += tex2D(_MainTex, float2(screenPos.x - 1.0 * depth, screenPos.y + 1.0 * depth)) *  0.15;
				sum += tex2D(_MainTex, float2(screenPos.x + 1.0 * depth, screenPos.y - 1.0 * depth)) *  0.15;

				sum += tex2D(_MainTex, screenPos - 5.0 * depth) * 0.025;
				sum += tex2D(_MainTex, screenPos - 4.0 * depth) * 0.05;
				sum += tex2D(_MainTex, screenPos - 3.0 * depth) * 0.09;
				sum += tex2D(_MainTex, screenPos - 2.0 * depth) * 0.12;
				sum += tex2D(_MainTex, screenPos - 1.0 * depth) * 0.15;
				sum += tex2D(_MainTex, screenPos) * 0.16;
				sum += tex2D(_MainTex, screenPos + 5.0 * depth) * 0.15;
				sum += tex2D(_MainTex, screenPos + 4.0 * depth) * 0.12;
				sum += tex2D(_MainTex, screenPos + 3.0 * depth) * 0.09;
				sum += tex2D(_MainTex, screenPos + 2.0 * depth) * 0.05;
				sum += tex2D(_MainTex, screenPos + 1.0 * depth) * 0.025;

				return sum / 2;
				//col.a = (c.r + c.b + c.g) / 3;
				// just invert the colors
				//col = 1 - col;
				//return col;
			}
			ENDCG
		}
	}
}
