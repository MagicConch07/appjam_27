using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Give : MonoBehaviour
{
    [SerializeField] private Shake _shake;

    public void GiveAlcohol()
    {
        if (_shake.IsRight == false) return;

        SceneManager.LoadScene(0);
    }
}
