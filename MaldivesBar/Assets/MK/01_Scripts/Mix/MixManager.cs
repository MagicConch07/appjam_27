using System.Collections;
using System.Collections.Generic;
using MKDir;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MixManager : MonoSingleton<MixManager>
{
    public RecipeSO[] _recipes;
    public Image[] images;

    public RecipeSO _currentRecipe;

    public void RandomRecipe()
    {
        int rand = Random.Range(0, _recipes.Length);
        _currentRecipe = _recipes[rand];
    }

    public void RecipeStart()
    {
        RandomRecipe();

        for (int i = 0; i < 4; ++i)
        {
            images[i].sprite = _currentRecipe.resources[i];
        }
    }

    public void GiveAl()
    {
        SceneManager.LoadScene(1);
    }
}
