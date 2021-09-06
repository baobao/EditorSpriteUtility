/**
EditorSpriteUtility

Copyright (c) 2021 ohbashunsuke

This software is released under the MIT License.
http://opensource.org/licenses/mit-license.php
*/

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.U2D;
using UnityEngine;
using UnityEngine.U2D;

namespace info.shibuya24
{
    public static class EditorSpriteUtility
    {
        /// <summary>
        /// Get List <Sprite> from SpriteAtlas.
        /// Returns null if it does not exist.
        /// </summary>
        public static List<Sprite> GetSpriteList(SpriteAtlas atlas)
        {
            if (atlas == null) return null;

            var objs = atlas.GetPackables();
            if (objs == null || objs.Length <= 0) return null;

            var spriteList = new List<Sprite>();

            foreach (var o in objs)
            {
                // Debug.Log(o);
                if (o is DefaultAsset)
                {
                    // When a folder is specified for SpriteAtlas
                    var dirPath = AssetDatabase.GetAssetPath(o);
                    var spriteGUIDs = AssetDatabase.FindAssets("t:sprite", new[] {dirPath});

                    // Ignore if Sprite does not exist
                    if (spriteGUIDs.Length == 0) continue;

                    spriteList.AddRange(spriteGUIDs.Select(AssetDatabase.GUIDToAssetPath)
                        .Select(AssetDatabase.LoadAssetAtPath<Sprite>).ToList());
                }
                else if (o is Texture2D)
                {
                    var sp = AssetDatabase.LoadAssetAtPath<Sprite>(AssetDatabase.GetAssetPath(o));
                    spriteList.Add(sp);
                }
            }

            return spriteList;
        }
    }
}
