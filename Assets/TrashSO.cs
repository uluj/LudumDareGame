using UnityEngine;

[CreateAssetMenu(fileName = "TrashType", menuName = "Scriptable Objects/TrashType")]
public class TrashSo : ScriptableObject
{
    [Header("Identity")]
    public string Id;
    [Header("Prefab")]
    public GameObject Prefab;
    [Header("GamePlay")]
    public int Score;
    [Header("Spawn/PoolSize")]
    public int PoolSize = 5;
}
