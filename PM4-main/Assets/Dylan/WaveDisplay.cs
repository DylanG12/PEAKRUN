using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static EnemySpawner;
public class WaveDisplay : MonoBehaviour
{

    public TMP_Text WaveText;
    public TMP_Text CountdownText;

    public void UpdateUI()
    {
        WaveText.text = $" Wave: {WaveControls.nextWave + 1}";
        CountdownText.text = $" Countdown: {WaveControls.waveCountdown:F0}";


    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }
}
