using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sirenix.OdinInspector.Editor;
using Sirenix.OdinInspector;

public class EntityEditor
{
    // [Title("Entity Property")]
    public int a;

    [ListDrawerSettings(DraggableItems = false, ShowIndexLabels = true, ShowItemCount = true)]
    // [TableList]
    public List<EntityEditorWarp> m_EntityList = new List<EntityEditorWarp>(){
         new EntityEditorWarp(1,100,1,1),
    };

    [TableList(ShowIndexLabels = true)]
    public List<int> nums;

    [HorizontalGroup("Group 1", LabelWidth = 30)]
    public int index;

    [HorizontalGroup("Group 1", LabelWidth = 30)]
    [Button("Refresh Entity")]
    public void RefreshEntity()
    {
        Debug.Log("Refresh Entity");

        UpdateData(WarpEntity(EntityMgr.Instance.GetEntity(index)));
    }

    private EntityEditorWarp WarpEntity(Entity entity)
    {
        if (null == entity)
        {
            Debug.LogError("Entity is null");
            return null;
        }
        return new EntityEditorWarp(entity.LogicID, entity.HP, entity.Attack, entity.Defense);
    }

    private void UpdateData(EntityEditorWarp entity)
    {
        if (null == entity)
        {
            Debug.LogError("Entity is null");
            return;
        }
        m_EntityList.Add(entity);
        Debug.Log($"Update Entity {entity.LogicID}  count= {m_EntityList.Count}");
    }
}

// write a class to warp the entity property, like hp, attack, defense, etc.
[Serializable]
public class EntityEditorWarp
{
    [HorizontalGroup("group1", Width = 100)]
    [PreviewField(Alignment = ObjectFieldAlignment.Center)]
    public Texture icon = null;

    [HorizontalGroup("group1", marginLeft: 50, LabelWidth = 100)]

    [BoxGroup("group1/Property")]
    public int m_LogicID;
    [BoxGroup("group1/Property")]
    public int hp;
    // [BoxGroup("Property")]
    [BoxGroup("group1/Property")]
    public float attack;
    // [BoxGroup("Property")]
    [BoxGroup("group1/Property")]
    public float defense;

    public int LogicID => m_LogicID;

    public int HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public float Attack
    {
        get { return attack; }
        set { attack = value; }
    }

    public float Defense
    {
        get { return defense; }
        set { defense = value; }
    }
    public EntityEditorWarp(int logicId, int hp, float attack, float defense)
    {
        m_LogicID = logicId;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
    }
}
