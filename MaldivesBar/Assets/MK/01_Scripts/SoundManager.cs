using System.Collections;
using System.Collections.Generic;
using MKDir;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this.gameObject);
    }
}
