//using System;
//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Game configuration data
    const string menuHint = "Type \"menu\" to return to TARS Corporation (TM) Terminal";
    string[] level1Passwords = { "drink", "coffee", "water", "ice cream", "croissant" };
    string[] level2Passwords = { "hacking", "phishing", "malware", "rootkit", "exploit" };
    string[] level3Passwords = { "ethereum", "distributed", "cryptanalysis", "decentralization", "satoshi nakamoto" };

    // Game State
    int level;
    string password;
    enum Screen { MainMenu, HintsScreen, WaitingForPassword, WinScreen };
    Screen currentScreen;

    // Use this for initialization
    void Start()
    {
        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        currentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to TARS Corporation (TM) Terminal");
        Terminal.WriteLine("Copyright (C) 2984-2987, TARS Corp. Software");
        Terminal.WriteLine("OS version: 22A1-P100-00\n");
        Terminal.WriteLine("Initializing...");
        Terminal.WriteLine("=========================================\n");
        Terminal.WriteLine("Memory Test: 281474976710656B OK\n");
        Terminal.WriteLine("Auto-Detecting modules ... TARS \"H@CK-MODULE\" found!\n");
        Terminal.WriteLine("Auto-Detecting modules ... TARS \"AI-MODULE\" found!\n");
        Terminal.WriteLine("Searching for devices nearby ...");
        Terminal.WriteLine("=========================================\n");
        Terminal.WriteLine("Please choose an option :\n");
        Terminal.WriteLine(" (1) \"Stellar Coffee\"");
        Terminal.WriteLine(" (2) \"Hacking the Hacker\"");
        Terminal.WriteLine(" (3) \"Adventures in Blockchain\"\n");
        Terminal.WriteLine("If you are not sure what to choose type \"hints\" to see more details about each option:");
        Terminal.WriteLine("What is your choise:");
    }

    void ShowHints()
    {
        currentScreen = Screen.HintsScreen;
        Terminal.ClearScreen();
        Terminal.WriteLine("TARS AI Hints:\n");
        Terminal.WriteLine("\"Stellar Coffee\" is the local coffehouse which still uses and old Windows 3000 OS and can be hacked without much hassle.\n");
        Terminal.WriteLine("George thinks that he is a great hacker, but you can prove himself that he is not.\n");
        Terminal.WriteLine("Ivan is an expirenced programmer and blockchain security specialist. Breaking into his computer will be a real challange!\n");
        Terminal.WriteLine(menuHint);
    }

    void OnUserInput(string input)
    {
        if (input == "menu") // This will bring the user back to the main menu
        {
            ShowMainMenu();
        }
        else if (input == "hints")
        {
            ShowHints();
        }
        else if (currentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (currentScreen == Screen.WaitingForPassword)
        {
            CheckPassword(input);
        }

    }


    //void Update()
    //{
    //    int index01 = Random.Range(0, level1Passwords.Length);
    //    print(index01);
    //    int index02 = Random.Range(0, level2Passwords.Length);
    //    print(index02);
    //}

    void RunMainMenu(string input)
    {
        bool isValidLevelNumber = (input == "1" || input == "2" || input == "3");
        if (isValidLevelNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else if (input == "2001") // Easter Egg #1
        {
            Terminal.WriteLine("A Space Odyssey");
        }
        else if (input == "2010") // Easter Egg #2
        {
            Terminal.WriteLine("The Year We Make Contact");
        }
        else
        {
            Terminal.WriteLine("Please choose a valid option");
        }
    }

    void AskForPassword()
    {
        currentScreen = Screen.WaitingForPassword;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine(menuHint);
        Terminal.WriteLine("");
        Terminal.WriteLine("Enter target password - hint: " + password.Anagram());
    }

    void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = level1Passwords[Random.Range(0, level1Passwords.Length)];
                break;
            case 2:
                password = level2Passwords[Random.Range(0, level2Passwords.Length)];
                break;
            case 3:
                password = level3Passwords[Random.Range(0, level3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid level number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (input == password)
        {
            DisplayWinScreen();
        }
        else
        {
            AskForPassword();
        }
    }

    void DisplayWinScreen()
    {
        currentScreen = Screen.WinScreen;
        Terminal.ClearScreen();
        ShowLevelReward();
        Terminal.WriteLine("\n\n\n\n\n\n\n\n\n\n");
        Terminal.WriteLine(menuHint);
    }

    void ShowLevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Good job! You hacked the coffee terminal! Now you can enjoy free coffee.");
                Terminal.WriteLine(@"

      )
     (   )
      )  ( 
   _______)___
  |---------- |
  |           |''.
  |  Coffee   |   '
  |           |  .'
  |           |''
  '==========='
  '|_________|'

“Coffee is a language in itself.” – Jackie Chan");
                break;
            case 2:
                Terminal.WriteLine("Well done! You proved that you are real hacker.\n");
                Terminal.WriteLine("\"Hackerman achievement unlocked!\"");
                Terminal.WriteLine(@"

 _    _   _____   _____   _   _   _____   ____    _     _   _____   _     _
| |  | | |  _  | |  ___| | | / / |  ___| |  _ \  | \   / | |  _  | |  \  | |
| |__| | | |_| | | |     | |/ /  | |___  | |_| ' |  \_/  | | |_| | |   \ | |
|  __  | |  _  | | |     |   '   |  ___| |    /  | |\_/| | |  _  | | |\ \| |
| |  | | | | | | | |___  | |\ \  | |___  | |\ \  | |   | | | | | | | | \   |
|_|  |_| |_| |_| |_____| |_| \_\ |_____| |_| \_\ |_|   |_| |_| |_| |_|  \ _|


“Hacking involves a different way of looking at problems that no one's thought of.”Walter O'Brien");
                break;
            case 3:
                Terminal.WriteLine("Impressive! You are a genius. You just won one Bitcoin!\n");
                Terminal.WriteLine(@"
        __......_   
     .-' _   _   '-.
   ..   | | | |    ''
  //  __| |_| |_     \\
 //  |__   _    '     \\
;;     |  |_|    '     ;;
||     |         '     ;;
||     |       ' .     ||
;:     |   __     '    :;
 \\   _|  |__|     '  //
  \\ /__   _   __.'  //
   ''   | | | |     '' 
     '-.|_| |_| _.-'

“Bitcoin is a remarkable cryptographic achievement and the ability to create something that is not duplicable in the digital world has enormous value”
Eric Schmidt");
                break;
            default:
                Debug.LogError("Invalid level number");
                break;

        }
        
    }
}
