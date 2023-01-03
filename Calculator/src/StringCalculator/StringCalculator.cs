namespace src
{
    public class StringCalculator
    {        
        public char[] delimiterChars = { ',', '\n',';','*'};
        public int Add(string input)
        {
            if(string.IsNullOrEmpty(input))
                return 0;

            string st = ignoreFirstChar(input);//if first char is a delimiter

            string s = checkSlashChar(st);//format: "//{delimiter}\n{nombres}"

            string [] str = string.IsNullOrEmpty(s) ?
                        st.Split(delimiterChars)
                        :
                        s.Split(delimiterChars);//Array of charactères depending on s & st

            List<int> numbers = convertToInt(str);//liste of integers

            List<int> negatifsNbs= negatifsNumbers(numbers);//liste of negatifs integers

            if(negatifsNbs.Count()>0)
                throw new Exception($"Les nombres négatifs ne sont pas autorisés:{exceptionMessage(negatifsNbs)}");

            return sumNumbers(numbers);//sum of numbers
        }

        public List<int> convertToInt(string[] str)
        {
            List<int> numbers = new List<int>();
            int nb;

            foreach(string st in str)
            {
                bool res = int.TryParse(st, out nb);
                if(!res)
                    throw new Exception($"{nb} is not an integer in the string {str}");

                numbers.Add(nb);
            }

            return numbers;
        }
        public List<int> negatifsNumbers(List<int> nbs)
        {
            List<int> numbers = new List<int>();

            foreach(int nb in nbs)
            {
                if(nb<0)
                {
                    numbers.Add(nb);
                }
            }

            return numbers;
        }

        public int sumNumbers(List<int> nbs)
        {
            int sum =0;
            foreach(int nb in nbs)
            {
                if(nb>1000)
                    continue;
                sum+=nb;
            }
            return sum;
        }

        public string exceptionMessage(List<int> nbs)
        {
            string str = string.Empty;

            foreach(int nb in nbs)
            {
                str+=nb+",";
            }

            return str;
        }

        public string checkSlashChar(string str)
        {
            string strWithSlash = string.Empty;
            string strWithoutSlash = string.Empty;
            string strWithDelimiteur = string.Empty;
            string strWithSlashN = string.Empty;


            if(str.Length > 4)
            {
                strWithSlash = str.Substring(0,2);
                strWithDelimiteur = str.Substring(2,1);
                strWithSlashN = str.Substring(3,1);

                if(strWithSlash == "//" && checkDelimiterInString(strWithDelimiteur) && strWithSlashN == "\n")
                    strWithoutSlash = str.Substring(4,str.Length -4);
            }
            

            return strWithoutSlash;
        }

        public bool checkDelimiterInString(string str)
        {
            foreach(char c in delimiterChars)
            {
                if(c.ToString()==str)
                    return true;
            }
            return false;
        }

        public string ignoreFirstChar(string str)
        {
            foreach(char c in delimiterChars)
            {
                if(c.ToString() == str.Substring(0,1))
                    return str.Substring(1,str.Length-1);
            }
            return str;
        }
    }
}