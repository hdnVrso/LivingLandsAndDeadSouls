using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Authentication
{
    public class StartScene : MonoBehaviour
    {
        public void LoadFirstPageScene()
        {
            SceneManager.LoadScene("FirstPage");
        }
    }
}
