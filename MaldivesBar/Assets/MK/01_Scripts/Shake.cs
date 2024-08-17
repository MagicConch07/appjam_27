using UnityEngine;

public class Shake : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] _sprite;
    [SerializeField] private Cup _cup;

    public bool IsRight = false;

    public void ShakeAL()
    {
        int sum = 0;
        for (int i = 0; i < _sprite.Length; ++i)
        {
            //bool check = false;

            for (int j = 0; j < 4; ++j)
            {
                Debug.Log($"sp : {_sprite[i].color}");
                Debug.Log($"re : {MixManager.Instnace._currentRecipe.resColors[j]}");
                if (_sprite[i].color == MixManager.Instnace._currentRecipe.resColors[j])
                {
                    Debug.Log("이게 안된다고?");
                    sum++;
                    //check = true;
                }
            }

            /* if (check == false)
            {
                _cup.DeleteWater();
                return;
            } */
        }

        IsRight = true;

        foreach (var img in _sprite)
        {
            img.color = MixManager.Instnace._currentRecipe.color;
        }

        /* if (sum >= 4)
        {
            foreach (var img in _sprite)
            {
                img.color = MixManager.Instnace._currentRecipe.color;
            }

        } */
    }
}
