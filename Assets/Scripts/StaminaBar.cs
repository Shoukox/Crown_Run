using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Image StamBar;
    public float StamBarFill;

    void Start()
    {
        StamBarFill = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && StamBarFill >= 0)
        {
            StamBarFill -= 0.01f;
        } else if (StamBarFill != 1f)
        {
            StamBarFill += 0.01f;
        }
        StamBar.fillAmount = StamBarFill;
    }
}
