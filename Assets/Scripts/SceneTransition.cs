using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Button _startButton;
   
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

    }

    public void LoadScene()
    {
       
        SceneManager.LoadScene(0);
    }

}
