﻿using System.Diagnostics;

namespace ExaminationSysProj
{
    public class Helpers
    {
        public static void Printline(string Patt, int RN)
        {
            int i = 0;
            for (; i < RN; i++)
            {
                Console.Write(Patt);
            }

            Console.WriteLine("");
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            #region CreateQuestions


            #region HTML QuestionList
            //QuestionList HtmlQuestions = new QuestionList("HTML", true);
            //string htmlQ1Body = @"HTML stands for 'Hyper Text Markup Language'";
            //Question htmlQ1 = new TrueOrFalseQuestion(AnswerList.AnswerListTF(true), htmlQ1Body);
            //HtmlQuestions?.Add(htmlQ1);

            //Answer HTMLQ2ans1 = new Answer("head", true);
            //Answer HTMLQ2ans2 = new Answer("h1", false);
            //Answer HTMLQ2ans3 = new Answer("title", false);
            //Answer HTMLQ2ans4 = new Answer("header", false);

            //AnswerList htmlQ2AnsLis = new AnswerList();
            //htmlQ2AnsLis?.Add(HTMLQ2ans1);
            //htmlQ2AnsLis?.Add(HTMLQ2ans2);
            //htmlQ2AnsLis?.Add(HTMLQ2ans3);
            //htmlQ2AnsLis?.Add(HTMLQ2ans4);

            //string htmlQ2Body = @"Which tag is used to define the main heading of an HTML document?";
            //Question htmlQ2 = new ChooseOneQuestion(htmlQ2AnsLis, htmlQ2Body);
            //HtmlQuestions?.Add(htmlQ2);


            //Answer HTMLQ3ans1 = new Answer("h1", false);
            //Answer HTMLQ3ans2 = new Answer("footer", true);
            //Answer HTMLQ3ans3 = new Answer("a", false);
            //Answer HTMLQ3ans4 = new Answer("header", true);

            //AnswerList htmlQ3AnsLis = new AnswerList();
            //htmlQ3AnsLis?.Add(HTMLQ3ans1);
            //htmlQ3AnsLis?.Add(HTMLQ3ans2);
            //htmlQ3AnsLis?.Add(HTMLQ3ans3);
            //htmlQ3AnsLis?.Add(HTMLQ3ans4);

            //string htmlQ3Body = @"What is semantic HTML tags?";
            //Question htmlQ3 = new ChooseMultiQuesion(htmlQ3AnsLis, htmlQ3Body);
            //HtmlQuestions?.Add(htmlQ3);

            #endregion


            #region JSQuesionList Creation

            //QuestionList JSQuestions = new QuestionList("JS", true);
            //string JSQ1Body = "Can't use js in styling elements of HTML?";
            //Question JSQ1 = new TrueOrFalseQuestion(AnswerList.AnswerListTF(false), JSQ1Body);
            //JSQuestions?.Add(JSQ1);

            //Answer JSQ2ans1 = new Answer("getElementsByClassName", false);
            //Answer JSQ2ans2 = new Answer("getElementById", true);
            //Answer JSQ2ans3 = new Answer("getElementsByTagName", false);
            //Answer JSQ2ans4 = new Answer("getElementsByNames", false);

            //AnswerList JSQ2AnsLis = new AnswerList();
            //JSQ2AnsLis?.Add(JSQ2ans1);
            //JSQ2AnsLis?.Add(JSQ2ans2);
            //JSQ2AnsLis?.Add(JSQ2ans3);
            //JSQ2AnsLis?.Add(JSQ2ans4);

            //string JSQ2Body = @"Which selector is more specific ?";
            //Question JSQ2 = new ChooseOneQuestion(htmlQ2AnsLis, JSQ2Body);
            //JSQuestions?.Add(JSQ2);

            #endregion

            #endregion

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Exam.StartExam();

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Console.WriteLine($"You take {elapsedTime} Sec");


        }
    }
}