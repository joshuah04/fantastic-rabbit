#if OPENGL
#define SV_POSITION POSITION
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0_level_9_1
#define PS_SHADERMODEL ps_4_0_level_9_1
#endif

float4x4 MatrixTransform;
//float4x4 gworldviewprojection;

Texture2D SpriteTexture;

sampler2D SpriteTextureSampler = sampler_state
{
    Texture = <SpriteTexture>;
    minfilter = point;
    magfilter = point;
    mipfilter = point;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float4 Color : COLOR0;
    float2 TextureCoordinates : TEXCOORD0;
    //float4 WorldPos : TEXCOORD2;
};


float4 MainPS(VertexShaderOutput input, float2 originalUV : TEXCOORD0) : COLOR
{
    float4 color = tex2D(SpriteTextureSampler, input.TextureCoordinates);
   

    float4 hatColor = float4(0.0, 0.0, 0.0, 1.0);
    float4 hairColor = float4(0.612, 0.290, 0.0, 1.0);
    float4 skinColor = float4(1.0, 0.808, 0.773, 1.0);

    if (color.a != 0.0)
    {
        if ((int) (color.r * 255) == 116 && (int) (color.g * 255) == 116 && (int) (color.b * 255) == 116)
            color.rgb = hatColor.rgb;
        else if ((int) (color.r * 255) == 173 && (int) (color.g * 255) == 173 && (int) (color.b * 255) == 173)
            color.rgb = hairColor.rgb;
        else if ((int) (color.r * 255) == 233 && (int) (color.g * 255) == 233 && (int) (color.b * 255) == 233)
            color.rgb = skinColor.rgb;
    }

    return color;

}

technique SpriteDrawing
{
    pass P0
    {
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
};