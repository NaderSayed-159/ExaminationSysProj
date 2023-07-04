﻿using System.IO;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ExaminationSysProj
{
    abstract public class Question
    {
        public AnswerList QuestionAnswers { get; set; }
        public string Body { get; set; }
        public string header { get; set; }
        public int marks { get; set; }

        [JsonConstructor]
        public Question(AnswerList _QuestionAnswers, string _Body, string _header, int _marks)
        {
            Body = _Body;
            header = _header;
            marks = _marks;

            QuestionAnswers = _QuestionAnswers;
        }


        public abstract int DisplayQuestion();

    }

    public class QuestionList : List<Question>
    {
        readonly string listName;
        readonly bool ListForExam;
        bool addBehaviour;

        public QuestionList(string _listName, bool _addBehaviour)
        {
            listName = _listName;
            addBehaviour = _addBehaviour;
        }
        public QuestionList(bool _addBehaviour)
        {
            addBehaviour = _addBehaviour;
        }

        public new void Add(Question question)
        {
            base.Add(question);

            if (addBehaviour)
            {
                LogQ(question);
            }



        }

        public void LogQ(Question quesion)
        {
            string path;

            var isExist = Directory.Exists("SubjList");
            if (!isExist)
            {
                path = Directory.CreateDirectory("SubjList").FullName;
            }
            else
            {
                path = new DirectoryInfo("SubjList").FullName;
            }

            string JsonFromQuesion = JsonSerializer.Serialize(quesion, new JsonSerializerOptions
            {
                IncludeFields = false
            });

            try
            {

                if (quesion.GetType().Name == "TrueOrFalseQuestion")
                {
                    File.AppendAllText(@$"{path}\{listName}.txt", "tf" + Environment.NewLine);

                }
                else
                {
                    File.AppendAllText(@$"{path}\{listName}.txt", "chooseone" + Environment.NewLine);

                }

                File.AppendAllText(@$"{path}\{listName}.txt", JsonFromQuesion + Environment.NewLine);

            }
            catch (Exception)
            {
                Console.WriteLine(@"Can't log question");
            }

        }

    }

    public class TrueOrFalseQuestion : Question
    {
        bool TorF;

        public TrueOrFalseQuestion(AnswerList TFQuestionAnswers, bool _TorF, string Body, string header = "True Or False", int marks = 5) : base(TFQuestionAnswers, Body, header, marks)
        {
            TorF = _TorF;
            QuestionAnswers = TFQuestionAnswers;
        }
        [JsonConstructor]
        public TrueOrFalseQuestion(AnswerList QuestionAnswers, string Body, string header = "True Or False", int marks = 5) : base(QuestionAnswers, Body, header, marks)
        {
            this.QuestionAnswers = QuestionAnswers;
            this.Body = Body;
        }

        public override int DisplayQuestion()
        {
            Console.Write(header);
            Console.WriteLine($"    Marks : {marks}");
            Console.WriteLine(Body);
            Console.WriteLine("1 - True");
            Console.WriteLine("2 - False");
            int x;
            do
            {

                Console.Write("Your Answer : ");
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    continue;
                }

            } while (x < 0 || x >= 2);

            return x;

        }



    }

    public class ChooseOneQuestion : Question
    {
        [JsonConstructor]
        public ChooseOneQuestion(AnswerList QuestionAnswers, string Body, string header = "Choose One", int marks = 10) : base(QuestionAnswers, Body, header, marks)
        {
            this.QuestionAnswers = QuestionAnswers;
        }



        public override int DisplayQuestion()
        {
            Console.Write(header);
            Console.WriteLine($"    Marks : {marks}");
            Console.WriteLine(Body);
            int counter = 1;
            foreach (Answer answer in QuestionAnswers)
            {
                Console.WriteLine($"{counter} - {answer.body}");
                counter++;
            }
            int x;
            do
            {

                Console.Write("Your Answer : ");
                if (!int.TryParse(Console.ReadLine(), out x))
                {
                    continue;
                }

            } while (x < 0 || x >= 4);

            return x;



        }

    }



}