using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : ScreenBase {
    public ScreenBase mainMenu;
    public override void UpdateScreen(ScreenManager SM)
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            SM.ChangeScreen(mainMenu);
        }
    }

}   
