using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection.Metadata;

namespace EternalQuest
{
    public class GoalManager
    {
        private List<Goal> _goals;
        private int _totalPoints;

        public GoalManager() 
        {
            _goals = new List<Goal>();
            _totalPoints = 0;
        }
        
        public void Start()
        {
            Console.WriteLine($"You have {_totalPoints} points.");
            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
        }
        
        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"Current Points: {_totalPoints}");
            ListGoalDetails();
        }
        
        public void ListGoalNames()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You have no goals listed.");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {_goals[i].GetName()}");
                }
            }
        }
        
        public void ListGoalDetails()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You have no goals listed.");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{_goals[i].GetStringRepresentation()}");
                }
            }
        }
        
        public void CreateGoal()
        {
            string goalType = "";
            while (goalType != "1" && goalType != "2" && goalType != "3") // Fixed logical condition
            {
                Console.WriteLine("The types of Goals are:");
                Console.WriteLine(" 1. Simple Goal");
                Console.WriteLine(" 2. Eternal Goal");
                Console.WriteLine(" 3. Checklist Goal");
                Console.WriteLine("Which type of Goal would you like to create?");
                goalType = Console.ReadLine();
                Console.Clear();
                
                if (goalType != "1" && goalType != "2" && goalType != "3")
                {
                    Console.WriteLine("Invalid input, please input a numerical value between 1 and 3.");
                }
            }

            Console.Write("What is the name of your goal? ");
            string name = Console.ReadLine();
            Console.Clear();
            
            Console.Write("What is a short description of it? ");
            string description = Console.ReadLine();
            Console.Clear();
            
            Console.Write("What is the amount of points associated with this goal? ");
            int points;
            while (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.WriteLine("Invalid input, please input a numerical value.");
                Console.Write("What is the amount of points associated with this goal? ");
            }

            Goal newGoal = null;
            switch (goalType)
            {
                case "1":
                    newGoal = new Simple(name, description, points);
                    break;
                case "2":
                    newGoal = new Eternal(name, description, points);
                    break;
                case "3":
                    Console.WriteLine("How many times does this Goal need to be accomplished for a bonus?");
                    int target;
                    while (!int.TryParse(Console.ReadLine(), out target))
                    {
                        Console.WriteLine("Invalid input please enter a numerical value.");
                        Console.WriteLine("How many times does this Goal need to be accomplished for a bonus?");
                    }

                    Console.WriteLine("What is the bonus for accomplishing it that many times?");
                    int bonus;
                    while (!int.TryParse(Console.ReadLine(), out bonus))
                    {
                        Console.WriteLine("Invalid input please enter a numerical value.");
                        Console.WriteLine("What is the bonus for accomplishing it that many times?");
                    }

                    newGoal = new Checklist(name, description, points, target, bonus);
                    break;
                default:
                    Console.WriteLine("Please enter a Goal number between 1-3.");
                    return;
            }
            
            _goals.Add(newGoal);
            Console.WriteLine($"Goal '{name}' has been created successfully!");
        }

        public void RecordEvent()
        {
            if (_goals.Count == 0)
            {
                Console.WriteLine("You have no goals to record events for.");
                return;
            }

            Console.WriteLine("Which goal did you accomplish?");
            Console.WriteLine("The goals are:");
            ListGoalNames();
            
            int accomplishment;
            
            while (true)
            {
                Console.Write("Enter the number of the goal you accomplished: ");
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out accomplishment) && 
                    accomplishment >= 1 && accomplishment <= _goals.Count)
                {
                    break; // Valid input - exit the loop
                }
                else
                {
                    Console.WriteLine($"Invalid input. Please enter a number between 1 and {_goals.Count}.");
                }
            }
            
            // Continue with valid goal number
            int goalIndex = accomplishment - 1;
            
            // Handle different goal types properly
            if (_goals[goalIndex] is Simple)
            {
                if (!_goals[goalIndex].IsComplete())
                {
                    _goals[goalIndex].RecordEvent();
                    int pointsEarned = _goals[goalIndex].GetPoints();
                    _totalPoints += pointsEarned;
                    Console.WriteLine($"Great Job! You have earned {pointsEarned} points!");
                    Console.WriteLine($"You now have {_totalPoints} points.");
                }
                else
                {
                    Console.WriteLine($"The '{_goals[goalIndex].GetName()}' goal was already completed!");
                }
            }
            else if (_goals[goalIndex] is Eternal)
            {
                // Eternal goals can always be completed
                _goals[goalIndex].RecordEvent();
                int pointsEarned = _goals[goalIndex].GetPoints();
                _totalPoints += pointsEarned;
                Console.WriteLine($"Great Job! You have earned {pointsEarned} points!");
                Console.WriteLine($"You now have {_totalPoints} points.");
            }
            else if (_goals[goalIndex] is Checklist checklist)
            {
                if (!checklist.IsComplete())
                {
                    checklist.RecordEvent();
                    int pointsEarned = checklist.GetPoints();
                    
                    // Check if they just completed the checklist for bonus
                    if (checklist.IsComplete())
                    {
                        pointsEarned += checklist.GetBonus();
                        Console.WriteLine($"Bonus earned for completing the checklist!");
                    }
                    
                    _totalPoints += pointsEarned;
                    Console.WriteLine($"Great Job! You have earned {pointsEarned} points!");
                    Console.WriteLine($"You now have {_totalPoints} points.");
                }
                else
                {
                    Console.WriteLine($"The '{checklist.GetName()}' checklist is already complete!");
                }
            }
        }
        
        public void SaveGoals()
        {
            string filename = "EternalQuestFile.txt";

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_totalPoints);
                foreach (Goal goal in _goals)
                {
                    // Save in a format that includes all necessary data for loading
                    string saveData = GetGoalSaveData(goal);
                    outputFile.WriteLine(saveData);
                }
            }
            Console.WriteLine($"Goals saved to {filename}");
        }
        
        // Helper method to create complete save data for goals
        private string GetGoalSaveData(Goal goal)
        {
            if (goal is Simple simple)
            {
                return $"Simple|{simple.GetName()}|{simple.GetDescription()}|{simple.GetPoints()}|{simple.IsComplete()}";
            }
            else if (goal is Eternal eternal)
            {
                return $"Eternal|{eternal.GetName()}|{eternal.GetDescription()}|{eternal.GetPoints()}";
            }
            else if (goal is Checklist checklist)
            {
                return $"Checklist|{checklist.GetName()}|{checklist.GetDescription()}|{checklist.GetPoints()}|{checklist.GetTarget()}|{checklist.GetBonus()}|{checklist.GetAmountCompleted()}|{checklist.IsComplete()}";
            }
            else
            {
                // Fallback to the display representation if type is unknown
                return goal.GetStringRepresentation();
            }
        }
        
        public void LoadGoals()
        {
            string filename = "EternalQuestFile.txt";
            
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} not found. No goals loaded.");
                return;
            }
            
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filename);
                
                if (lines.Length == 0)
                {
                    Console.WriteLine("File is empty. No goals loaded.");
                    return;
                }
                
                // First line should be total points
                if (int.TryParse(lines[0], out int points))
                {
                    _totalPoints = points;
                }
                else
                {
                    Console.WriteLine("Invalid file format. Could not load total points.");
                    return;
                }
                
                // Clear existing goals
                _goals.Clear();
                
                // Parse each goal line
                for (int i = 1; i < lines.Length; i++)
                {
                    Goal goal = ParseGoalFromString(lines[i]);
                    if (goal != null)
                    {
                        _goals.Add(goal);
                    }
                    else
                    {
                        Console.WriteLine($"Warning: Could not parse goal from line {i + 1}");
                    }
                }
                
                Console.WriteLine($"Successfully loaded {_goals.Count} goals and {_totalPoints} total points from {filename}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading goals: {ex.Message}");
            }
        }
        
        // Helper method to parse goal from string representation
        private Goal ParseGoalFromString(string goalString)
        {
            try
            {
                Console.WriteLine($"DEBUG: Attempting to parse: '{goalString}'");
                
                // Check if it's the new pipe-separated format
                if (goalString.Contains("|"))
                {
                    return ParsePipeSeparatedFormat(goalString);
                }
                // Check if it's the old checkbox format
                else if (goalString.StartsWith("[ ]") || goalString.StartsWith("[X]"))
                {
                    return ParseGoalCheckboxFormat(goalString);
                }
                else
                {
                    Console.WriteLine($"DEBUG: Unknown format for: '{goalString}'");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing goal string '{goalString}': {ex.Message}");
                return null;
            }
        }
        
        // Helper method for the new pipe-separated format
        private Goal ParsePipeSeparatedFormat(string goalString)
        {
            try
            {
                string[] parts = goalString.Split('|');
                
                if (parts.Length < 4)
                {
                    Console.WriteLine("DEBUG: Not enough parts in pipe-separated format");
                    return null;
                }
                
                string type = parts[0].Trim();
                string name = parts[1].Trim();
                string description = parts[2].Trim();
                
                if (!int.TryParse(parts[3].Trim(), out int points))
                {
                    Console.WriteLine($"DEBUG: Could not parse points from '{parts[3]}'");
                    return null;
                }
                
                Goal goal = null;
                
                switch (type.ToLower())
                {
                    case "simple":
                        goal = new Simple(name, description, points);
                        if (parts.Length > 4 && bool.TryParse(parts[4].Trim(), out bool isComplete) && isComplete)
                        {
                            goal.RecordEvent();
                        }
                        break;
                        
                    case "eternal":
                        goal = new Eternal(name, description, points);
                        break;
                        
                    case "checklist":
                        if (parts.Length >= 7)
                        {
                            if (int.TryParse(parts[4].Trim(), out int target) && 
                                int.TryParse(parts[5].Trim(), out int bonus) && 
                                int.TryParse(parts[6].Trim(), out int amountCompleted))
                            {
                                goal = new Checklist(name, description, points, target, bonus);
                                
                                // Record events to match the saved state
                                for (int i = 0; i < amountCompleted; i++)
                                {
                                    goal.RecordEvent();
                                }
                            }
                            else
                            {
                                Console.WriteLine("DEBUG: Could not parse checklist parameters");
                                return null;
                            }
                        }
                        else
                        {
                            Console.WriteLine("DEBUG: Not enough parts for checklist goal");
                            return null;
                        }
                        break;
                        
                    default:
                        Console.WriteLine($"DEBUG: Unknown goal type: '{type}'");
                        return null;
                }
                
                Console.WriteLine($"DEBUG: Successfully created {type} goal: '{name}'");
                return goal;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing pipe-separated format '{goalString}': {ex.Message}");
                return null;
            }
        }
        
        // Helper method for your specific checkbox format
        private Goal ParseGoalCheckboxFormat(string goalString)
        {
            try
            {
                bool isComplete = goalString.StartsWith("[X]");
                
                // Remove the checkbox part: "[X] " or "[ ] "
                string content = goalString.Substring(4);
                
                // Extract name and description
                int descStart = content.IndexOf('(');
                int descEnd = content.IndexOf(')');
                
                if (descStart == -1 || descEnd == -1 || descEnd <= descStart)
                {
                    Console.WriteLine("DEBUG: Could not find description parentheses");
                    return null;
                }
                
                string name = content.Substring(0, descStart).Trim();
                string description = content.Substring(descStart + 1, descEnd - descStart - 1).Trim();
                
                // Check what comes after the description
                string afterDesc = content.Substring(descEnd + 1).Trim();
                
                if (afterDesc.Contains("Currently completed:"))
                {
                    // This is a Checklist goal
                    // Format: " -- Currently completed: X/Y"
                    int completedIndex = afterDesc.IndexOf("Currently completed:");
                    string completedPart = afterDesc.Substring(completedIndex + "Currently completed:".Length).Trim();
                    
                    string[] completedInfo = completedPart.Split('/');
                    if (completedInfo.Length != 2)
                    {
                        Console.WriteLine("DEBUG: Could not parse completed info for checklist");
                        return null;
                    }
                    
                    if (!int.TryParse(completedInfo[0].Trim(), out int amountCompleted) ||
                        !int.TryParse(completedInfo[1].Trim(), out int target))
                    {
                        Console.WriteLine("DEBUG: Could not parse completion numbers for checklist");
                        return null;
                    }
                    
                    Console.WriteLine("WARNING: Checklist goals loaded with default values for points and bonus.");
                    Console.WriteLine("Consider updating the save format to include all goal data.");
                    
                    int defaultPoints = 10;
                    int defaultBonus = 50;
                    
                    Goal checklistGoal = new Checklist(name, description, defaultPoints, target, defaultBonus);
                    
                    // Record the appropriate number of events to restore the completion state
                    for (int i = 0; i < amountCompleted; i++)
                    {
                        checklistGoal.RecordEvent();
                    }
                    
                    Console.WriteLine($"DEBUG: Created Checklist goal '{name}' with {amountCompleted}/{target} completed");
                    return checklistGoal;
                }
                else if (string.IsNullOrEmpty(afterDesc))
                {
                    // This is either a Simple or Eternal goal (both have same format: "[ ] Name (Description)")
                    // Key difference: Simple goals can show [X] when complete, Eternal goals always show [ ]
                    
                    Console.WriteLine("WARNING: Goal loaded with default point values.");
                    Console.WriteLine("Consider updating the save format to include goal type and points.");
                    
                    int defaultPoints = 10;
                    Goal goal;
                    
                    if (isComplete && goalString.StartsWith("[X]"))
                    {
                        // If it shows [X], it must be a completed Simple goal
                        // (Eternal goals never show [X] according to their GetStringRepresentation)
                        goal = new Simple(name, description, defaultPoints);
                        goal.RecordEvent(); // Mark it as completed
                        Console.WriteLine($"DEBUG: Created Simple goal '{name}' (completed)");
                    }
                    else if (goalString.StartsWith("[ ]"))
                    {
                        // This could be either:
                        // 1. An uncompleted Simple goal
                        // 2. An Eternal goal (which always shows [ ])
                        
                        // Since we can't definitively tell from the format alone,
                        // we'll default to Simple goal for now
                        // In a future version, you might want to include goal type in the save format
                        
                        goal = new Simple(name, description, defaultPoints);
                        Console.WriteLine($"DEBUG: Created Simple goal '{name}' (assumed from [ ] format)");
                        Console.WriteLine("NOTE: Could not distinguish between Simple and Eternal goals from save format.");
                    }
                    else
                    {
                        // Fallback case
                        goal = new Simple(name, description, defaultPoints);
                        Console.WriteLine($"DEBUG: Created Simple goal '{name}' (fallback)");
                    }
                    
                    return goal;
                }
                else
                {
                    // Unknown format after description
                    Console.WriteLine($"DEBUG: Unknown format after description: '{afterDesc}'");
                    
                    int defaultPoints = 10;
                    Goal simpleGoal = new Simple(name, description, defaultPoints);
                    
                    if (isComplete)
                    {
                        simpleGoal.RecordEvent();
                    }
                    
                    Console.WriteLine($"DEBUG: Created Simple goal '{name}' (unknown format fallback)");
                    return simpleGoal;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing checkbox format '{goalString}': {ex.Message}");
                return null;
            }
        }
    }
}