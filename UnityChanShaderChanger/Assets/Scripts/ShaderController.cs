using UnityEngine;

public class ShaderController : MonoBehaviour
{
    public GameObject avatarModel; // アバターのモデル
    // public Shader[] shaders; // 使用するシェーダーの配列
    public Material[] materials; // 使用するマテリアルの配列

    private int currentShaderIndex = 0; // 現在のシェーダーインデックス

    // シェーダーを変更
    public void ChangeShader()
    {
        // currentShaderIndex = (currentShaderIndex + 1) % shaders.Length; // 次のシェーダーにインデックスを更新
        // avatarModel.GetComponent<Renderer>().material.shader = shaders[currentShaderIndex]; // 現在のシェーダーを適用
        currentShaderIndex = (currentShaderIndex + 1) % materials.Length; // 次のシェーダーにインデックスを更新
        Debug.Log(materials[currentShaderIndex]);

        // avatarModel.GetComponent<Renderer>().material.shader = materials[currentShaderIndex].shader; // 現在のシェーダーを適用

        // avatarModel内の全ての SkinnedMeshRenderer を取得
        SkinnedMeshRenderer[] renderers = avatarModel.GetComponentsInChildren<SkinnedMeshRenderer>();

        // すべての SkinnedMeshRenderer にマテリアルを適用
        foreach (var renderer in renderers)
        {
            if (renderer != null)
            {
                renderer.material.shader = materials[currentShaderIndex].shader; // マテリアルを適用
            }
        }
    }
}