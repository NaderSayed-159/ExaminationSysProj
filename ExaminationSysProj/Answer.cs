namespace ExaminationSysProj
{
    public class Answer
    {
        public string body { get; set; }
        public bool isRight { get; set; }



        public Answer(string body, bool isRight)
        {
            this.body = body;
            this.isRight = isRight;
        }


    }

    public class AnswerList : List<Answer>
    {
        public static AnswerList AnswerListTF(bool rightanswer)
        {
            AnswerList Qanswers = new AnswerList();

            if (rightanswer)
            {
                Answer answer1 = new Answer("True", true);
                Answer answer2 = new Answer("false", false);
                Qanswers.Add(answer1);
                Qanswers.Add(answer2);
            }
            else
            {
                Answer answer1 = new Answer("True", false);
                Answer answer2 = new Answer("false", true);
                Qanswers.Add(answer1);
                Qanswers.Add(answer2);
            }

            return Qanswers;
        }

    }
}