
Shader "CurioShaders/Curve_Transparent" 
{
	Properties 
	{
		_Color ("Main Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
	}

	SubShader 
	{
		Tags{ "RenderType" = "Transparent" "Queue" = "Transparent" }
		LOD 200

		CGPROGRAM
		#pragma surface surf NoLighting noambient vertex:vert alpha
		#pragma multi_compile __ CURVE_ACTIVE

		// Global properties to be set by CurveControl script
		uniform int	_CurveStlye;
		uniform half3 _CurveOrigin;
		uniform half _Curvature;
		uniform half _Curve1;
		uniform half _Curve2;

		uniform half _Flatness;
		uniform half _Flatness2;
		
		uniform fixed3 _Slant;

		// Per material properties
		sampler2D _MainTex;
		fixed4 _Color;

		struct Input 
		{
			float2 uv_MainTex;
		};

		half4 Bend(half4 v)
		{
              half4 world = mul(unity_ObjectToWorld, v);
              half dist = length(world.xz-_CurveOrigin.xz);
              dist = max(0, dist-_Flatness);
              dist = dist*dist;
			  half2 curv = half2(_Curve1, _Curve2);
			  curv *= 0.001;
              world.xy += dist*curv;
              return mul(unity_WorldToObject, world);
		}
		half4 Curve1(half4 v)
		{
		_Curvature *= 0.001;
			half4 wpos = mul (unity_ObjectToWorld, v);
			half2 xzDist = (wpos.xz - _CurveOrigin.xz) / _Slant.xz;
			half dist = length(xzDist);
			dist = max(0, dist - _Flatness);
			wpos.y -= dist * dist * _Curvature;
			wpos = mul (unity_WorldToObject, wpos);
			return wpos;
		}

		half4 Curve2(half4 v)
		{
		_Curvature *= 0.001;
			half4 wpos = mul (unity_ObjectToWorld, v);
			half xDist = max(0, abs(wpos.x - _CurveOrigin.x) - _Flatness);
			half zDist = max(0, abs(wpos.z - _CurveOrigin.z) - _Flatness2);
			half zOff = xDist * xDist * _Curve1 + zDist * zDist * _Curve2;
			wpos.y += zOff * _Curvature ;
			wpos = mul (unity_WorldToObject, wpos);
			return wpos;
		}
		void vert (inout appdata_full v) 
		{
			#if defined(CURVE_ACTIVE)
			if(_CurveStlye ==0)
			v.vertex = Bend(v.vertex);	
			else if(_CurveStlye ==1)
			v.vertex = Curve1(v.vertex);	
			else if(_CurveStlye ==2)
			v.vertex = Curve2(v.vertex);	
			#endif
		}

		void surf (Input IN, inout SurfaceOutput o) 
		{
			fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb;
			o.Alpha = c.a;
		}
		fixed4 LightingNoLighting(SurfaceOutput s, fixed3 lightDir, fixed atten) {
            fixed4 c;
            c.rgb = s.Albedo;
            c.a = s.Alpha;
            return c;
        }
		ENDCG
	}

	Fallback "Mobile/Diffuse"
}

