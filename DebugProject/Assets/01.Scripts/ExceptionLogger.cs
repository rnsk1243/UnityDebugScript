using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ExceptionLogger : MonoBehaviour {
    // StreamWriter 오브젝트의 내부 참조변수
    private System.IO.StreamWriter SW;

    // 로그를 남길 파일 이름
    public string LogFileName = "log.txt";

    // Use this for initialization
    void Start() {
        // 오브젝트가 파괴되지 않고 유지되도록 한다
        DontDestroyOnLoad(gameObject);
        // 문자열 기록 오브젝트를 생성한다
        // Application.persistentDataPath위치에 디버그 문자열을 쓸 수 있도록 새로운 StreamWriter오브젝트 만듬
        SW = new System.IO.StreamWriter(Application.persistentDataPath + "/" + LogFileName);

        Debug.Log(Application.persistentDataPath + "/" + LogFileName);
    }
    // 예외를 받아 기록할 수 있도록 등록한다
    void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }
    // 예외 등록 해제
    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }
	// 예외를 텍스트 파일로 기록한다
    void HandleLog(string logString, string stackTrace, LogType type)
    {
        // 예외나 오류인 경우 파일로 기록한다
        if(type == LogType.Exception || type == LogType.Error)
        {
            SW.WriteLine("Logged at: " + System.DateTime.Now.ToString()
                + " - Log Desc: " + logString
                + " - Trace: " + stackTrace
                + " - Type: " + type.ToString());
        }
    }

    // 오브젝트가 파괴될 때 호출됨
    void OnDestroy()
    {
        // 파일 닫음
        SW.Close();
    }
}
