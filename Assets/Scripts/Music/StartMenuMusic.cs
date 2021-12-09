using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMainMenuTheme();
    }
}
