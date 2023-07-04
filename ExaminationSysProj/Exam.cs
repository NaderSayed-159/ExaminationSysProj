namespace ExaminationSysProj
{
    abstract public class Exam
    {
        byte ExamTime { get; set; }
        int NumberOfQuestions { get; set; }
        Dictionary<int, int> ModelAnswer;
        QuestionList ExamQuestion;


        public Exam(QuestionList _ExamQuesion)
        {
            ExamQuestion = _ExamQuesion;
        }

        protected Dictionary<int, int> CreateModalAnswers(ref Dictionary<int, int> _ModelAnswer)
        {
            for (int i = 0; i < ExamQuestion.Count; i++)
            {
                for (int j = 0; j < ExamQuestion[i].QuestionAnswers.Count; j++)
                {
                    if (ExamQuestion[i].QuestionAnswers[j].isRight)
                    {

                        _ModelAnswer[i + 1] = j;
                        break;
                    }
                }

            }
            return _ModelAnswer;
        }

        public byte _ExamTime { get { return ExamTime; } set { ExamTime = value; } }
        public int _NumberOfQuestions { get { return NumberOfQuestions; } set { NumberOfQuestions = value; } }
        public Dictionary<int, int> _ModelAnswer { get { return ModelAnswer; } set { ModelAnswer = value; } }


        public abstract void ShowExam();
    }


    public class PracticeExam : Exam
    {
        public QuestionList ExamQuestions;
        public PracticeExam(QuestionList _ExamQuestion) : base(_ExamQuestion)
        {
            ExamQuestions = _ExamQuestion;
            _ExamTime = 5;
            _NumberOfQuestions = ExamQuestions.Count;

        }


        public override void ShowExam()
        {
            Console.Write($"Exam Time: {_ExamTime}      ");
            Console.Write($"Questions Number: {ExamQuestions.Count}      ");
            Helpers.Printline("*", 25);
            foreach (Question question in ExamQuestions)
            {
                question.DisplayQuestion();
                Helpers.Printline("*", 25);
            }
            Dictionary<int, int> Manswers = new Dictionary<int, int>();
            _ModelAnswer = CreateModalAnswers(ref Manswers);

            Console.Write("Exam Modal Answer:");
            Console.WriteLine("       #");
            Helpers.Printline("#", 25);

            for (int i = 1; i <= ExamQuestions.Count; i++)
            {
                Console.WriteLine(ExamQuestions[i - 1].Body);
                Console.WriteLine($"Right Answer: {ExamQuestions[i - 1].QuestionAnswers[_ModelAnswer[i]].body}");
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
            _ExamTime = 10;
            _NumberOfQuestions = _ExamQuestion.Count;

        }

        public override void ShowExam()
        {
            Console.Write($"Exam Time: {_ExamTime}      ");
            Console.Write($"Questions Number: {ExamQuestions.Count}      ");
            Helpers.Printline("*", 25);

            foreach (Question question in ExamQuestions)
            {
                question.DisplayQuestion();
                Helpers.Printline("*", 25);
            }
        }
    }


}