using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets
{
    public class Question
    {
        private int id;
        private int fisrtNumber;
        private int secondNumber;
        private int rightAnswer;
        private int wrongAnswer1;
        private int wrongAnswer2;
        private int wrongAnswer3;
        private int level;
        private int priority;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public int FisrtNumber
        {
            get
            {
                return fisrtNumber;
            }

            set
            {
                fisrtNumber = value;
            }
        }

        public int SecondNumber
        {
            get
            {
                return secondNumber;
            }

            set
            {
                secondNumber = value;
            }
        }

        public int WrongAnswer1
        {
            get
            {
                return wrongAnswer1;
            }

            set
            {
                wrongAnswer1 = value;
            }
        }

        public int WrongAnswer2
        {
            get
            {
                return wrongAnswer2;
            }

            set
            {
                wrongAnswer2 = value;
            }
        }

        public int WrongAnswer3
        {
            get
            {
                return wrongAnswer3;
            }

            set
            {
                wrongAnswer3 = value;
            }
        }

        public int Level
        {
            get
            {
                return level;
            }

            set
            {
                level = value;
            }
        }

        public int Priority
        {
            get
            {
                return priority;
            }

            set
            {
                priority = value;
            }
        }

        public int RightAnswer
        {
            get
            {
                return rightAnswer;
            }

            set
            {
                rightAnswer = value;
            }
        }
    }
}
