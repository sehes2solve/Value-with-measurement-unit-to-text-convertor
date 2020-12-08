using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Value_and_Unit_Text_Converter
{
    class Value_and_Unit_Text__Converter_Methodes
    {
        string[][] units = new string[3][] {
            new string[] { "kg", "gm", "m", "cm", "mm", "L" },
            new string[] { "kilogram", "gram", "meter", "centimeter", "millimeter", "litre" },
            new string[] { "كيلوجرام", "جرام", "متر", "سنتيمتر", "مليمتر", "لتر" } };
        public bool Validation(string number, string lang, string unit , out int err_id, out string err_message)
        {
            if(value_validation(number.Trim(), out err_id,out err_message))
            {
                if(language_validation(lang.Trim(),out err_id,out err_message))
                {
                    if(unit_validation(unit.Trim(), out err_id,out err_message))
                        return true;
                }
            }
            return false;
        }
        /// <summary>
        /// defines whether the numerical value that will be converted is valid or invalid
        /// ,save error message incase error occured & save id for that message.
        /// err_id : err_message
        ///   0    | "success"
        ///   1    | "value field is empty"
        ///   2    | "input length out of range"
        ///   3    | "starting with seprator"
        ///   4    | "ending with seprator"
        ///   5    | "max number of dots exceeded"
        ///   6    | "seprator dublication"
        ///   7    | "comma in fractional part"
        ///   8    | "max number of commas exceeded"
        ///   9    | "wrong inputted char"
        ///   10   | "fractional part is out of length range"
        ///   11   | "integral part is out of length range"
        ///   12   | "Value is out of range"
        /// </summary>
        /// <param name="number">the number that will beconverted</param>
        /// <param name="err_id">int id of error type occured</param>
        /// <param name="err_message">string save message explain that type of error</param>
        /// <returns>returns true if the number was valid otherwise false</returns>
        public bool value_validation(string number, out int err_id, out string err_message)
        {
                if (number.Length > 0 && number.Length <= 20)//check whether length of the string doesn't exceed max length or if string is empty.
                {
                    if (number[0] != ',' && number[0] != '.')//check if the string doesn't start with seprator.
                    {
                        if (number[number.Length - 1] != ',' && number[number.Length - 1] != '.')//check whther the string doesn't end with seprator.
                        {
                            int dots_no = 0, comas_no = 0;//sets counters for number of dots & number of commas in string.
                            foreach (char number_char in number)//loops on each char of the string.
                            {
                                if (number_char >= '0' && number_char <= '9')//check if the char is number.
                                    continue;
                                else if (number_char == '.')//check if the char is dot.
                                {
                                    dots_no++;//increment dot counter
                                    if (dots_no > 1)//chek whether dot counter more than avaliable number.
                                    {
                                        err_id = 5;//set id of the error
                                        err_message = "max number of dots exceeded";// set error message describe the error type.
                                        return false;
                                    }
                                    if (Array.IndexOf(number.ToCharArray(), number_char) != number.Length - 1)//check whether char not last one in string.
                                    {
                                        if (number[(Array.IndexOf(number.ToCharArray(), number_char) + 1)] == ',' || number[(Array.IndexOf(number.ToCharArray(), number_char) + 1)] == '.')
                                        // check whether th char is followed by seprator.
                                        {
                                            err_id = 6;//set id of the error
                                            err_message = "seprator dublication";// set error message describe the error type.
                                            return false;
                                        }
                                    }
                                    continue;
                                }
                                else if (number_char == ',')//check if the char is comma.
                                {
                                    if (dots_no == 1)//check if the inegral part has passed and the char is in the fractional part.
                                    {
                                        err_id = 7;//set id of the error
                                        err_message = "comma in fractional part";// set error message describe the error type.
                                        return false;
                                    }
                                    comas_no++;// increment the counter of commas.
                                    if (comas_no > 3)//chek whether comma counter more than avaliable number.
                                    {
                                        err_id = 8;//set id of the error.
                                        err_message = "max number of commas exceeded";// set error message describe the error type.
                                        return false;
                                    }
                                    if (Array.IndexOf(number.ToCharArray(), number_char) != number.Length - 1)//check whether char not last one in string.
                                    {
                                        if (number[(Array.IndexOf(number.ToCharArray(), number_char) + 1)] == ',' || number[(Array.IndexOf(number.ToCharArray(), number_char) + 1)] == '.')
                                        // check whether th char is followed by seprator.
                                        {
                                            err_id = 6;//set id of the error
                                            err_message = "seprator dublication";// set error message describe the error type.
                                            return false;
                                        }
                                    }
                                    continue;
                                }
                                else
                                {
                                    err_id = 9;//set id of the error.
                                    err_message = "wrong inputted char";// set error message describe the error type.
                                    return false;
                                }
                            }
                            number = number.Replace(",", "");//remove the commas.
                            if (dots_no != 0)//check if the number has fractional part.
                            {
                                if (number.Split('.')[1].Length <= 4)//check if the fractional part length doesn't exceed max limit.
                                {
                                    if (number.Split('.')[0].Length <= 12)//check if the integral part length doesn't exceed max limit.
                                    {
                                        if (Convert.ToDecimal(number) >= 1)//check if the value of the number not less than 1.
                                        {
                                            err_id = 0;//set error id of not occuring error.
                                            err_message = "success";//set message of success for validation.
                                            return true;
                                        }
                                        else
                                        {
                                            err_id = 12;//set id of the error.
                                            err_message = "Value is out of range";// set error message describe the error type.
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        err_id = 11;//set id of the error.
                                        err_message = "integral part is out of length range";// set error message describe the error type.
                                        return false;
                                    }
                                }
                                else
                                {
                                    err_id = 10;//set id of the error.
                                    err_message = "fractional part is out of length range";// set error message describe the error type.
                                    return false;
                                }
                            }
                            else
                            {
                                if (number.Length <= 12)//check if the integral part length doesn't exceed max limit.
                                {
                                    if (Convert.ToInt32(number) == 0)
                                    {
                                        err_id = 12;//set id of the error.
                                        err_message = "Value is out of range";// set error message describe the error type.
                                        return false;
                                    }
                                    else
                                    {
                                        err_id = 0;//set error id of not occuring error.
                                        err_message = "success"; ;//set message of success for validation.
                                        return true;
                                    }
                                }
                                else
                                {
                                    err_id = 11;//set id of the error.
                                    err_message = "integral part is out of length";// set error message describe the error type.
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            err_id = 4;//set id of the error.
                            err_message = "ending with seprator";// set error message describe the error type.
                            return false;
                        }
                    }
                    else
                    {
                        err_id = 3;//set id of the error.
                        err_message = "starting with seprator";// set error message describe the error type.
                        return false;
                    }
                }
                else
                {
                    if (number.Length == 0)//check whether the field is empty.
                    {
                        err_id = 1;//set id of the error.
                        err_message = "value field is empty.";// set error message describe the error type.
                        return false;
                    }
                    else
                    {
                        err_id = 2;//set id of the error.
                        err_message = "input length out of range";// set error message describe the error type.
                        return false;
                    }
                }
        }
        /// <summary>
        /// defines whether the language (that the number will be convrted in it's format) is valid or invalid
        /// ,save error message incase error occured & save id for that message.
        /// /// err_id : err_message
        ///    0   | "success"
        ///   13   | "language field is empty"
        ///   14   | "undefined language"
        /// </summary>
        /// <param name="lang">string carry the indicator of the language</param>
        /// <param name="err_id">int id of error type occured</param>
        /// <param name="err_message">string save message explain that type of error</param>
        /// <returns>returns true the indicator of language is right</returns>
        public bool language_validation(string lang, out int err_id, out string err_message)
        {
            lang = lang.Trim();// the spaces on the borders of language string
            if (lang == "AR" || lang == "EN")//Check whther the string carry defined indicator
            {
                err_id = 0;
                err_message = "success";//set error id of not occuring error.
                return true;//set message of success for validation.
            }
            else
            {
                if (lang.Length == 0)
                {
                    err_id = 13;//set id of the error.
                    err_message = "language field is empty";// set error message describe the error type.
                    return false;
                }
                err_id = 14;//set id of the error.
                err_message = "undefined language";// set error message describe the error type.
                return false;
            }
        }
        public bool unit_validation(string unit,out int err_id,out string err_message)
        {
            if(Array.IndexOf(units[0],unit) != -1)
            {
                err_id = 0;
                err_message = "success.";
                return true;
            }
            else
            {
                if(unit.Length == 0)
                {
                    err_id = 15;
                    err_message = "unit field is empty.";
                    return false;
                }
                err_id = 16;
                err_message = "undefined unit.";
                return false;
            }
        }
        public string UnitValueTextConverter(string number, string lang, string unit)
        {
            int err_id;
            string err_message;
            if (Validation(number, lang, unit,out err_id,out err_message))
            {
                number = number.Trim();//remove the added spaces on borders from string.
                lang = lang.Trim();//~ ~ ~ ~ ~ ~ ~ ~.
                unit = unit.Trim();//~ ~ ~ ~ ~ ~ ~ ~.
                if (lang == "EN")//check whether indicator is for english format.
                    return En_converter(number) + " " + units[1][Array.IndexOf(units[0], unit)];//returns the text in arabic equivalent to the number without any addition.
                else
                    return Ar_converter(number) + " " + units[2][Array.IndexOf(units[0], unit)];//returns the text in arabic equivalent to the number without any addition.
            }
            return err_id + " : " + err_message;
            
        }
        /// <summary>
        /// converts a number into text in english format
        /// </summary>
        /// <param name="number">string of the number that will be converted</param>
        /// <returns>string equivalent to the number in english</returns>
        public string En_converter(string number)
        {
            string[] number_arr = number.Split('.');//split the integral part & fractional part of number & set result in string of arrays.
            if (number_arr.Length > 1)//check whther there's fractional part
                return integer_converter_En(Convert.ToDecimal(number_arr[0])) + " and " + fractional_converter_En(Convert.ToDecimal("0." + number_arr[1]));
            //returns the equivalent text for integral part in english and add (and) then add the equivalent text for fractional part (add by (0.) to be in fraction format) in english.
            else
                return integer_converter_En(Convert.ToDecimal(number_arr[0]));
            //returns the equivalent text for integral part in english
            //note converting text to decimal cause two functions takess decimal parameter.
        }
        /// <summary>
        /// converts a decimal number that is integral only into a text in english
        /// </summary>
        /// <param name="integer">decimal carries the value of the integer that will be converted</param>
        /// <returns>returns the equivalent text for the integer number</returns>
        public string integer_converter_En(decimal integer)
        {
            if (integer == 0)// check if the number is 0.
                return "";// returns nothing.
            else
            {
                string text = "";//set string that the value of each three digits of the number will accumlate in it.
                if ((long)integer / 1000000000 > 0)//check whether the 3 digits (that describe the billion value) there value not zero.
                {
                    text += integer_converter_En((long)integer / 1000000000) + " Billion ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word billion.
                    integer %= 1000000000;//remove from the integer the three digit of billion level.
                }
                if ((int)integer / 1000000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
                {
                    text += integer_converter_En((int)integer / 1000000) + " Million ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word Milion.
                    integer %= 1000000;//remove from the integer the three digit of Million level.
                }
                if ((int)integer / 1000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
                {
                    text += integer_converter_En((int)integer / 1000) + " Thousand ";
                    //add for text the text conversion of the three digits (but starts from units level) and add word thousand.
                    integer %= 1000;//remove from the integer the three digit of thousand level.
                }
                if ((int)integer / 100 > 0)//check whether the hundered digit isn't zero.
                {
                    text += integer_converter_En((int)integer / 100) + " hundered ";
                    //add for text the text conversion of the hundered digit (but starts as unit) and add word hundered.
                    integer %= 100;//remove from the integer the hundered digit.
                }
                if (integer == 0)//check whether the units & tenth digits summation value is zero.
                    return text;//return the text reulted from digits from hundered to billion.

                string[] units_tenth = new string[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                //intialize array carries the name of numbers less than twenty.
                string[] tenth = new string[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
                //intialize array that carry the names of tenth digits except that first the one as theeach combination of it with units gives specified name.
                if (integer < 20)//check whether the integer value is less than twenty.
                {
                    text += units_tenth[(int)integer];//add the name of the number that less than 20 and it's value is integer.
                }
                else
                {
                    text += tenth[(int)integer / 10];//get the value of the tenth digit only and add it's name as a tenth.
                    if (integer % 10 > 0)//check whether the units digit isn't zero.
                        text += "-" + integer_converter_En(integer % 10);//add dash then the name of the digit in units digit.
                }


                return text;

            }
        }
        /// <summary>
        /// Convert a fraction with integral value equal zero to it's text equivalent after approximating the fraction digits to be two only.
        /// </summary>
        /// <param name="fraction">decimal carry the fraction that will be converted</param>
        /// <returns> the text in english equivalent to the fraction</returns>
        public string fractional_converter_En(decimal fraction)
        {
            if (fraction < 1 && fraction >= 0)//check whether the fraction contian integral part equals zero.
            {
                if (fraction == 0)//check whether the fraction equal zero
                    return "";//return nothing
                fraction = Math.Round(fraction, 2);//approximate the fraction to be in two digits.

                if (fraction < 1)//check whether fraction after approximation is still wth integral part equal zero.
                {
                    if (fraction.ToString().Length >= 4)//check whether there's two digits after dot
                    {
                        if (fraction.ToString()[3] != '0')//check whether second digit of the fraction not a zero.
                        {
                            return integer_converter_En(100 * fraction) + " Out of Hundered";
                            //returns the text value of the fraction digits when the act as starting from units and add out of hundered in english.
                        }
                        else
                        {
                            return integer_converter_En(10 * fraction) + " Out of Ten";
                            //returns the text value of th fraction which is one digit when it act as unit and add out of ten in english.
                        }
                    }
                    else
                    {
                        return integer_converter_En(10 * fraction) + " Out of Ten";
                        //returns the text value of th fraction which is one digit when it act as unit and add out of ten in english.
                    }
                }
                else
                {
                    return "ninety-nine Out of Hundered";
                }
            }
            else return "fraction out of range.";
        }
        /// <summary>
        /// converts a number into text in arabic format
        /// </summary>
        /// <param name="number">string of the number that will be converted</param>
        /// <returns>string equivalent to the number in arabic</returns>
        public string Ar_converter(string number)
        {
            string[] number_arr = number.Split('.');//split the integral part & fractional part of number & set result in string of arrays.
            if (number_arr.Length > 1)//check whther there's fractional part
                return integer_converter_Ar(Convert.ToDecimal(number_arr[0])) + " و " + fractional_converter_Ar(Convert.ToDecimal("0." + number_arr[1]));
            // returns the equivalent text for integral part in arabic and add(and) then add the equivalent text for fractional part (add by(0.) to be in fraction format) in arabic.
            else
                return integer_converter_Ar(Convert.ToDecimal(number_arr[0]));
            //returns the equivalent text for integral part in arabic.
            //note converting text to decimal cause two functions takess decimal parameter.
        }
        /// <summary>
        /// converts a decimal number that is integral only into a text in Arabic
        /// </summary>
        /// <param name="integer">decimal carries the value of the integer that will be converted</param>
        /// <returns>returns the equivalent text for the integer number</returns>
        public string integer_converter_Ar(decimal integer)
        {
            if (integer == 0)// check if the number is 0.
                return "";
            string text = "";//set string that the value of each three digits of the number will accumlate in it.
            if ((long)integer / 1000000000 > 0)//check whether the 3 digits (that describe the billion value) there value not zero.
            {
                if ((long)integer / 1000000000 == 1)//check whether those digits value is 1.
                    text += " مليار ";//add the suiting word according to grammer.
                else if ((long)integer / 1000000000 == 2)//check whether those digits value is 2.
                    text += " ملياران ";//add the suiting word according to grammer.
                else if ((long)integer / 1000000000 < 11)//check whether those digits value is less than 11.
                    text += integer_converter_Ar((long)integer / 1000000000) + " مليارات ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                else
                    text += integer_converter_Ar((long)integer / 1000000000) + " ملياراَ ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                integer %= 1000000000;//remove from the integer the three digit of billion level.
            }
            if ((int)integer / 1000000 > 0)//check whether the 3 digits (that describe the Million value) there value not zero.
            {
                if (text != "")//check whether there's value in text from pervious condition.
                    text = text + " و ";//add linking char according to grammer.
                if ((int)integer / 1000000 == 1)//check whether those digits value is 1.
                    text = " مليون " + text;//add the suiting word according to grammer.
                else if ((int)integer / 1000000 == 2)//check whether those digits value is 2.
                    text += " مليونان ";//add the suiting word according to grammer.
                else if ((int)integer / 1000000 < 11)//check whether those digits value is less than 11.
                    text += integer_converter_Ar((int)integer / 1000000) + " ملايين ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                else
                    text += integer_converter_Ar((int)integer / 1000000) + " مليوناً ";
                // add for text the text conversion of the three digits(but starts from units level) and suiting word grammarly.
                integer %= 1000000;// remove from the integer the three digit of million level.
            }
            if ((int)integer / 1000 > 0)//check whether the 3 digits (that describe the thousand value) there value not zero.
            {
                if (text != "")//check whether there's value in text from pervious conditions.
                    text = text + " و ";//add linking char according to grammer.
                if ((int)integer / 1000 == 1)//check whether those digits value is 1.
                    text += "ألف ";//add the suiting word according to grammer.
                else if ((int)integer / 1000 == 2)//check whether those digits value is 2.
                    text += "ألفان ";//add the suiting word according to grammer.
                else if ((int)integer / 1000 < 11)//check whether those digits value is less than 11.
                    text += integer_converter_Ar((int)integer / 1000) + " ألاف ";
                //add for text the text conversion of the three digits (but starts from units level) and suiting word grammarly.
                else
                    text += integer_converter_Ar((int)integer / 1000) + " ألفاً ";
                // add for text the text conversion of the three digits(but starts from units level) and suiting word grammarly.
                integer %= 1000;// remove from the integer the three digit of thousand level.
            }
            if ((int)integer / 100 > 0)//check whether the hundered digit isn't zero.
            {
                if (text != "")//check whether there's value in text from pervious conditions.
                    text = text + " و ";//add linking char according to grammer.
                string[] hundered = new string[] { "صفر", "مائة", "مائتان", "ثلاثمائة", "أربعمائة", "خمسمائة", "ستمائة", "سبعمائة", "ثمانمائة", "تسعمائة" };
                //intialize array names of digits in hundereds according to grammer.
                text += hundered[(int)integer / 100];//add the name of the digit in hundered level
                integer %= 100;// remove the hundered digit.
            }
            if (integer == 0)//check whether the units & tenth digits summation value is zero.
                return text;//return the text reulted from digits from hundered to billion.
            if (text != "")//check whether there's value in text from pervious conditions.
                text = text + " و ";//add linking char according to grammer.
            string[] units = new string[] { "صفر", "واحد", "اثنان", "ثلاثة", "أربعة", "خمسة", "ستة", "سبعة", "ثمانية", "تسعة", "عشرة" };
            //array carry the names of numbers at units digit and the name of first one in tenth digit with zero combination of units digit.
            string[] tenth = new string[] { "صفر", "عشرة", "عشرون", "ثلاثون", "أربعون", "خمسون", "ستون", "سبعون", "ثمانون", "تسعون" };
            //array carry the names of numbers at tenth digit.
            if (integer <= 10)//check whether the total value of the two digits is less than or equal ten.
                text = text + units[(int)integer];//add the name of the digit from the array of units
            else if (integer < 20)//check whether the total value of two digits is less than 20
            {
                if (integer == 11)//check whether it's 11 
                    text = text + "أحد عشر";//add name of eleven
                else if (integer == 12)//check whther it's twelve
                    text = text + "اثنا عشر";//add name of twelve
                else
                    text = text + units[(int)integer % 10] + " عشر";//add the units name of the units digit and add the suiting constan word according to grammer.
            }
            else
            {
                if ((int)integer % 10 != 0)//check whether the units digit is not zero.
                    text += units[(int)integer % 10] + " و " + tenth[(int)integer / 10];
                // add the tenth name of the tenth digit and linking char and the units name of units digit.
                else
                    text += tenth[(int)integer / 10];//add the tenth name of tenth digit.
            }

            return text;
        }
        /// <summary>
        /// Convert a fraction with integral value equal zero to it's text equivalent after approximating the fraction digits to be two only.
        /// </summary>
        /// <param name="fraction">decimal carry the fraction that will be converted</param>
        /// <returns>the text in arabic equivalent to the fraction</returns>
        public string fractional_converter_Ar(decimal fraction)
        {
            if (fraction < 1 && fraction >= 0)//check whether the fraction contian integral part equals zero.
            {
                if (fraction == 0)//check whether the fraction equal zero
                    return "";
                fraction = Math.Round(fraction, 2);//approximate the fraction to be in two digits.

                if (fraction < 1)//check whether fraction after approximation is still wth integral part equal zero.
                {
                    if (fraction.ToString().Length >= 4)//check whether there's two digits after dot
                    {
                        if (fraction.ToString()[3] != '0')//check whether second digit of the fraction not a zero.
                        {
                            return integer_converter_Ar(100 * fraction) + " من مئة";
                            //returns the text value of the fraction digits when the act as starting from units and add out of hundered in arabic.
                        }
                        else
                        {
                            return integer_converter_Ar(10 * fraction) + " من عشرة";
                            //returns the text value of th fraction which is one digit when it act as unit and add out of ten in arabic.
                        }
                    }
                    else
                        return integer_converter_Ar(10 * fraction) + "  من عشرة";
                    //returns the text value of th fraction which is one digit when it act as unit and add out of ten in english.
                }
                else
                {
                    return "تسعة و تسعون من مئة";
                }
            }
            else return "fraction out of range.";
        }
    }
}
