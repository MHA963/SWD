using System;
#region lightswitch with states
// public class FlashLight
// {
//     public enum FlashLightEvent { PowerBtnPressed }
//     enum FlashLightState { On, Off }
//     private FlashLightState _currentState;

//     public FlashLight()
//     {
//         _currentState = FlashLightState.Off;
//     }

//     public void HandleEvent(FlashLightEvent evt)
//     {
//         switch (_currentState)
//         {
//             case FlashLightState.On:
//                 _currentState = FlashLightState.Off;
//                 break;
//             case FlashLightState.Off:
//                 _currentState = FlashLightState.On;
//                 break;
//         }
//     }

//     public string GetCurrentState()
//     {
//         return _currentState.ToString();
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         FlashLight flashLight = new FlashLight();

//         Console.WriteLine($"Initial state: {flashLight.GetCurrentState()}");

//         flashLight.HandleEvent(FlashLight.FlashLightEvent.PowerBtnPressed);
//         Console.WriteLine($"State after pressing power button: {flashLight.GetCurrentState()}");

//         flashLight.HandleEvent(FlashLight.FlashLightEvent.PowerBtnPressed);
//         Console.WriteLine($"State after pressing power button again: {flashLight.GetCurrentState()}");
//     }
// }
#endregion



using System;

// ILightState interface
interface ILightState
{
    void HandlePWRPressed();
}

// OnState class
class OnState : ILightState
{
    public void HandlePWRPressed()
    {
        Console.WriteLine("Turning off the light.");
    }
}

// OffState class
class OffState : ILightState
{
    public void HandlePWRPressed()
    {
        Console.WriteLine("Turning on the light.");
    }
}

// LightSwitch class
class LightSwitch
{
    private ILightState currentState;

    public LightSwitch()
    {
        currentState = new OffState(); // Initial state
    }

    public void SetState(ILightState state)
    {
        currentState = state;
    }

    public void PWRPressed()
    {
        currentState.HandlePWRPressed();
    }
}

class Program
{
    static void Main(string[] args)
    {
        LightSwitch lightSwitch = new LightSwitch();

        // Initial state: Off
        lightSwitch.PWRPressed(); // Turning on the light

        // Change state to On
        lightSwitch.SetState(new OnState());

        // Current state: On
        lightSwitch.PWRPressed(); // Turning off the light
    }
}
