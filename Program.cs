using System.Security.Cryptography.X509Certificates;
namespace filehandling1
{


    class addressbook
    {
        string path = "F:\\newFile.cs";

        public void addcontacts(string a, string b, string c)
        {
            string line = $"{a},{b},{c}";

            File.WriteAllText(path, line);
            //using (StreamWriter writer = File.AppendText(path))
            //{
            //    writer.WriteLine(line);
            //}
            Console.WriteLine("added successfully");


            Console.ReadLine();

        }

        public void Editcontact(string m1, string m2)
        {
            string[] lines = File.ReadAllLines(path);
            bool edited = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] s = lines[i].Split(',');
                if (s.Length >= 3 && s[0].Equals(m1) && s[1].Equals(m2))
                {
                    Console.WriteLine("Enter new age:");
                    string newAge = Console.ReadLine();


                    s[2] = newAge;


                    lines[i] = string.Join(",", s);

                    edited = true;
                    Console.WriteLine("Edited successfully");
                    break;
                }
            }

            if (edited)
            {

                File.WriteAllLines(path, lines);
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void deletecontact(string m1, string m2)
        {
            string[] lines = File.ReadAllLines(path);
            bool deleted = false;

            for (int i = 0; i < lines.Length; i++)
            {
                string[] s = lines[i].Split(',');
                if (s.Length >= 2 && s[0].Equals(m1) && s[1].Equals(m2))
                {
                    Console.WriteLine("Deleting contact: " + lines[i]);
                    lines[i] = null;
                    deleted = true;
                    Console.WriteLine("Deleted successfully");
                    break;
                }
            }

            if (deleted)
            {

                File.WriteAllLines(path, lines.Where(line => line != null));
            }
            else
            {
                Console.WriteLine("Contact not found");
            }
        }

        public void displaycontact()
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }



    }


    internal class Program
    {
        static void Main(string[] args)
        {
            addressbook ab = new addressbook();

            while (true)
            {
                Console.WriteLine("choose the option\n1: add contacts\n2: edit contacts\n3: delete contact\n4: display contact\n5. exit");
                int im = int.Parse(Console.ReadLine());

                switch (im)
                {
                    case 1:
                        Console.WriteLine("enter your name");
                        String name = Console.ReadLine();
                        Console.WriteLine("enter your last  name");
                        String L_name = Console.ReadLine();
                        Console.WriteLine("enter your age");
                        String age = Console.ReadLine();

                        ab.addcontacts(name, L_name, age);
                        break;

                    case 2:
                        Console.WriteLine("enter first name to edit");
                        String name1 = Console.ReadLine();
                        Console.WriteLine("enter last name to edit");
                        String name2 = Console.ReadLine();

                        ab.Editcontact(name1, name2);
                        break;
                    case 3:
                        Console.WriteLine("enter first name to delete");
                        String nam1 = Console.ReadLine();
                        Console.WriteLine("enter last name to delete");
                        String nam2 = Console.ReadLine();

                        ab.deletecontact(nam1, nam2);
                        break;
                    case 4:
                        ab.displaycontact();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }






        }
    }

}

