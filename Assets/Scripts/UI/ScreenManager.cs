using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    private ScreenBase[] screens;

    // Start is called before the first frame update
    void Awake()
    {
        App.screenManager = this;
        screens = GetComponentsInChildren<ScreenBase>(true);
    }

    public void Show<T>()
    {
        foreach(ScreenBase screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                screen.Show();
                return;
            }
        }
    }

    public void Hide<T>()
    {
        foreach(ScreenBase screen in screens)
        {
            if(screen.GetType() == typeof(T))
            {
                screen.Hide();
                return;
            }
        }
    }
}
