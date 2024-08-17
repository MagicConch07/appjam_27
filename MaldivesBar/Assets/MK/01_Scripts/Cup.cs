using UnityEngine;

public class Cup : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _waterSprites;

    private int _waterIndex = 0;

    public void FillCup(Color color)
    {
        _waterSprites[_waterIndex].enabled = true;
        _waterSprites[_waterIndex].color = color;
        _waterIndex++;
    }
}
