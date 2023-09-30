using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RandomComponentAuthoring : MonoBehaviour
{
}
public struct RandomComponent : IComponentData
{
    public Random value;
}


public class RandomComponentBaker : Baker<RandomComponentAuthoring>
{
    public override void Bake(RandomComponentAuthoring authoring)
    {
        Entity etity = GetEntity(TransformUsageFlags.None);
        AddComponent(etity, new RandomComponent { value = new Random(1) });
    }
}
