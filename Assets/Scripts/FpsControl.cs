using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsControl : MonoBehaviour
{
    public float timer, refresh, avgFramerate;
    public string display = "{0} FPS";
    public Text m_Text;

    void Awake()
    {
        QualitySettings.vSyncCount = 1;
        Application.targetFrameRate = 30;
    }

    void Update()
    {
#if DEVELOPMENT_BUILD
        float timelapse = Time.smoothDeltaTime;
        timer = timer <= 0 ? refresh : timer -= timelapse;

        if (timer <= 0) avgFramerate = (int)(1f / timelapse);
        m_Text.text = string.Format(display, avgFramerate.ToString());
#endif
    }
}
