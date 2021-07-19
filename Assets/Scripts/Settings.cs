using UnityEngine;

public class Settings : MonoBehaviour
{
    public static Settings S;

    public int timeToPrepare;
    public int ballDirectionMinAngle;
    public float ballSpeed;
    public float timeToIncreaseSpeed;
    public float increaseSpeedAmount;
    public float padSpeed;

    private void Awake()
    {
        S = this;
    }
}
