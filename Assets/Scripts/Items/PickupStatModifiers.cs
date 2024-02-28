using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupStatModifiers : PickupItem
{
    [SerializeField] private List<CharacterStats> statsModifier;
    protected override void OnPickedUp(GameObject receiver)
    {
        CharacterStatHandler statsHandler = receiver.GetComponent<CharacterStatHandler>();
        foreach (CharacterStats stat in statsModifier)
        {
            statsHandler.AddStatModifier(stat);
        }
    }
}
