using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    public static ManagerUI MUI;

    public Text textScore1, textScore2;

    private void Awake()
    {
        MUI = this;
    }

    public void UpdateScore(bool _player1, string _text)
    {
        if (_player1)
            textScore1.text = _text;
        else
            textScore2.text = _text;
    }
}
