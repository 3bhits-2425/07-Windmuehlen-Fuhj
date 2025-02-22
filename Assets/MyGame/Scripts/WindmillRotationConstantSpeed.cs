using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class WindmillRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private Transform rotatingPart;
    [SerializeField] private Slider speedSlider;
    [SerializeField] private Light windmillLight;
    [SerializeField] private Button lockSpeedButton;

    private static List<WindmillRotation> allWindmills = new List<WindmillRotation>();
    private static int currentActiveIndex = -1;

    private bool isRotating = false;
    private bool isSpeedLocked = false;

    private void Awake()
    {
        allWindmills.Add(this);
        allWindmills.Sort((a, b) => a.rotatingPart.position.x.CompareTo(b.rotatingPart.position.x));
    }

    private void Start()
    {
        if (speedSlider != null)
        {
            speedSlider.minValue = 0f;
            speedSlider.maxValue = 255f;
            speedSlider.value = rotationSpeed;
            speedSlider.onValueChanged.AddListener(UpdateSpeedFromSlider);
        }

        if (lockSpeedButton != null)
        {
            lockSpeedButton.onClick.AddListener(LockSpeed);
        }

        UpdateWindmillLight();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currentActiveIndex == -1)
        {
            currentActiveIndex = 0;
            allWindmills[currentActiveIndex].StartRotation();
        }

        if (isRotating && rotatingPart != null)
        {
            rotatingPart.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        UpdateWindmillLight();
    }

    private void UpdateSpeedFromSlider(float value)
    {
        if (!isSpeedLocked)
        {
            rotationSpeed = value;
            UpdateWindmillLight();
        }
    }

    private void LockSpeed()
    {
        if (!isSpeedLocked)
        {
            isSpeedLocked = true;
            Debug.Log($"Windrad bei X={rotatingPart.position.x} gesperrt mit Geschwindigkeit: {rotationSpeed}");

            if (currentActiveIndex + 1 < allWindmills.Count)
            {
                currentActiveIndex++;
                allWindmills[currentActiveIndex].StartRotation();
            }
        }
    }

    private void StartRotation()
    {
        isRotating = true;
        Debug.Log($"Windrad bei X={rotatingPart.position.x} gestartet!");
    }

    private void UpdateWindmillLight()
    {
        if (windmillLight != null)
        {
            float minIntensity = 0.1f;   // Fast kein Licht
            float midIntensity = 5f;     // Normale Beleuchtung
            float maxIntensity = 50f;    // Extrem grell!

            float speedFactor = rotationSpeed / 255f;

            // Wenn die Geschwindigkeit max. ist -> Licht explodiert, sonst nimmt es stark ab
            if (rotationSpeed >= 255f)
            {
                windmillLight.intensity = maxIntensity;
            }
            else
            {
                windmillLight.intensity = Mathf.Lerp(minIntensity, midIntensity, Mathf.Pow(speedFactor, 1.5f));
            }
        }
    }
}
