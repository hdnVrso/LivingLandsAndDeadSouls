using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Authentication
{
    public class LoadPasswordResetScene : MonoBehaviour
    {
        public void LoadScene()
        {
            SceneManager.LoadScene("PasswordReset");
        }
    }
}
