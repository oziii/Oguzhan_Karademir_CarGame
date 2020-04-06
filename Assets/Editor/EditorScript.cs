using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EditorScript : MonoBehaviour
{
    [MenuItem("Level Designer/Game Area Create ")]
    static void GameAreaCreate(MenuCommand mc)
    {
        //Prefabı dizinden çekiyoruz.
        // We pull the prefab from the path.
        Object gameAreaPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/GameArea.prefab", typeof(GameObject));
        if (gameAreaPrefab != null)
        {
            //Obje null değilse prefabı Instantiate yapıyoruz.
            // If the object is not null, we make the prefab Instantiate.
            PrefabUtility.InstantiatePrefab(gameAreaPrefab);
        }
    }

    [MenuItem("Level Designer/Entrance Create ")]
    static void EntanceCreate(MenuCommand mc)
    {
        Object entrancePrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Entrance.prefab", typeof(GameObject));
        if (entrancePrefab != null)
        {
            PrefabUtility.InstantiatePrefab(entrancePrefab);
        }

    }

    [MenuItem("Level Designer/Target Create ")]
    static void TargetCreate(MenuCommand mc)
    {
        Object targetPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Target.prefab", typeof(GameObject));
        if (targetPrefab != null)
        {
            PrefabUtility.InstantiatePrefab(targetPrefab);
        }
    }

    [MenuItem("Level Designer/Obstacles/Obstacles1 Create ")]
    static void Obstacles1Create(MenuCommand mc)
    {
        Object obstaclesPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Obstacle1.prefab", typeof(GameObject));
        if (obstaclesPrefab != null)
        {
            PrefabUtility.InstantiatePrefab(obstaclesPrefab);
        }
    }

    [MenuItem("Level Designer/Obstacles/Obstacles2 Create ")]
    static void Obstacles2Create(MenuCommand mc)
    {
        Object obstaclesPrefab = AssetDatabase.LoadAssetAtPath("Assets/Prefab/Obstacle2.prefab", typeof(GameObject));
        if (obstaclesPrefab != null)
        {
            PrefabUtility.InstantiatePrefab(obstaclesPrefab);
        }
    }
}
