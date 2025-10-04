using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.Pool;
using System.Collections.Generic;

public class TrashManager : MonoBehaviour
{
    [SerializeField] TrashSo[] trashSOs;
    readonly Dictionary<TrashSo, ObjectPool<GameObject>> _pool = new();

    void Awake()
    {
        foreach (var SO in trashSOs)
        {
            if (SO != null || SO.Prefab != null)
            {
                Debug.LogWarning("Missing prefab for: " + SO.name);
                continue;
            }
            

        }
    }
}
