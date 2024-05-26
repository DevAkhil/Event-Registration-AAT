using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Threading.ConsoleApplication
{
    internal class Program
    {
        static List<int> globalList = new List<int>();
        static object lockObject = new object();
        static bool evenThreadStarted = false;
        static int startThrirdThreadAt = 250000;
        static int stopAllThreadsAt = 1000000;
        static Thread oddNumberThread = new Thread(GenerateOddNumbers);
        static Thread primeNumberThread = new Thread(GenerateNegativePrimeNumbers);
        static Thread evenNumberThread = new Thread(GenerateEvenNumbers);
        static void Main(string[] args)
        {
            oddNumberThread.Start();
            primeNumberThread.Start();


            oddNumberThread.Join();
            primeNumberThread.Join();
            lock (lockObject)
            {
                globalList.Sort();
                int oddCount = globalList.Count(x => x % 2 != 0);
                int evenCount = globalList.Count(x => x % 2 == 0);

                Console.WriteLine($"Odd numbers count: {oddCount}");
                Console.WriteLine($"Even numbers count: {evenCount}");
                SerializeToBinary(Path.Combine(Directory.GetCurrentDirectory() + @"/BinaryOutput.bin"), globalList);
                SerializeToXml(Path.Combine(Directory.GetCurrentDirectory() + @"/XMLOutput.xml"), globalList);

            }



        }
        static void GenerateOddNumbers()
        {
            while (true)
            {
                Random random = new Random();
                int randomNumber = random.Next();
                while (randomNumber % 2 == 0)
                {
                    randomNumber = random.Next();
                }
                if (!AddToGlobalList(randomNumber))
                {
                    break;
                }

            }

        }

        static void GenerateEvenNumbers()
        {
            Random random = new Random();
            while (true)
            {
                int number = random.Next(1, int.MaxValue / 2) * 2;
                if (!AddToGlobalList(number))
                {
                    break;
                }
            }
        }
        //https://stackoverflow.com/questions/17579091/faster-way-to-check-if-a-number-is-a-prime
        static bool IsPrime(int number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;
            int boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
            {
                if (number % i == 0) return false;
            }

            return true;
        }

        static void GenerateNegativePrimeNumbers()
        {
            int number = 2;
            while (true)
            {
                if (IsPrime(number))
                {
                    if (!AddToGlobalList(-number))
                    {
                        break;

                    }
                }
                number++;

            }



        }






        static bool AddToGlobalList(int number)
        {
            lock (lockObject)
            {
                if (globalList.Count == startThrirdThreadAt && !evenThreadStarted)
                {
                    evenNumberThread.Start();
                    evenThreadStarted = true;
                }
                if (globalList.Count == stopAllThreadsAt)
                {
                    return false;
                }
                globalList.Add(number);
                return true;


            }
        }

        //https://www.c-sharpcorner.com/UploadFile/mahesh/create-a-binary-file-in-C-Sharp/
        static void SerializeToBinary(string fileName, List<int> list)
        {
            using (BinaryWriter bw = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                foreach (int x in list)
                {
                    bw.Write(x);
                }

            }
        }

        //https://www.youtube.com/watch?v=zAn-ZbJqS90
        static void SerializeToXml(string fileName, List<int> list)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<int>));
                serializer.Serialize(fs, list);
            }
        }
    }
}
