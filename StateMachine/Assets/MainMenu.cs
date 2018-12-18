using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : ScreenBase
{
    public ScreenBase optionsAhmed;
    public override void UpdateScreen(ScreenManager SM)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SM.ChangeScreen(optionsAhmed);
        }
    }

}
