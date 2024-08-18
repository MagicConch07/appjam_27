using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MenuBtn : MonoBehaviour
{
    public Button startButton;
    // Start is called before the first frame update
    void Start()
    {
        if (startButton != null)
        {
            startButton.onClick.AddListener(SceneChanger);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void SceneChanger()
    {
        SceneManager.LoadScene(3);
    }
}
