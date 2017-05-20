Shader "Custom/maskedscreen" {
	Properties {
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Mask ("Mask", 2D) = "white" {}
		_Alpha("Alpha", Range(0.0,1.0)) = 1.0
		
	}
	SubShader {
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 200
		
		CGPROGRAM
		#pragma surface surf Lambert alpha

		struct Input {
			float2 uv_MainTex;
			float2 uv_Mask;
		};
		
		sampler2D _MainTex;
		sampler2D _Mask;
		float _Alpha;

		float rand(float2 co)
		{
			float x = _Time.x;
			while (x > 1) x *= 0.5;
			x = cos(x);
			return abs(cos(dot(co.xy, float2(1, 2)) * x)) * abs(sin(_Time.y) + 0.2) * 0.01 + x * 0.01;
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{
			float moveSpeed = 1;
			float r = rand(IN.uv_MainTex);
			half4 masked = tex2D(_Mask, float2(IN.uv_Mask.x, IN.uv_Mask.y + rand(IN.uv_Mask) + _Time.x * moveSpeed)) * r;
			half4 res = tex2D(_MainTex, float2(IN.uv_MainTex.x+ masked.r,IN.uv_MainTex.y+ masked.r));
			o.Albedo = res.rgb;
			o.Alpha = _Alpha;
			o.Emission = res.rgb;
		}
		ENDCG
	} 
	//FallBack "Diffuse"
	Fallback "Transparent/VertexLit"
}
