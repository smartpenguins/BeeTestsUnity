using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Burst;
using Unity.Transforms;
using Unity.Mathematics;


public partial struct MoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        new MoveJob { deltaTime=SystemAPI.Time.DeltaTime}.ScheduleParallel();
    }
}


[BurstCompile]
public partial struct MoveJob : IJobEntity
{
    public float deltaTime;
    private void Execute(RefRW<Bee> bee, RefRW<LocalTransform> transform)
    {
        if (math.distancesq(transform.ValueRO.Position, bee.ValueRO.toPoint) < .02f)
        {
            float2 newPoint = bee.ValueRW.random.NextFloat2Direction()* bee.ValueRW.random.NextFloat() * bee.ValueRO.flyRadius;
            bee.ValueRW.toPoint = bee.ValueRO.startPoint + new float3(newPoint.x, newPoint.y, 0);
        }
        transform.ValueRW.Position += (math.normalize(bee.ValueRO.toPoint - transform.ValueRO.Position) * deltaTime * bee.ValueRO.speed);
    }
}