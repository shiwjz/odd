using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectConfirm : MonoBehaviour

{
    public void Confirm()
    {
        SceneManager.LoadScene("SampleScene");
    }
}