using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {


        //object 1.1 First Comment = comment1 (sets the 1st comment name and text strings)

        Comments v1c1 = new Comments("Joshua Wright", "Here's my first video on Coding With Classes. Be sure to subscibe and share to get the word out. Also be sure to leave a comment about the video. Was it helpful, too long, or just right.");

        //Object 1.2 Second Comment = comment2 (sets the 2nd comment name and text strings)

        Comments v1c2 = new Comments("Jack Coder", "Great Content! just the right length");

        //object 1.3 3rd Comment = comment3 (sets the 3rd comment name and text strings)

        Comments v1c3 = new Comments("Patricia Python", "This was definitely a helpful video as I'm currently learning classes and struggling a little. This definitely helped.");

        //Object 1, 1st video. Sets the Title, author, lenth of video and first comment.

        Videos v1 = new Videos("Working With Classes", "Joshua Wright", 900, v1c1);
        v1.AddComment(v1c2);
        v1.AddComment(v1c3);

        //Object 2.1, 1st comment = v2c1 (sets the 1st comment name and text)

        Comments v2c1 = new Comments("Joshua Wright", "Here's my newest video on Creating Dictionaries with Python. Dictionaries are an essential tool when writing code in python. Be sure to subscibe and share to get the word out. Also be sure to leave a comment about the video. Was it helpful, too long, or just right.");

        //Object 2.2, 2nd comment = v2c2 (sets the 2nd comment name and text)
        Comments v2c2 = new Comments("Jack Coder", "Really liking the content you're putting out! Great detail and super helpful.");

        //Object 2.3, 3rd comment = v2c3 (sets the 3rd comment name and text)
        Comments v2c3 = new Comments("Patricia Python", "Great content! This is really helpful for those new to coding. Really helped me to understand the concept better.");

        //Object 2, 2nd Video(Sets the Title, authorm lenth of video and first comment)
        Videos v2 = new Videos("Creating Dictionaries with Python", "Joshua Wright", 1200, v2c1);
        v2.AddComment(v2c2);
        v2.AddComment(v2c3);

        //Object 3.1, 1st Comment = v3c1
        Comments v3c1 = new Comments("Joshua Wright", "Latest video on JavaScript and Creating a Dynamic Website. This why JS is key in creating a functional user friendly website.");

        //Object 3.2, 2nd Comment = v3c2
        Comments v3c2 = new Comments("Jack Coder", "Great content as usual! I love web design and development over all. This is great tutorial on JS and why it's important in web development.");

        //Object 3.3, 3rd Comment = v3c3
        Comments v3c3 = new Comments("Patricia Python", "Ok... Loving this content! Not only great for newer developers, but just great for everyone!");

        //Object 3, 3rd video = v3
        Videos v3 = new Videos("JavaScript and Creating a Dynamic Website", "Joshua Wright", 1200, v3c1);
        v3.AddComment(v3c2);
        v3.AddComment(v3c3);

        List<Videos> videos;
        videos = new List<Videos>();
        videos.Add(v1);
        videos.Add(v2);
        videos.Add(v3);
        foreach (Videos video in videos)
        {
            Console.WriteLine("------------------------");
            Console.WriteLine($"Title: {video.GetTitle()}");
            Console.WriteLine($"Author: {video.GetAuthor()}");
            Console.WriteLine($"Length: {video.GetLengthInSeconds()}");
            Console.WriteLine($"Number of Comments: {video.GetTheNumberOfComments()}");
            Console.WriteLine("Comments:");
            video.GetTheComments();
            Console.WriteLine();
        }



        
        
        
    }
}