public static class InputManager
{
    private static Controls sideScrollerInput;

    //This method is subscribes a player component to the game controls
    public static void Init(PlayerMovement player)
    {
        sideScrollerInput = new Controls();

        //Subscribe SetMovementDirection to movement buttons
        sideScrollerInput.Movement.Movement.performed += context =>
        {
            player.SetMovementDir(context.ReadValue<float>());
        };
    }

    #region Modes
    //This method toggles on the game controls
    public static void GameMode()
    {
        sideScrollerInput.Movement.Enable();
        sideScrollerInput.UI.Disable();
    }

    //This method toggles on the UI controls
    public static void UIMode()
    {
        sideScrollerInput.Movement.Disable();
        sideScrollerInput.UI.Enable();
    }
    #endregion
}

