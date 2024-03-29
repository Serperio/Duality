﻿// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "UI/Vertical Transparency"
{
    Properties
    {
        [PerRendererData] _MainTex("Sprite Texture", 2D) = "white" {}
        _ColorA("Tint", Color) = (1,1,1,1)
        _ColorB("Tint", Color) = (1,1,1,1)

        _StencilComp("Stencil Comparison", Float) = 8
        _Stencil("Stencil ID", Float) = 0
        _StencilOp("Stencil Operation", Float) = 0
        _StencilWriteMask("Stencil Write Mask", Float) = 255
        _StencilReadMask("Stencil Read Mask", Float) = 255

        _ColorMask("Color Mask", Float) = 15

        [Toggle(UNITY_UI_ALPHACLIP)] _UseUIAlphaClip("Use Alpha Clip", Float) = 0

        [Toggle(UNITY_UI_ALPHACLIP)] _Phase("Phase", Float) = 0

        _TransparencyA("Transparency A", Float) = 0
        _TransparencyB("Transparency B", Float) = 0
    }

        SubShader
        {
            Tags
            {
                "Queue" = "Transparent"
                "IgnoreProjector" = "True"
                "RenderType" = "Transparent"
                "PreviewType" = "Plane"
                "CanUseSpriteAtlas" = "True"
            }

            Stencil
            {
                Ref[_Stencil]
                Comp[_StencilComp]
                Pass[_StencilOp]
                ReadMask[_StencilReadMask]
                WriteMask[_StencilWriteMask]
            }

            Cull Off
            Lighting Off
            ZWrite Off
            ZTest[unity_GUIZTestMode]
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMask[_ColorMask]

            Pass
            {
                Name "Default"
            CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #pragma target 2.0

                #include "UnityCG.cginc"
                #include "UnityUI.cginc"

                #pragma multi_compile_local _ UNITY_UI_CLIP_RECT
                #pragma multi_compile_local _ UNITY_UI_ALPHACLIP

                struct appdata_t
                {
                    float4 vertex   : POSITION;
                    float4 color    : COLOR;
                    float2 texcoord : TEXCOORD0;
                    UNITY_VERTEX_INPUT_INSTANCE_ID
                };

                struct v2f
                {
                    float4 vertex   : SV_POSITION;
                    fixed4 color : COLOR;
                    float2 texcoord  : TEXCOORD0;
                    float4 worldPosition : TEXCOORD1;
                    UNITY_VERTEX_OUTPUT_STEREO
                };

                sampler2D _MainTex;
                fixed4 _ColorA;
                fixed4 _ColorB;
                fixed4 _TextureSampleAdd;
                float4 _ClipRect;
                float4 _MainTex_ST;
                float _TransparencyA;
                float _TransparencyB;
                float _Phase;

                v2f vert(appdata_t v)
                {
                    v2f OUT;
                    UNITY_SETUP_INSTANCE_ID(v);
                    UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                    OUT.worldPosition = v.vertex;
                    OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                    OUT.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
                    OUT.color = v.color;
                    return OUT;
                }

                fixed4 frag(v2f IN) : SV_Target
                {
                    half4 color;
                    if (IN.texcoord.y <= 0.45)
                        color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color * _ColorB;
                    else if (IN.texcoord.y <= 0.55)
                        color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color * _ColorB * _ColorA;
                    else
                        color = (tex2D(_MainTex, IN.texcoord) + _TextureSampleAdd) * IN.color * _ColorA;

                    if (_Phase == 1) {

                        for (int i = 0; i < 30; i++)
                        {
                            if (IN.texcoord.y <= (-i * .1) + 1.8 - _TransparencyA && IN.texcoord.y >= (-i * .1) + 1.77 - _TransparencyA)
                                color.a = 0;
                        }

                    }

                    if (_Phase == 0) {

                        for (int i = 0; i < 20; i++)
                        {
                            if (IN.texcoord.y <= (-i * .1) + 1.8 + _TransparencyB && IN.texcoord.y >= (-i * .1) + 1.77 + _TransparencyB)
                                color.a = 0;
                        }

                    }

                    #ifdef UNITY_UI_CLIP_RECT
                    color.a *= UnityGet2DClipping(IN.worldPosition.xy, _ClipRect);
                    #endif

                    #ifdef UNITY_UI_ALPHACLIP
                    clip(color.a - 0.001);
                    #endif

                    return color;
                }
            ENDCG
            }
        }
}