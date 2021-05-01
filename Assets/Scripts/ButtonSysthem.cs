using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class ButtonSysthem : MonoBehaviour
{
    public static ButtonSysthem instance;
    public InputField nickname;
    public InputField adress;
    public ButtonSysthem()
    {
        instance = this;
    }
    public void playGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
