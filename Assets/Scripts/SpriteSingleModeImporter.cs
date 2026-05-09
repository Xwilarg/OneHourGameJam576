#if UNITY_EDITOR
using UnityEditor;

// https://discussions.unity.com/t/sprite-mode-default-to-multiple/921914/5
public class SpriteSingleModeImporter : AssetPostprocessor
{
    const int PostProcessOrder = 0;
    public override int GetPostprocessOrder() => PostProcessOrder;

    void OnPreprocessTexture()
    {
        var importer = assetImporter as TextureImporter;

        if (importer.importSettingsMissing is false)
            return;

        importer.spriteImportMode = SpriteImportMode.Single;
    }
}
#endif