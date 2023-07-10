namespace ExaminationSysProj
{
    abstract public class Exam
    {
        public byte ExamTime { get; set; }
        public int NumberOfQuestions { get; set; }
        public Dictionary<int, List<int>> ModelAnswer;
        QuestionList ExamQuestion;
        public List<List<int>> StudentAnswers;

        public Exam(QuestionList _ExamQuesion)
        {
            ExamQuestion = _ExamQuesion;
        }

        protected Dictionary<int, List<int>> CreateModalAnswers()
        {
            Dictionary<int, List<int>> BlockModelAnswer = new Dictionary<int, List<int>>();
            for (int i = 0; i < ExamQuestion.Count; i++)
            {
                List<int> RightAnswers = new List<int>();
                for (int j = 0; j < ExamQuestion[i].QuestionAnswers.Count; j++)
                {
                    if (ExamQuestion[i].QuestionAnswers[j].isRight)
                    {
                        RightAnswers.Add(j + 1);

                    }
                }
                BlockModelAnswer[i + 1] = RightAnswers;

            }
            return BlockModelAnswer;
        }

        public abstract void ShowExam();
        public static void StartExam()
        {
            Subject ExamSubj;

            ExamSubj = Subject.ChooseSubj();

            if (ExamSubj != null)
            {
                ExamSubj.GenerateExamForSubj();

                Helpers.Printline("+", 25);
                Console.WriteLine($"Exam of {ExamSubj.SubjectTitle.ToUpper()}");
                Helpers.Printline("+", 25);

                ExamSubj.SubjExam.ShowExam();

                ExamSubj.SubjExam.CorrectExam();

            }


        }

        public void CorrectExam()
        {
            int StudentMarks = 0;
            int TotalMarks = 0;
            for (int j = 1; j <= ExamQuestion.Count; j++)
            {
                TotalMarks += ExamQuestion[j - 1].marks;

                if (StudentAnswers[j - 1].Count > 1)
                {
                    StudentAnswers[j - 1].Sort();
                }

                if (StudentAnswers[j - 1].SequenceEqual(ModelAnswer[j]))
                {
                    StudentMarks += ExamQuestion[j - 1].marks;
                }



            }
            Helpers.Printline("#", 30);

            Console.Write($"You got {StudentMarks} / {TotalMarks}");
            Console.WriteLine("              #");
            Helpers.Printline("#", 30);



        }
    }


    public class PracticeExam : Exam
    {
        public QuestionList ExamQuestions;
        public PracticeExam(QuestionList _ExamQuestion) : base(_ExamQuestion)
        {
            ExamQuestions = _ExamQuestion;
            ExamTime = 5;
            NumberOfQuestions = ExamQuestions.Count;

        }


        public override void ShowExam()
        {
            ModelAnswer = CreateModalAnswers();
            Console.Write($"Exam Time: {ExamTime}      ");
            Console.WriteLine($"Questions Number: {ExamQuestions.Count}      ");
            Helpers.Printline("*", 25);
            StudentAnswers = new List<List<int>>();
            foreach (Question question in ExamQuestions)
            {
                List<int> StAnswer = question.DisplayQuestion();
                StudentAnswers.Add(StAnswer);
                Helpers.Printline("*", 25);
            }

            Helpers.Printline("#", 25);
            Console.Write("Exam Modal Answer:");
            Console.WriteLine("       #");
            Helpers.Printline("#", 25);

            for (int i = 1; i <= ExamQuestions.Count; i++)
            {
                Console.WriteLine(ExamQuestions[i - 1].Body);
                foreach (int rightAnswer in ModelAnswer[i])
                {
                    Console.WriteLine($"Right Answer: {ExamQuestions[i - 1].QuestionAnswers[rightAnswer - 1].body}");
                }
                Helpers.Printline("*", 25);
            }
        }
    }


    public class FinalExam : Exam
    {
        QuestionList ExamQuestions;
        public FinalExam(QuestionList _ExamQuestion) : base(_ExamQuestion)
        {
            ExamQuestions = _ExamQuestion;
            ExamTime = 10;
            NumberOfQuestions = _ExamQuestion.Count;

        }

        public override void ShowExam()
        {
            ModelAnswer = CreateModalAnswers();
            Console.Write($"Exam Time: {ExamTime}      ");
            Console.WriteLine($"Questions Number: {ExamQuestions.Count}      ");
            Helpers.Printline("*", 25);

            StudentAnswers = new List<List<int>>();
            foreach (Question question in ExamQuestions)
            {
                List<int> StAnswer = question.DisplayQuestion();
                StudentAnswers.Add(StAnswer);
                Helpers.Printline("*", 25);
            }
        }


    }

    public class QuizExam : Exam
    {
        QuestionList ExamQuestions;
        public QuizExam(QuestionList _ExamQuestion) : base(_ExamQuestion)
        {
            ExamQuestions = _ExamQuestion;
            ExamTime = 10;
            NumberOfQuestions = _ExamQuestion.Count;

        }
        public override void ShowExam()
        {
            ModelAnswer = CreateModalAnswers();
            Console.Write($"Exam Time: {ExamTime}      ");
            Console.WriteLine($"Questions Number: {ExamQuestions.Count}      ");
            Helpers.Printline("*", 25);

            StudentAnswers = new List<List<int>>();
            foreach (Question question in ExamQuestions)
            {
                List<int> StAnswer = question.DisplayQuestion();
                StudentAnswers.Add(StAnswer);
                Helpers.Printline("*", 25);
            }
        }
    }
}