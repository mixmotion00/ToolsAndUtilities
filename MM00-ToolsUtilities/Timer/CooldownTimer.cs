using System;

//*** HOW TO USE ***//
//create field private CooldownTimer timer;
//in Start() create timer object eg: timer = new CooldownTimer(10f, ()=>Debug.Log("Hello"));
//in Update() timer.Update(Time.DeltaTime);
//******************//

public class CooldownTimer 
{
    private float _interval;
    private float _currTime;
    public Action OnInterval { get; set; }

    public CooldownTimer(float interval, Action onTimelapsed) 
    {
        OnInterval = onTimelapsed;
        _interval = interval;
        _currTime = _interval;
    }

    public void Tick(float deltaTime) 
    {
        _currTime -= deltaTime;
        if(_currTime <= 0.0f) 
        {
            OnInterval?.Invoke();
            _currTime = _interval;
        }
    }
}
