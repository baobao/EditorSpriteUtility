using info.shibuya24;
using NUnit.Framework;
using UnityEditor;
using UnityEngine.U2D;

public class SpriteAtlasUtilityTest
{
    [Test]
    public void TestGetSpriteList()
    {
        var atlas = AssetDatabase.LoadAssetAtPath<SpriteAtlas>("Assets/Sample/Atlas.spriteatlas");
        Assert.IsNotNull(atlas);
        
        var list = EditorSpriteUtility.GetSpriteList(atlas);
        Assert.AreEqual(list.Count, 5);
    }
    
    [Test]
    public void TestGetSpriteListSetNull()
    {
        var list = EditorSpriteUtility.GetSpriteList(null);
        Assert.IsNull(list);
    }
}