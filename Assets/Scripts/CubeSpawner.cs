using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject cubePrefab;
    
    [Header("Default Values")]
    [SerializeField] private float defaultTimeToNewCubeSpawn = 2;
    [SerializeField] private float defaultCubeSpeed = 10;
    [SerializeField] private float defaultMovingDistance = 10;
    [SerializeField] private Vector3 movingDirection = Vector3.one;
    [SerializeField] private Vector3 startPosition = Vector3.zero;

    [Header("Input Fields")]
    [SerializeField] private InputField timeToNewCubeSpawn;
    [SerializeField] private InputField cubeSpeed;
    [SerializeField] private InputField movingDistance;

    private float _currentTimeToNewCubeSpawn, _currentCubeSpeed, _currentMovingDistance;
    private float _lastSpawnTime;
    
    void Start()
    {
        _currentTimeToNewCubeSpawn = defaultTimeToNewCubeSpawn;
        _currentCubeSpeed = defaultCubeSpeed;
        _currentMovingDistance = defaultMovingDistance;

        timeToNewCubeSpawn.placeholder.GetComponent<Text>().text = defaultTimeToNewCubeSpawn.ToString(CultureInfo.CurrentCulture);
        cubeSpeed.placeholder.GetComponent<Text>().text = defaultCubeSpeed.ToString(CultureInfo.CurrentCulture);
        movingDistance.placeholder.GetComponent<Text>().text = _currentMovingDistance.ToString(CultureInfo.CurrentCulture);
    } 
    
    void Update()
    {
        if (Time.time > _lastSpawnTime + _currentTimeToNewCubeSpawn)
        {
            var duration = (_currentMovingDistance / _currentCubeSpeed);
            var newCube = Instantiate(cubePrefab, startPosition  , Quaternion.identity);
            newCube.GetComponent<Cube>().Initialize(duration,movingDirection.normalized * _currentMovingDistance);
            _lastSpawnTime = Time.time;
        }
    }

    private void OnEnable()
    {
        timeToNewCubeSpawn.onEndEdit.AddListener(ChangeTimeToNewCubeSpawn);
        cubeSpeed.onEndEdit.AddListener(ChangeCubeSpeed);
        movingDistance.onEndEdit.AddListener(ChangeMovingDistance);
    }

    private void OnDisable()
    {
        timeToNewCubeSpawn.onEndEdit.RemoveListener(ChangeTimeToNewCubeSpawn);
        cubeSpeed.onEndEdit.RemoveListener(ChangeCubeSpeed);
        movingDistance.onEndEdit.RemoveListener(ChangeMovingDistance);
    }

    private void ChangeTimeToNewCubeSpawn(string text)
    {
        if (text.Length > 0)
        {
            var x = Convert.ToSingle(text);
            _currentTimeToNewCubeSpawn = x;
        }
        else
        {
            timeToNewCubeSpawn.text = _currentTimeToNewCubeSpawn.ToString(CultureInfo.CurrentCulture);
        }
        
    }

    private void ChangeCubeSpeed(string text)
    {
        if (text.Length > 0)
        {
            _currentCubeSpeed = Convert.ToSingle(text);
        }
        else
        {
            cubeSpeed.text = _currentCubeSpeed.ToString(CultureInfo.CurrentCulture);
        }
    }

    private void ChangeMovingDistance(string text)
    {
        if (text.Length > 0)
        {
            _currentMovingDistance = Convert.ToSingle(text);
        }
        else
        {
            movingDistance.text = _currentMovingDistance.ToString(CultureInfo.CurrentCulture);
        }
    }
}
