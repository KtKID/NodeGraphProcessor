using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityMgr
{
    private static EntityMgr instance;

    public static EntityMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new EntityMgr();
            }
            return instance;
        }
    }

    private Dictionary<int, Entity> m_EntityDic = new Dictionary<int, Entity>();

    private EntityMgr()
    {
        m_EntityDic.Clear();

        AddEntity(new Entity(1, 100, 10, 5));
        AddEntity(new Entity(2, 200, 20, 10));
    }

    private void AddEntity(Entity entity)
    {
        if (entity == null)
        {
            return;
        }

        if (m_EntityDic.ContainsKey(entity.LogicID))
        {
            return;
        }
        Debug.Log($"Add Entity {entity.LogicID}");

        m_EntityDic.Add(entity.LogicID, entity);
    }

    public Entity GetEntity(int logicId)
    {
        if (m_EntityDic.ContainsKey(logicId))
        {
            return m_EntityDic[logicId];
        }

        return null;
    }
}
