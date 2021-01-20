﻿Shader "Super Text Mesh/UI/Dropshadow And Outline" {
	Properties 
	{
		_MainTex ("Font Texture", 2D) = "white" {}
		_MaskTex ("Mask Texture", 2D) = "white" {}

		_ShadowColor ("Shadow Color", Color) = (0,0,0,1)
        _ShadowDistance ("Shadow Distance", Range(0,1)) = 0.05
        [Toggle(USE_VECTOR3)] _UseVector3 ("Use Vector3", Float) = 0
        [HideIf(USE_VECTOR3)] _ShadowAngle ("Shadow Angle", Range(0,360)) = 135
		[ShowIf(USE_VECTOR3)] _ShadowAngle3 ("Shadow Angle3", Vector) = (1,-1,0)
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0,1)) = 0.05

		[Toggle(SDF_MODE)] _SDFMode ("Toggle SDF Mode", Float) = 0
		[ShowIf(SDF_MODE)] _SDFCutoff ("SDF Cutoff", Range(0,1)) = 0.5
		[ShowIf(SDF_MODE)] _Blend ("Blend Width", Range(0.0001,1)) = 0.05
		[MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
		_ShadowCutoff ("Shadow Cutoff", Range(0,1)) = 0.5
		_Cutoff ("Cutoff", Range(0,1)) = 0.0001 //text cutoff
		[Enum(UnityEngine.Rendering.CullMode)] _CullMode ("Cull Mode", Float) = 0
		
		_MaskComp ("Mask Comparison", Float) = 8
		_MaskMode ("Mask Mode", Float) = 0
		_MaskOp ("Mask Operation", Float) = 0
        _WriteMask ("Write Mask", Float) = 255
		_ReadMask ("Read Mask", Float) = 255

		_ColorMask ("Color Mask", Float) = 15
	}
	SubShader {
		Tags { 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"STMUberShader"="Yes"
		}

		Stencil
		{  
			Ref [_MaskMode]  //Customize this value  
			Comp [_MaskComp] //Customize the compare function  
			Pass [_MaskOp]
			ReadMask [_ReadMask]
			WriteMask [_WriteMask]
		}

		LOD 100

		Lighting Off
		Cull [_CullMode]
		//special UI zTest Mode
		ZTest [unity_GUIZTestMode]
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha
		ColorMask [_ColorMask]

		Pass 
		{
			CGPROGRAM
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMdropshadow.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 0;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 90;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 180;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 270;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 45;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 135;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 225;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			static float ANGLE = 315;
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STMoutline.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
		Pass 
		{
			CGPROGRAM
			#include "UnityCG.cginc"
			#include "UnityUI.cginc"
			#include "../STM.cginc"
			#pragma vertex vert
			#pragma fragment frag
			#pragma shader_feature SDF_MODE
			#pragma shader_feature PIXELSNAP_ON
			ENDCG
		}
	}
	FallBack "GUI/Text Shader"
}
