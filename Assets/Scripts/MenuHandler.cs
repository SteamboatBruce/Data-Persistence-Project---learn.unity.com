using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{

    public TMP_InputField nameField;
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        // Put focus on player name field
        EventSystem.current.SetSelectedGameObject(nameField.gameObject, null);
        nameField.OnPointerClick(new PointerEventData(EventSystem.current));
        onNameValueChanged();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        if (startButton.interactable)
        {
            SceneManager.LoadScene("main");
        }

    }

    public void onNameValueChanged()
    {
        GameManager.Instance.playerName = nameField.text.Trim();
        //startButton.enabled = GameManager.Instance.playerName.Length > 0;
        startButton.interactable = GameManager.Instance.playerName.Length > 0;

    }
}
