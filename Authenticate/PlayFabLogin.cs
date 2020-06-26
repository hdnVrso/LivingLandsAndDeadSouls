using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using UnityEngine.UI;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
public class PlayFabLogin : MonoBehaviour
{
    private string userEmail;
    private string userPassword;
    private string username;
    public GameObject loginPanel;
    public InputField emailPanel;

    //This method let to skip loginPanel and athenticate authomatically
    /*void Start()
    {
        if (PlayerPrefs.HasKey("EMAIL"))
        {
            userEmail=PlayerPrefs.GetString("EMAIL");
            userPassword=PlayerPrefs.GetString("PASSWORD");
            var request = new LoginWithEmailAddressRequest { Email=userEmail, Password=userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailed);
        }
    }*/


    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("User logged !");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        Debug.Log("Hello, user");
        SceneManager.LoadScene("Menu");
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("User registered !");
        PlayerPrefs.SetString("EMAIL", userEmail);
        PlayerPrefs.SetString("PASSWORD", userPassword);
        OnClickLogin();
        SceneManager.LoadScene("Menu");
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        string[] errorReport = error.GenerateErrorReport().Split();
        if (errorReport[1]=="Username")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Никнейм занят";
        }
        else if (errorReport[1]=="Email")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Email занят или имеет неверный формат";
        }
        else if (errorReport[4]=="Username:")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Логин может содержать буквы латинницы";
        }
        else if (errorReport[4]=="Password:")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Неверный формат пароля";
        }
    }

    void OnLoginFailed(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        string[] errorReport = error.GenerateErrorReport().Split();
        if (errorReport[4]=="host")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Отсутствует соединение с сетью Интернет";
        }
        if (errorReport[4]=="Email:")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Неправильный пароль или логин";
        }

        if (errorReport[1] == "Invalid")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text="Неправильный пароль или логин";
        }
    }

    public void GetUserEmail(string email)
    {

        userEmail=email;
    }

    public void GetUserPassword(string password)
    {
        userPassword=password;
    }

    public void OnClickLogin()
    {
            var request = new LoginWithEmailAddressRequest { Email=userEmail, Password=userPassword };
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailed);
    }

    public void GetUsername(string username)
    {
        this.username=username;
    }

    public void OnClickRegister()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email=userEmail, Password=userPassword, Username=username };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }


    public void RecoveryPassword()
    {
        string email = emailPanel.text;
        var request = new SendAccountRecoveryEmailRequest();
        request.Email=email;
        request.TitleId="99BF5";
        PlayFab.PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoveryEmailSuccess, OnRecoveryEmailFailed);

    }

    public void OnRecoveryEmailSuccess(SendAccountRecoveryEmailResult result)
    {
        Debug.Log("Password reset");
        SceneManager.LoadScene("Login");
    }

    public void OnRecoveryEmailFailed(PlayFab.PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
    }
}
