using System;
using System.Text.RegularExpressions;

namespace AoC2020ClassLibrary
{
    public class Passport
    {
        private string byr = "";
        private string iyr = "";
        private string eyr = "";
        private string hgt = "";
        private string hcl = "";
        private string ecl = "";
        private string pid = "";
        private string cid = "";

        private string[] eclValues = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

        public Passport()
        {
        }

        private int ValueToInteger(string number)
        {
            try
            {
                return int.Parse(number);
            }
            catch
            {
                return -1;
            }
        }

        public string BirthYear
        {
            get
            {
                return byr;
            }
            set
            {
                byr = value;
            }
        }

        public string IssueYear
        {
            get
            {
                return iyr;
            }
            set
            {
                iyr = value;
            }
        }

        public string ExpirationYear
        {
            get
            {
                return eyr;
            }
            set
            {
                eyr = value;
            }
        }

        public string Height
        {
            get
            {
                return hgt;
            }
            set
            {
                hgt = value;
            }
        }

        public string HairColor
        {
            get
            {
                return hcl;
            }
            set
            {
                hcl = value;
            }
        }

        public string EyeColor
        {
            get
            {
                return ecl;
            }
            set
            {
                ecl = value;
            }
        }

        public string PassportID
        {
            get
            {
                return pid;
            }
            set
            {
                pid = value;
            }
        }

        public string CountryID
        {
            get
            {
                return cid;
            }
            set
            {
                cid = value;
            }
        }

        public bool RequiredFieldsPresent
        {
            get
            {
                return byr.Length > 0
                    && iyr.Length > 0
                    && eyr.Length > 0
                    && hgt.Length > 0
                    && hcl.Length > 0
                    && ecl.Length > 0
                    && pid.Length > 0;
            }
        }

        public bool IsValid
        {
            get
            {
                int bYr = ValueToInteger(byr);
                if (bYr < 1920 || bYr > 2002)
                {
                    return false;
                }

                int iYr = ValueToInteger(iyr);
                if (iYr < 2010 || iYr > 2020)
                {
                    return false;
                }

                int eYr = ValueToInteger(eyr);
                if (eYr < 2020 || eYr > 2030)
                {
                    return false;
                }

                if (hgt.Length > 2)
                {
                    string heightUnit = hgt.Substring(hgt.Length - 2);
                    int heightVal = ValueToInteger(hgt.Substring(0, hgt.Length - 2));
                    switch (heightUnit)
                    {
                        case "cm":
                            if (heightVal < 150 || heightVal > 193)
                            {
                                return false;
                            }
                            break;
                        case "in":
                            if (heightVal < 59 || heightVal > 76)
                            {
                                return false;
                            }
                            break;
                        default:
                            return false;
                    }
                }
                else
                {
                    return false;
                }

                if (Regex.Match(hcl, @"#[a-f0-9]{6}").Success == false)
                {
                    return false;
                }

                if (Array.Exists(eclValues, element => element.Equals(ecl)) == false)
                {
                    return false;
                }

                int passportID = ValueToInteger(pid);
                if (pid.Length != 9 || passportID < 0)
                {
                    return false;
                }

                return true;
            }
        }

        public override string ToString()
        {
            return String.Format(
                "byr:{0} iyr:{1} eyr:{2} hgt:{3} hcl:{4} ecl:{5} pid:{6} cid:{7}",
                byr, iyr, eyr, hgt, hcl, ecl, pid, cid
            );
        }

        public static Passport FromString(string input)
        {
            Regex re = new Regex(@"([a-z]{3}):([#a-z0-9]+)");

            Passport pass = new Passport();

            MatchCollection matches = re.Matches(input);

            string val;

            foreach (Match match in matches)
            {
                val = match.Groups[2].Value;

                switch (match.Groups[1].Value)
                {
                    case "byr":
                        pass.BirthYear = val;
                        break;
                    case "iyr":
                        pass.IssueYear = val;
                        break;
                    case "eyr":
                        pass.ExpirationYear = val;
                        break;
                    case "hgt":
                        pass.Height = val;
                        break;
                    case "hcl":
                        pass.HairColor = val;
                        break;
                    case "ecl":
                        pass.EyeColor = val;
                        break;
                    case "pid":
                        pass.PassportID = val;
                        break;
                    case "cid":
                        pass.CountryID = val;
                        break;
                }
            }

            return pass;
        }
    }
}
