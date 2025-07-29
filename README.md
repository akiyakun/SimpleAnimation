# SimpleAnimation

This is a sample that shows how to use Playable Graphs to animate objects in a manner similar to the Animation Component. 

# Changes
## SimpleAnimation class
Add pause and resume methods.
```cs
public bool IsPauseTime(string name)
public void Pause(string stateName)
public void Resume(string stateName)
```

Add a pause parameter to the Play method.
`Play(string stateName, bool pause = false)`


Add IsInitialized property.
`public bool IsInitialized`

