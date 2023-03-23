using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace IllumateStudios.Helper
{
    public class ArtHelper : MonoBehaviour
    {
        [SerializeField] private GameObject prefab;

        [ContextMenu("Replace by Prefabs")]
        private void ReplaceByPrefabs()
        {
            Transform[] childs = new Transform[transform.childCount];
            for (int i = 0; i < transform.childCount; i++)
            {
                childs[i] = transform.GetChild(i);
            }

            for (int i = 0; i < childs.Length; i++)
            {
                GameObject obj = PrefabUtility.InstantiatePrefab(prefab, transform) as GameObject;
                obj.transform.position = childs[i].position;
                obj.transform.rotation = childs[i].rotation;
                DestroyImmediate(childs[i].gameObject);
            }
        }
    }
}