using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

class Videos
{
    private string _title;
    private string _author;
    private int _lengthInSeconds;
    private List<Comments> _comments;

    public Videos(string title, string author, int lengthInSeconds, Comments text)
    {
        _title = title;
        _author = author;
        _lengthInSeconds = lengthInSeconds;
        _comments = new List<Comments>();
        _comments.Add(text);


    }
    //Gets the number of comments from the _comments list
    public int GetTheNumberOfComments()
    {
        int numberOfComments = _comments.Count;

        return numberOfComments;
    }

    //Adds comments to existing videos
    public void AddComment(Comments text)
    {
        _comments.Add(text);
    }
    public string GetTitle()
    {
        return _title;
    }
    public string GetAuthor()
    {
        return _author;
    }
    public int GetLengthInSeconds()
    {
        return _lengthInSeconds;
    }
    public void GetTheComments()
    {

       
            for (int i = 0; i < _comments.Count; i++)
            {
            Comments c = _comments[i];
                Console.WriteLine($"{i + 1} {c.GetText()}");
            }

        }
    }   
