// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/GrassShader"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Sway ("Sway Strength", Vector) = (1, 1, 0, 0) // Should be used as a Vector2
        _Frequency ("Sway Frequency", Float) = 1
        //_Glossiness ("Smoothness", Range(0,1)) = 0.5
        //_Metallic ("Metallic", Range(0,1)) = 0.0
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "RenderType"="Opaque" }
        LOD 200
        Cull Off

        CGPROGRAM
        //Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf GlobalColor fullforwardshadows alpha vertex:vert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 2.5

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        struct VertexInput
        {
            float4 vertex : POSITION;
            float4 texcoord : TEXCOORD1;
            float3 normal : NORMAL;
        };


        // half _Glossiness;
        // half _Metallic;
        fixed4 _Color;
        fixed4 _Sway;
        float  _Frequency;

        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutput o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            // Metallic and smoothness come from slider variables
            // o.Metallic = _Metallic;
            // o.Smoothness = _Glossiness;
            o.Alpha = c.a;

            
        }

        half4 LightingGlobalColor (SurfaceOutput s, half3 lightDir, half atten)
        {
            half4 c;
            c.rgb = s.Albedo * _LightColor0.rgb * atten;
            c.a = s.Alpha;
            return c;
        }

        void vert (inout VertexInput v)
        {
            //float4 globalPos = mul(unity_ObjectToWorld, v.vertex);
            float4 globalOffset = sin(_Time * _Frequency) * _Sway;
            //v.vertex = mul(unity_WorldToObject, globalPos);
            v.vertex += min(0, (v.vertex.z - 0.8)) * mul(unity_WorldToObject, globalOffset);
        }
        ENDCG
    }
    FallBack "Diffuse"
}
