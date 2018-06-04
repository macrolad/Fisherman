using UnityEngine;
using System;

[CreateAssetMenu(fileName = "New Fish", menuName = "Fisherman/Fish", order = 0)]
public class FishScriptable : ScriptableObject
{
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
        Trash,
        VeryCommon,
        Common,
        Rare,
        Special,
        Mythical

    }
    public FishRarity Rarity;

    public void LoadData(string line)
    {
        string[] elements = line.Split(';');
        name = elements[0];
        Price = Convert.ToInt32(elements[1]);
        Weight = Convert.ToInt32(elements[2]);
        MinSize = Convert.ToInt32(elements[3]);
        MaxSize = Convert.ToInt32(elements[4]);
        Description = elements[5];
        CatchText = elements[6];
        PullForce = Convert.ToInt32(elements[7]);
        Rarity = (FishRarity)Convert.ToInt32(elements[8]);
    }
}
