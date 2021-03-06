﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Spartane.Web.Helpers
{
    public static class FileWritter
    {
        public static string Path { get; set; }
        public static void Write(string idRule, string attr, string scope, string ev, string section, StringBuilder newRule, int delete, string operation)
        {
            
            string id = "//BusinessRuleId:" + idRule + ", Attribute:" + attr + ", Operation:" + scope + ", Event:" + ev;
            
            if (delete == 4 || delete == 1)
            {
                CleanBusinessRule(id);
            }
            else
            {
                StringBuilder ruleToInsert = new StringBuilder();
                ruleToInsert.AppendLine(id);
				if (operation != "Field")
					ruleToInsert.AppendLine("if(operation == '" + operation + "'){");
                ruleToInsert.AppendLine(newRule.ToString());
				if (operation != "Field")
					ruleToInsert.AppendLine("}");
                ruleToInsert.AppendLine(id);
                ruleToInsert.AppendLine();
                ruleToInsert.AppendLine(section);
                ruleToInsert.AppendLine();
                AddBusinessRule(section, ruleToInsert);
            }
        }

        private static void AddBusinessRule(string section, StringBuilder newRule)
        {
            string text = System.IO.File.ReadAllText(Path);
            text = text.Replace(section, newRule.ToString().TrimStart().TrimEnd());
            System.IO.File.WriteAllText(Path, text);
        }

        public static void CleanBusinessRule(string id)
        {
            //StringBuilder sb = new StringBuilder();
            string sb = "";
            string allText = "";
            int counter = 0;
            string line;
            bool startWriter = false;
            bool end = false;

            using (System.IO.StreamReader file = new System.IO.StreamReader(Path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    if (!end)
                    {
                        if (line.Trim() == id.Trim())
                        {
                            startWriter = !startWriter;
                            if (!startWriter)
                            {
                                sb += line + "\r\n";
                                end = true;
                                //sb.AppendLine(line);
                            }
                        }
                        if (startWriter)
                        {
                            sb += line + "\r\n";
                            //sb.AppendLine(line);
                        }
                    }
                    allText += line + "\r\n";
                    counter++;
                }
                file.Close();
            }
            if (sb.ToString() != "")
            {
                int a = allText.IndexOf(sb);
                allText = allText.Replace(sb, "").ToString();
                System.IO.File.WriteAllText(Path, allText);
            }
        }
    }
}