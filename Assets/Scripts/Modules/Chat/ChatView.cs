﻿using UnityEngine;
using System.Collections;
using Util;
using UnityEngine.UI;

public class ChatView : SingletonMonoBehaviour<ChatView>
{
    private Button btn_chat;
    private InputField inputField;
    private GameObject itemGo;
    private Transform grid;
    private Transform tranf;
	void Start () 
    {
        tranf = transform;
        btn_chat = tranf.FindChild("Button").GetComponent<Button>();
        inputField = tranf.FindChild("InputField").GetComponent<InputField>();
        itemGo = Resources.Load("Prefabs/ChatView/item") as GameObject;
        grid = tranf.FindChild("Scroll/Grid");
        UIEventListener.Get(btn_chat.gameObject).onClick = OnClickChatBtn;
	}

    private void OnClickChatBtn(GameObject go)
    {
        AddChatItem(inputField.text);
        ChatModel.Instance.CTosChat("客户端", inputField.text);
        Debug.Log(inputField.text);
    }

    public void AddChatItem(string content)
    {
        GameObject chatItem = GameObject.Instantiate(itemGo) as GameObject;
        chatItem.transform.SetParent(grid, false);
        chatItem.transform.localPosition = Vector3.zero;
        chatItem.transform.localScale = Vector3.one;
        chatItem.transform.FindChild("Text").GetComponent<Text>().text = content;
    }
}
