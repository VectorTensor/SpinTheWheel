Shader "Examples/TapUnderline"
{
    Properties
    {
        
        _BaseColor("Base Color" , Color) = (1,1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" 
        "Queue" = "Transparent"
        
        }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha
          //  ZTest LEqual
          //  ZWrite On
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
                float4 vertex: SV_POSITION;
                float2 uv : TEXCOORD0;
                
            };

            float4 _BaseColor;

            float UnderlineLengthSDF(float2 p){

                float2 refDistance = {0,0};
                //p.x -= _Time.y;
                float dist = distance(refDistance, p);
                dist = exp(-6*dist+0.7);
                 if (dist<0.3){
                     dist =0;
                 }
                return dist;
            }
            float UnderlineLengthSDF(float2 p,float2 refDistance){

                //float2 refDistance = {0,0};
                //p.x -= _Time.y;
                float dist = distance(refDistance, p);
                dist = exp(-6*dist+1);
                 if (dist<0.3){
                     dist =0;
                 }
                return dist;
            }

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;

                return o;
                
            }

            

            float4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //float4 col = tex2D(_MainTex, i.uv);
                
                i.uv -=0.5;
                float4 col = _BaseColor;
              //  i.uv.x += sin(_Time.y*8);
                float alpha = UnderlineLengthSDF(i.uv);

                 if (cos(4*(i.uv.x + _Time.y/1.2)) > 0 && cos(4*(i.uv.x + _Time.y/1.2))<0.04 ){
                    col = float4(1,1,1,UnderlineLengthSDF(i.uv, float2(i.uv.x, 0.5)));
                 }
                col = float4 (col.xyz*alpha,alpha);
                //clip((1-alpha)/2);
                return col ;
            }
            ENDCG
        }
    }
}
