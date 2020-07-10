using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using UnityEngine.UI;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

namespace Authentication
{
    public class PlayFabLogin : MonoBehaviour
    {

        /*void Start()
        {
            if (PlayerPrefs.HasKey("EMAIL"))
            {
                _userEmail=PlayerPrefs.GetString("EMAIL");
                _userPassword=PlayerPrefs.GetString("PASSWORD");
                var request = new LoginWithEmailAddressRequest { Email=_userEmail, Password=_userPassword };
                PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailed);
            }
        }*/


    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("User logged !");
        PlayerPrefs.SetString("EMAIL", _userEmail);
        PlayerPrefs.SetString("PASSWORD", _userPassword);
        Debug.Log("Hello, user");
        SceneManager.LoadScene("Menu");
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        Debug.Log("User registered !");
        PlayerPrefs.SetString("EMAIL", _userEmail);
        PlayerPrefs.SetString("PASSWORD", _userPassword);
        OnClickLogin();
        SceneManager.LoadScene("Menu");
    }

    private void OnRegisterFailure(PlayFabError error)
    {
        Debug.LogError(error.GenerateErrorReport());
        string[] errorReport = error.GenerateErrorReport().Split();
        if (errorReport[1] == "Username")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Никнейм занят";
        }
        else if (errorReport[1] == "Email")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Email занят или имеет неверный формат";
        }
        else if (errorReport[4] == "Username:")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Логин может содержать буквы латинницы";
        }
        else if (errorReport[4] == "Password:")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Неверный формат пароля";
        }
    }

    void OnLoginFailed(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport());
        string[] errorReport = error.GenerateErrorReport().Split();
        if (errorReport[1] == "User")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Данный пользователь не найден";
        }
        if (errorReport[4] == "host")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Отсутствует соединение с сетью Интернет";
        }
        if (errorReport[4] == "Email:")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Неправильный пароль или логин";
        }

        if (errorReport[1] == "Invalid")
        {
            GameObject.Find("LoginFailed").GetComponent<Text>().text = "Неправильный пароль или логин";
        }
    }

    public void GetUserEmail(string email)
    {
        _userEmail = email;
    }

    public void GetUserPassword(string password)
    {
        _userPassword = password;
    }

    public void OnClickLogin()
    {
        var request = new LoginWithEmailAddressRequest { Email = _userEmail, 
            Password = _userPassword };
        PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnLoginFailed);
    }

    public void GetUsername(string username)
    {
        this._username = username;
    }

    public void OnClickRegister()
    {
        var registerRequest = new RegisterPlayFabUserRequest { Email = _userEmail, 
            Password = _userPassword, Username = _username };
        PlayFabClientAPI.RegisterPlayFabUser(registerRequest, OnRegisterSuccess, OnRegisterFailure);
    }


    public void RecoveryPassword()
    {
        string email = emailPanel.text;
        var request = new SendAccountRecoveryEmailRequest();
        request.Email = email;
        request.TitleId = "99BF5";
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

    public GameObject loginPanel;
    public InputField emailPanel;

    private string _userEmail;
    private string _userPassword;
    private string _username;
}
}