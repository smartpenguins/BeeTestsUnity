using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using Random = Unity.Mathematics.Random;
using UnityEngine;

public class BeeAuthoring : MonoBehaviour
{
    public float speed;
    public float flyRadius;
}
public struct Bee : IComponentData
{
    public float speed;
    public float flyRadius;
    public float3 startPoint;
    public float3 toPoint;
    public Random random;
}


public class BeeBaker : Baker<BeeAuthoring>
{
    public override void Bake(BeeAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.Dynamic);
        AddComponent(entity, new Bee { 
            speed = authoring.speed, 
            flyRadius=authoring.flyRadius, 
            startPoint=authoring.transform.position,
            random = new Random((uint) UnityEngine.Random.Range(1,1000000)),
            toPoint =authoring.transform.position 
        });
    }
}
