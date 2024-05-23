using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene1 : MonoBehaviour
{
    public void SceneChange()
    {
        GameObject.Find("Canvas").transform.Find("Setting").gameObject.SetActive(true);
    }
}
