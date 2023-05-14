using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity
{
    private int m_LogicID;
    private int hp;
    private float attack;
    private float defense;

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

    public Entity(int logicId, int hp, float attack, float defense)
    {
        m_LogicID = logicId;
        this.hp = hp;
        this.attack = attack;
        this.defense = defense;
    }
}
