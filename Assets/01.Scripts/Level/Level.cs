using UnityEngine;

public abstract class Level : MonoBehaviour
{
    [HideInInspector]
    public int maxWeight = 0;
    public int weight;

    public float lenght;

    public abstract void Initialize();
    public abstract void OnSpawn();
}
