# 2.S.UnityAssignment
Documentation

To execute the game load the 'MainMenu' scene.
    From the 'MainMenu' scene click on 'Start' to open the level select panel and select level 1. (level 2 does not have gameplay to it yet)

Used packages:
    InputSystem, Cinemachine, Art Assets from Penusbmic (itch.io / patreon)


Requirements:
    Git
       Uploaded to Git
      .gitignore 
       min. 4 commits

    Documentation
        Comments in code
        Text-Document

    Funktion
        Main Menu (funktional)
        Level 1 (accessible and gameplay)

    UI
        Menu (Start -> levvel select, Options -> no options implemented, credits, exit)
        Win & Lose screen (not working yet)
        'ESC' -> pause screen

    Gameplay
        2D Side Scrolling Character [left/right movement, jump, double jump, wallslide] (PlayerMovement.cs)

    Additional Functions
        Character animation
        Particle effect
        Environment -> Tileset/Tilemap

    Scripts
        BackgroundController.cs -> Parallax effect
        LevelMenu.cs -> Level select when pressing Start in MainMenu
        MainMenu.cs -> Start, Options, Credits, Quit
        PauseMenu.cs -> Pause menu activated by pressing 'ESC'
        PlayerMovement.cs -> Playermovent (Walk, Jump, Doublejump, Wallslide)
        WinLoseManager.cs -> Started implementing Lose/Win screen

    Things not added due to lack of time:
        Win/Lose screen
        Win/Lose conditions
        Moveable platforms and DoNotTouch objects
        Collectibles
        Sneack/Crouch

I tried