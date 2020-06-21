using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeOutfitButton : MonoBehaviour
{
    private void Start()
    {
        _playerAnimator = GameObject.Find("Player").GetComponent<Animator>();
    }

    public void ChangeOutfit()
    {
        _playerAnimator.runtimeAnimatorController = outfitAnimator as RuntimeAnimatorController;
    }
    
    //data members
    public AnimatorOverrideController outfitAnimator;
    
    private Animator _playerAnimator;
}
