using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class WorldRandomAuthoring : MonoBehaviour
{
}
public struct WorldRandom : IComponentData
{
    public Random value;
}


public class WorldRandomBaker : Baker<WorldRandomAuthoring>
{
    public override void Bake(WorldRandomAuthoring authoring)
    {
        Entity etity = GetEntity(TransformUsageFlags.None);
        AddComponent(etity, new WorldRandom { value = new Random(1) });
    }
}
