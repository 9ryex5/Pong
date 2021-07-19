using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector2 direction;

    private float timerPrepare;
    private bool isMoving;

    private float extraSpeed;
    private float timerIncreaseSpeed;

    private void Start()
    {
        Restart();
    }

    private void Update()
    {
        if (!isMoving)
        {
            timerPrepare -= Time.deltaTime;

            if (timerPrepare <= 0)
                isMoving = true;
        }
        else
        {
            if (transform.position.x > 10)
            {
                ManagerGameplay.MG.Score(true);
                Restart();
                return;
            }

            if (transform.position.x < -10)
            {
                ManagerGameplay.MG.Score(false);
                Restart();
                return;
            }

            timerIncreaseSpeed -= Time.deltaTime;

            if (timerIncreaseSpeed <= 0)
            {
                extraSpeed += Settings.S.increaseSpeedAmount;
                timerIncreaseSpeed = Settings.S.timeToIncreaseSpeed;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!isMoving) return;
        transform.Translate(direction * (Settings.S.ballSpeed + extraSpeed));
    }

    private void OnCollisionEnter2D(Collision2D _col)
    {
        direction = Vector2.Reflect(direction, _col.GetContact(0).normal);
    }

    private void Restart()
    {
        transform.position = Vector2.zero;

        do
        {
            direction = Random.insideUnitCircle.normalized;
        } while (Vector2.Angle(Vector2.up, direction) < Settings.S.ballDirectionMinAngle || Vector2.Angle(Vector2.down, direction) < Settings.S.ballDirectionMinAngle);

        extraSpeed = 0;

        timerPrepare = Settings.S.timeToPrepare;
        timerIncreaseSpeed = Settings.S.timeToIncreaseSpeed;
        isMoving = false;
    }
}
