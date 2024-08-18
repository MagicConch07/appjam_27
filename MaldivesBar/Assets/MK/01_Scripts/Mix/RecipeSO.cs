using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/Recipe")]
public class RecipeSO : ScriptableObject
{
    public Sprite[] resources;
    public Color[] resColors;
    public int[] indexs;
    public Color color;

    public int price;
}
