// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Skele/DrawUtilLine" {
        
    SubShader { //DX9 shader
     Tags {"Queue"="Overlay+50" "IgnoreProjector"="True" "RenderType"="Transparent"}
     Pass { //front pass

         LOD 200
         ZWrite Off
		 Cull Off
		 Blend SrcAlpha OneMinusSrcAlpha
                  
         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag
         #include "UnityCG.cginc"
   
         struct VertexInput {
             float4 v : POSITION;
             float4 color: COLOR;
         };
          
         struct VertexOutput {
             float4 pos : SV_POSITION;
             float4 col : COLOR;             
         };
         
          
         VertexOutput vert(VertexInput v) {          
             VertexOutput o;
             o.pos = UnityObjectToClipPos(v.v);
             o.col = v.color;
             return o;
         }
          
         float4 frag(VertexOutput o) : COLOR {
             return o.col;
         }
  
         ENDCG
         } 
	
	Pass { // back pass

         LOD 200
         ZWrite Off
		 Cull Off
		 ZTest Greater
		 Blend SrcAlpha OneMinusSrcAlpha
                  
         CGPROGRAM
         #pragma vertex vert
         #pragma fragment frag
         #include "UnityCG.cginc"
   
         struct VertexInput {
             float4 v : POSITION;
             float4 color: COLOR;
         };
          
         struct VertexOutput {
             float4 pos : SV_POSITION;
             float4 col : COLOR;             
         };
         
          
         VertexOutput vert(VertexInput v) {          
             VertexOutput o;
             o.pos = UnityObjectToClipPos(v.v);
             o.col = float4(v.color.xyz, v.color.a * 0.15 * step(o.pos.z, 10));
             return o;
         }
          
         float4 frag(VertexOutput o) : COLOR {
			 return o.col;
         }
  
         ENDCG
         } 
     }
  
 }