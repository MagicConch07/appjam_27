using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BackBtn : MonoBehaviour
{
    public Button BackButton;
    // Start is called before the first frame update
    void Start()
    {
        if (BackButton != null)
        {
            BackButton.onClick.AddListener(SceneChanger);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SceneChanger() {
        SceneManager.LoadScene(0);
    }
}
