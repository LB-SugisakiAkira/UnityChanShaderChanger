using UnityEngine;

public class ShaderController : MonoBehaviour
{
    public GameObject avatarModel; // アバターのモデル
    public Shader[] shaders; // 使用するシェーダーの配列

    private int currentShaderIndex = 0; // 現在のシェーダーインデックス

    // シェーダーを変更
    public void ChangeShader()
    {
        currentShaderIndex = (currentShaderIndex + 1) % shaders.Length; // 次のシェーダーにインデックスを更新
        Debug.Log(shaders[currentShaderIndex]);

        // avatarModel内の全ての SkinnedMeshRenderer を取得
        SkinnedMeshRenderer[] renderers = avatarModel.GetComponentsInChildren<SkinnedMeshRenderer>();

        // すべての SkinnedMeshRenderer にマテリアルを適用
        foreach (var renderer in renderers)
        {
            if (renderer != null)
            {
                foreach (var material in renderer.materials)
                {
                    material.shader = shaders[currentShaderIndex];
                }
            }
        }
    }
}