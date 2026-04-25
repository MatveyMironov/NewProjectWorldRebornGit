Shader "Unlit/GridCell"
{
    Properties
    {
        _BaseMap("Base Map", 2D) = "white" {}
        _BaseColor("Base Color", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Pass
        {
            Tags
            {
                "RenderType"="Opaque"
                "RenderPipeline" = "UniversalRenderPipeline"
            }

            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma multi_compile_instancing

            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
            #include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
            
            StructuredBuffer<float4> position_buffer;

            texture2D _BaseMap;
            sampler sampler_BaseMap;

            half4 _BaseMap_ST;
            half4 _BaseColor;

            struct attributes
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert(attributes v, const uint instance_id : SV_InstanceID)
            {
                float4 local_position = position_buffer[instance_id];
                const float3 world_position = local_position.xyz + v.vertex.xyz;

                v2f o;
                o.vertex = mul(UNITY_MATRIX_VP, float4(world_position, 1.0f));
                o.uv = v.uv;
                return o;
            }

            half4 frag(const v2f i) : SV_Target
            {
                half4 color = _BaseMap.Sample(sampler_BaseMap, i.uv);
                return color * _BaseColor;
            }
            ENDHLSL
        }
    }
}
