using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _sprite;
    [SerializeField] private Cup _cup;

    public bool IsRight = false;

    public void ShakeAL()
    {
        int sum = 0;
        for (int i = 0; i < 4; ++i)
        {
            for (int j = 0; j < 4; ++j)
            {
                if (_cup.indexs[i] == MixManager.Instnace._currentRecipe.indexs[j])
                {
                    sum++;
                }
            }
        }

        if (sum >= 4)
        {
            foreach (var img in _sprite)
            {
                img.color = MixManager.Instnace._currentRecipe.color;
            }

            IsRight = true;
        }
        else
        {
            _cup.DeleteWater();
        }
    }
}
