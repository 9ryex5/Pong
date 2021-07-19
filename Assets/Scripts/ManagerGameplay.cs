using UnityEngine;

public class ManagerGameplay : MonoBehaviour
{
    public static ManagerGameplay MG;

    public Transform ball;
    public Transform pad1, pad2;

    private int score1, score2;

    private void Awake()
    {
        MG = this;
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W) && pad1.transform.position.y < 3)
            pad1.Translate(new Vector2(-Settings.S.padSpeed, 0));

        if (Input.GetKey(KeyCode.S) && pad1.transform.position.y > -3)
            pad1.Translate(new Vector2(Settings.S.padSpeed, 0));

        if (Input.GetKey(KeyCode.UpArrow) && pad2.transform.position.y < 3)
            pad2.Translate(new Vector2(Settings.S.padSpeed, 0));

        if (Input.GetKey(KeyCode.DownArrow) && pad2.transform.position.y > -3)
            pad2.Translate(new Vector2(-Settings.S.padSpeed, 0));
    }

    public void Score(bool _player1)
    {
        if (_player1)
        {
            score1++;
            ManagerUI.MUI.UpdateScore(true, score1.ToString());
        }
        else
        {
            score2++;
            ManagerUI.MUI.UpdateScore(false, score2.ToString());
        }
    }
}
