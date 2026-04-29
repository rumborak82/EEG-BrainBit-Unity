using UnityEngine;

public class EEGManager : MonoBehaviour
{
    // Това прави класа достъпен от всякъде
    public static EEGManager Instance;

    // дали да използваме фалшиви данни
    public bool useSimulation = true;

    // EEG канали
    public float F1;
    public float F2;
    public float O1;
    public float O2;

    void Awake()
    {
        // запазваме единствената инстанция
        Instance = this;
    }

    void Update()
    {
        if (useSimulation)
        {
            SimulateEEG();
        }
    }

    void SimulateEEG()
    {
        F1 = Mathf.Sin(Time.time * 8f);
        F2 = Mathf.Sin(Time.time * 7f);
        O1 = Mathf.Sin(Time.time * 6f);
        O2 = Mathf.Sin(Time.time * 5f);
    }

    // тук по-късно ще идват реални данни
    public void SetRealData(float[] data)
    {
        F1 = data[0];
        F2 = data[1];
        O1 = data[2];
        O2 = data[3];
    }
}