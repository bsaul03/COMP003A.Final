using System;

/// <summary>
/// This application collects information to create a new user profile for a dating app.
/// Author: Saul Barajas
/// Course: COMP003A-L01
/// Purpose: Final Project
/// </summary>
class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Dating App - New User Profile Intake Form\n");

        // User Input Section
        string firstName = ValidateName("First Name");
        string lastName = ValidateName("Last Name");
        int birthYear = ValidateBirthYear();
        char gender = ValidateGender();

        // Questionnaire Section
        string[] questions = new string[]
        {
            "What is your favorite hobby?",
            "What is your favorite movie?",
            "Describe your ideal date?",
            "What are you looking for in a partner?",
            "What is your favorite travel destination?",
            "What is your favorite food?",
            "What are your pet peeves?",
            "What is your dream job?",
            "What are your long-term goals?",
            "What is something unique about yourself?"
        };

        string[] userResponses = new string[questions.Length];

        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine(questions[i]);
            userResponses[i] = Console.ReadLine();
        }

        // Profile Summary Section
        Console.WriteLine("\nProfile Summary:");
        Console.WriteLine($"Name: {lastName}, {firstName}");
        Console.WriteLine($"Age: {DateTime.Now.Year - birthYear}");
        Console.WriteLine($"Gender: {GetFullGenderDescription(gender)}\n");

        Console.WriteLine("Questionnaire Responses:");
        for (int i = 0; i < questions.Length; i++)
        {
            Console.WriteLine($"Question {i + 1}: {questions[i]}");
            Console.WriteLine($"Response {i + 1}: {userResponses[i]}\n");
        }
    }

    /// <summary>
    /// Validates and returns the user's first or last name.
    /// </summary>
    /// <param name="nameType">The type of name (first or last).</param>
    /// <returns>The validated first or last name.</returns>
    static string ValidateName(string nameType)
    {
        string name;
        do
        {
            Console.Write($"Enter {nameType}: ");
            name = Console.ReadLine().Trim();
        } while (string.IsNullOrWhiteSpace(name) || ContainsNumbersOrSpecialCharacters(name));

        return name;
    }

    /// <summary>
    /// Validates and returns the user's birth year.
    /// </summary>
    /// <returns>The validated birth year.</returns>
    static int ValidateBirthYear()
    {
        int birthYear;
        do
        {
            Console.Write("Enter Birth Year: ");
            int.TryParse(Console.ReadLine(), out birthYear);
        } while (birthYear < 1900 || birthYear > DateTime.Now.Year);

        return birthYear;
    }

    /// <summary>
    /// Validates and returns the user's gender.
    /// </summary>
    /// <returns>The validated gender.</returns>
    static char ValidateGender()
    {
        char gender;
        do
        {
            Console.Write("Enter Gender (M/F/O): ");
            char.TryParse(Console.ReadLine().ToUpper(), out gender);
        } while (gender != 'M' && gender != 'F' && gender != 'O');

        return gender;
    }

    /// <summary>
    /// Checks if the input string contains numbers or special characters.
    /// </summary>
    /// <param name="input">The input string to check.</param>
    /// <returns>True if the input contains numbers or special characters; otherwise, false.</returns>
    static bool ContainsNumbersOrSpecialCharacters(string input)
    {
        foreach (char c in input)
        {
            if (char.IsDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c))
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Returns the full description of the user's gender.
    /// </summary>
    /// <param name="gender">The gender code (M/F/O).</param>
    /// <returns>The full description of the gender.</returns>
    static string GetFullGenderDescription(char gender)
    {
        switch (gender)
        {
            case 'M':
                return "Male";
            case 'F':
                return "Female";
            case 'O':
                return "Other";
            default:
                return "Unknown";
        }
    }
}
