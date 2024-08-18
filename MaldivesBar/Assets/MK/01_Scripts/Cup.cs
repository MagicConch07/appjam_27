using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _waterSprites;
    public int[] indexs = new int[4];

    private int _waterIndex = 0;

    public void FillCup(Color color, int index)
    {
        _waterSprites[_waterIndex].enabled = true;
        _waterSprites[_waterIndex].color = color;
        indexs[_waterIndex] = index;
        _waterIndex++;
    }

    public void DeleteWater()
    {
        _waterIndex = 0;

        for (int i = 0; i < 4; ++i)
        {
            indexs[i] = 0;
        }

        foreach (var water in _waterSprites)
        {
            water.enabled = false;
        }
    }
}
