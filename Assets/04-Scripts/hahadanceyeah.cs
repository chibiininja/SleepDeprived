using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hahadanceyeah : MonoBehaviour
{
    public Animator saunder;

    public void Dance()
    {
        saunder.SetBool("Dancing", !saunder.GetBool("Dancing"));
    }
}
