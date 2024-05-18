using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectExitShop : MonoBehaviour
{
    public void Exit()
    {

        SceneManager.LoadScene("SampleScene");
    }
}
