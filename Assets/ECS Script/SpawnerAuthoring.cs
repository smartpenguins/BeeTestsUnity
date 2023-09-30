using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject prefab;
    public double rate;
    public int max;
    public KeyCode key = KeyCode.E;

}
public struct Spawner : IComponentData
{
    public Entity prefab;
    public double rate;
    public double nextSpawn;
    public int count;
    public int max;
    public bool run;
    public KeyCode keyCode;
}


public class SpawnerBaker : Baker<SpawnerAuthoring>
{
    public override void Bake(SpawnerAuthoring authoring)
    {
        Entity entity = GetEntity(TransformUsageFlags.None);
        AddComponent(entity, new Spawner
        {
            prefab = GetEntity(authoring.prefab, TransformUsageFlags.Dynamic),
            rate = authoring.rate,
            max = authoring.max,
            keyCode = authoring.key,
            count = 0,
            run = false,
            nextSpawn = Time.timeAsDouble
        });
    }
}

public partial class SpawnerSystem : SystemBase
{
    protected override void OnCreate()
    {
        RequireForUpdate<Spawner>();
    }
    protected override void OnUpdate()
    {
        foreach (var spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            // RefRW<Spawner> spawner = SystemAPI.GetSingletonRW<Spawner>();
            if (Input.GetKeyDown(spawner.ValueRO.keyCode))
            {
                spawner.ValueRW.run = true;
                spawner.ValueRW.max += 1000;
            }
            if (!spawner.ValueRO.run) continue;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                spawner.ValueRW.max += 10000;
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
            {
                spawner.ValueRW.max += 100000;
            }

            RefRW<WorldRandom> worldRandom = SystemAPI.GetSingletonRW<WorldRandom>();
            {
                while (spawner.ValueRO.nextSpawn <= SystemAPI.Time.ElapsedTime)
                {
                    if (spawner.ValueRO.count >= spawner.ValueRO.max)
                    {
                        break;
                    }

                    spawner.ValueRW.nextSpawn += spawner.ValueRO.rate;
                    spawner.ValueRW.count++;
                    Entity newEntity = EntityManager.Instantiate(spawner.ValueRO.prefab);
                    if (SystemAPI.HasComponent<Bee>(newEntity))
                        SystemAPI.GetComponentRW<Bee>(newEntity).ValueRW.random = new Unity.Mathematics.Random(worldRandom.ValueRW.value.NextUInt());
                }

                FPS.SetCount(spawner.ValueRO.count);
            }
        }
    }
}


