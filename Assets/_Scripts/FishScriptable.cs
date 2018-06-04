using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Fish", menuName = "Fisherman/Fish", order = 0)]
public class FishScriptable : ScriptableObject
{
    public int ID;
    public string Name;
    public Sprite Sprite;

    public enum FishHabitat
    {
        Sea,
        DeepSea,
        River,
        Tropical,
        Artic

    }
    [Space]
    [Header("Data")]
    public FishHabitat Habitat;
    public float Price;
    [Space]
    public float Weight;
    [Space]
    public float MinSize;
    public float MaxSize;
    [Space]
    [TextArea(4, 4)]
    public string Description;
    [TextArea(1, 2)]
    public string CatchText;

    [Space]
    [Header("Parameters")]
    public float PullForce;
    public enum FishRarity
    {
        VeryCommon,
        Common,
        Uncommon,
        Rare,
        VeryRare,
        Mythical

    }
    public FishRarity Rarity;
}
