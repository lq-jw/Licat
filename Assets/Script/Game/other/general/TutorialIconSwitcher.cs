using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialIconSwitcher : MonoBehaviour
{
    [SerializeField] private Sprite keyboardIcon, HandleIcon;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isUseHandle_now = false, isUseHandle_pre = false;

    void Start()
    {
        InitSpriteRenderer();
        GetIsUseHandle();
        UpdateIsUseHandlePre();
    }

    private void Update()
    {
        if (spriteRenderer != null)
        {
            UpdateIcon();
        }
    }

    /////////////
    private void InitSpriteRenderer()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("Sprite Renderer not found.");
        }
    }

    private void UpdateIcon()
    {
        GetIsUseHandle();
        SwitchSpite();
        // if (isUseHandle_now != isUseHandle_pre) SwitchSpite();
        // 如果 spriteRenderer 存在 && isUseHandle 有更新過，就更新 Spite
        UpdateIsUseHandlePre();
    }

    private void SwitchSpite()
    {
        if (isUseHandle_now) spriteRenderer.sprite = HandleIcon;
        else spriteRenderer.sprite = keyboardIcon;
        // Debug.Log("SwitchSpite");
    }

    private void GetIsUseHandle()
    {
        isUseHandle_now = GameManager.instance.GetIsUseHandle();
    }

    private void UpdateIsUseHandlePre()
    {
        isUseHandle_pre = isUseHandle_now;
    }
}