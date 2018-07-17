using LastSliceUWP.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Newtonsoft.Json;
using System.Linq;
using System.Diagnostics;

namespace LastSliceUWP
{
    public sealed partial class MainPage : Page
    {
        private ChallengeService challengeService = new ChallengeService();

        public MainPage()
        {
            InitializeComponent();
            ShowUserCache();
           // GetDiagonals();
        }

        private void ShowUserCache()
        {
            bool userHasLoggedIn = challengeService.HasUserLoggedIn();

            if (userHasLoggedIn)
            {
                currentUserText.Text = "Cached User in Storage";
            }
            else
            {
                currentUserText.Text = "No Cached User";
            }
        }

        private void btnClearUserCacheClick(object sender, RoutedEventArgs e)
        {
            challengeService.ClearUserCache();
            ShowUserCache();
        }

        public struct Words
        {
            public string word;
            public int x;
            public int y;
            public string direction;
        }
        public struct Solution
        {
            public List<Words> Words;
            public string PuzzleId;
            public string Initials;
        }

        public void GetDiagonals()
        {
            List<string> lines = new List<string>();
            lines.Add("PIAVP");
            lines.Add("ECSSL");
            lines.Add("PHKMO");
            lines.Add("SOSGA");
            lines.Add("PKJPN");
            lines.Add("EESMOORHSUMGUTASEEPL");
            lines.Add("AJHRVOTJPMAHSRORCPPG");
            lines.Add("CCDAMTPKNVEGAAMVSPVN");
            lines.Add("MTGTJONCOIDCGARDCEVC");
            lines.Add("AMOLANJCISOIEVDHIRLT");
            lines.Add("HMCDL");
            lines.Add("MDHNA");
            lines.Add("ONIVP");
            lines.Add("NKPNE");
            lines.Add("KKKVN");
            List<string> toCheck = new List<string>();
            string s = lines[5] + lines[5];
            char[] sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = "" + lines[0][0] + lines[1][1] + lines[2][2] + lines[3][3] + lines[4][4] + lines[10][4] + lines[11][3] + lines[12][2] + lines[13][1] + lines[14][0];
            s = s + s;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = "" + lines[0][4] + lines[1][3] + lines[2][2] + lines[3][1] + lines[4][0] + lines[10][0] + lines[11][1] + lines[12][2] + lines[13][3] + lines[14][4];
            s = s + s;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = "" + lines[5][9] + lines[6][8] + lines[7][7] + lines[8][6] + lines[9][5] + lines[10][0] + lines[11][1] + lines[12][2] + lines[13][3] + lines[14][4];
            s = s + s;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = lines[6] + lines[6];
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = lines[7] + lines[7];
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = lines[8] + lines[8];
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = lines[9] + lines[9];
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            string one = "";
            string two = "";
            string three = "";
            string four = "";
            string five = "";
            for (int i = 0; i < 15; i++)
            {
                one += lines[i][0];
                two += lines[i][1];
                three += lines[i][2];
                four += lines[i][3];
                five += lines[i][4];
            }
            five += lines[9][10];
            five += lines[8][10];
            five += lines[7][10];
            five += lines[6][10];
            five += lines[5][10];
            four += lines[9][11];
            four += lines[8][11];
            four += lines[7][11];
            four += lines[6][11];
            four += lines[5][11];
            three += lines[9][12];
            three += lines[8][12];
            three += lines[7][12];
            three += lines[6][12];
            three += lines[5][12];
            two += lines[9][13];
            two += lines[8][13];
            two += lines[7][13];
            two += lines[6][13];
            two += lines[5][13];
            one += lines[9][14];
            one += lines[8][14];
            one += lines[7][14];
            one += lines[6][14];
            one += lines[5][14];
            s = one + one;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = two + two;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = three + three;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = four + four;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));
            s = five + five;
            sr = s.ToCharArray();
            Array.Reverse(sr);
            toCheck.Add(s);
            toCheck.Add(new string(sr));

            List<string> solutions = new List<string>();
        }

        private async void btnChallenge2Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ResultText.Text = "\"Did I stutter? Because that's not the pizza I ordered.\"";
                while (ResultText.Text.Contains("not the pizza"))
                {
                    string token = await challengeService.Login();

                    if (!string.IsNullOrEmpty(token))
                    {
                        string puzzle = await challengeService.GetPuzzle();
                        string[] split = puzzle.Split('{');
                        string[] split2 = split[2].Split('[');
                        string[] split3 = split2[1].Split(',');
                        for (int i = 0; i < split3.Length; i++)
                        {
                            split3[i] = split3[i].Replace("\"", "").Replace("\"", "").Replace("]", "").Replace("}", "").Replace("\"", "");
                        }
                        string idString = split3[15].Split(':')[1];
                        List<string> toppings = new List<string>();
                        toppings.Add("ANCHOVY");
                        toppings.Add("ARTICHOKE");
                        toppings.Add("PECAN");
                        toppings.Add("BACON");
                        toppings.Add("CHEESE");
                        //toppings.Add("FIRE");
                        //toppings.Add("FROG");
                        toppings.Add("GARLIC");
                        toppings.Add("GREENPEPPER");
                        toppings.Add("HABANERO");
                        toppings.Add("AVOCADO");
                        toppings.Add("JALAPENO");
                        toppings.Add("MUSHROOMS");
                        //toppings.Add("SOAP");
                        toppings.Add("OLIVE");
                        toppings.Add("ONION");
                        toppings.Add("MEATBALLS");
                        toppings.Add("TUNA");
                        toppings.Add("PROVOLONE");
                        toppings.Add("PINEAPPLE");
                        toppings.Add("PEPPERONI");
                        toppings.Add("SAUSAGE");
                        //toppings.Add("CARDBOARDBOX");
                        //toppings.Add("CUBE");
                        //toppings.Add("GAS");
                        //toppings.Add("HEART");
                        toppings.Add("CHICKEN");
                        toppings.Add("SHRIMP");
                        toppings.Add("PARMESAN");
                        //toppings.Add("RECYCLEBIN");
                        toppings.Add("PEANUTBUTTER");
                        toppings.Add("MOZZARELLA");
                        //toppings.Add("PAPERBOY");
                        List<string> lines = split3.ToList();
                        lines.RemoveAt(16);
                        lines.RemoveAt(15);
                        List<string> toCheck = new List<string>();
                        List<Words> solutions = new List<Words>();
                        string s = lines[5] + lines[5];
                        char[] sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = s.IndexOf(toppings[j]);
                                w.y = 5;
                                w.direction = "EAST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.y = 5;
                                w.direction = "WEST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = lines[6] + lines[6];
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = s.IndexOf(toppings[j]);
                                w.y = 6;
                                w.direction = "EAST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.y = 6;
                                w.direction = "WEST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = lines[7] + lines[7];
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = s.IndexOf(toppings[j]);
                                w.y = 7;
                                w.direction = "EAST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.y = 7;
                                w.direction = "WEST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = lines[8] + lines[8];
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = s.IndexOf(toppings[j]);
                                w.y = 8;
                                w.direction = "EAST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.y = 8;
                                w.direction = "WEST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = lines[9] + lines[9];
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = s.IndexOf(toppings[j]);
                                w.y = 9;
                                w.direction = "EAST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.y = 9;
                                w.direction = "WEST";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        string one = "";
                        string two = "";
                        string three = "";
                        string four = "";
                        string five = "";
                        for (int i = 0; i < 15; i++)
                        {
                            one += lines[i][0];
                            two += lines[i][1];
                            three += lines[i][2];
                            four += lines[i][3];
                            five += lines[i][4];
                        }
                        five += lines[9][10];
                        five += lines[8][10];
                        five += lines[7][10];
                        five += lines[6][10];
                        five += lines[5][10];
                        four += lines[9][11];
                        four += lines[8][11];
                        four += lines[7][11];
                        four += lines[6][11];
                        four += lines[5][11];
                        three += lines[9][12];
                        three += lines[8][12];
                        three += lines[7][12];
                        three += lines[6][12];
                        three += lines[5][12];
                        two += lines[9][13];
                        two += lines[8][13];
                        two += lines[7][13];
                        two += lines[6][13];
                        two += lines[5][13];
                        one += lines[9][14];
                        one += lines[8][14];
                        one += lines[7][14];
                        one += lines[6][14];
                        one += lines[5][14];
                        s = one + one;
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 0;
                                w.y = s.IndexOf(toppings[j]);
                                w.direction = "SOUTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 0;
                                w.y = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.direction = "NORTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = two + two;
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 1;
                                w.y = s.IndexOf(toppings[j]);
                                w.direction = "SOUTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 1;
                                w.y = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.direction = "NORTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = three + three;
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 2;
                                w.y = s.IndexOf(toppings[j]);
                                w.direction = "SOUTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 2;
                                w.y = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.direction = "NORTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = four + four;
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 3;
                                w.y = s.IndexOf(toppings[j]);
                                w.direction = "SOUTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 3;
                                w.y = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.direction = "NORTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        s = five + five;
                        sr = s.ToCharArray();
                        Array.Reverse(sr);
                        toCheck.Add(s);
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (s.Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 4;
                                w.y = s.IndexOf(toppings[j]);
                                w.direction = "SOUTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        toCheck.Add(new string(sr));
                        for (int j = 0; j < toppings.Count; j++)
                        {
                            if (toCheck[toCheck.Count - 1].Contains(toppings[j]))
                            {
                                Words w = new Words();
                                w.x = 4;
                                w.y = toCheck.Count - toCheck[toCheck.Count - 1].IndexOf(toppings[j]);
                                w.direction = "NORTH";
                                w.word = toppings[j];
                                solutions.Add(w);
                                Debug.WriteLine(toppings[j]);
                            }
                        }
                        Solution sol = new Solution();
                        sol.Initials = "SJK";
                        sol.PuzzleId = idString;
                        sol.Words = solutions;
                        string solution = JsonConvert.SerializeObject(sol);
                        string solutionResponse = await challengeService.PostSolutionToPuzzle(solution);

                        ResultText.Text = solutionResponse;
                    }

                    // TODO: Check the solution response to see if you got the correct solution
                }
            }
            catch (Exception ex)
            {
                string exceptionDetails = ex.ToString();
                ShowException(exceptionDetails);
            }

            ShowUserCache();
        }

        private async void ShowException(string message)
        {
            MessageDialog dialog = new MessageDialog(message, "Sorry, an error occurred.");
            await dialog.ShowAsync();
        }
    }
}
