using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatsChangeType
{
    Add,
    Multiple,
    Override,
}

// CharacterStats가 클래스기 때문에 CharacterStatHandler.cs에서 baseStats을 인스펙터에 표시하기 위해 직렬화
[Serializable]
public class CharacterStats
{
    public StatsChangeType statsChangeType;
    [Range(1, 100)] public int maxHealth;
    [Range(1f, 20f)] public float speed;

    public AttackSO attackSO;
}
