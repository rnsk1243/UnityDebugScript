using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelegateUsage : MonoBehaviour {
    // 델리게이트의 형식을 선언한다 - 파라미터, 반환 형식
    public delegate void EventHandler(int Param1, int Param2);
    // 해당 델리게이트 형식의 함수 참조를 담는 배열을 선언한다
    public EventHandler[] EH = new EventHandler[10];

    void Awake()
    {
        // HandleMyEvent를 델리게이트 목록에 추가한다.
        EH[0] = HandleMyEvent;
    }
	// Use this for initialization
	void Start () {
		// 모든 델리게이트 리스트를 순회하며 모든 이벤트를 호출한다.
        // 리스트 안의 모든 델리게이트를 순회한다
        foreach(EventHandler e in EH)
        {
            if(e != null)
            {
                e(0, 0);
            }
        }
	}
	
	void HandleMyEvent(int Param1, int Param2)
    {
        Debug.Log("Event Called = " + (Param1 + Param2));
    }
}
