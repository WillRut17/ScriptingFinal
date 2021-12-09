using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayGameTheme();
    }
}
