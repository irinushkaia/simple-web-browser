using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectOOP
{
    public class ManageHtml : ParseHtml
    {
        private int _endIndex;
        
        public int endIndex
        {
            get { return _endIndex; }
            set { _endIndex = value; }
        }
        public ManageHtml(string html)  { 
            Source= html;
        }
       
        public void GetText(Form1 form)
        {
            
            while (!Eof)
            {
                
                if (MoveToNextTag() == true)
                {
                    if (Index < 0)
                    {
                        form.write(Source.Substring(endIndex));
                        break;
                    }
                    // form.tab();
                    form.write(Source.Substring(endIndex, Index - endIndex));
                    
                    endIndex = Source.IndexOf(">", Index) + 1;
                    string tag=Source.Substring(Index,endIndex-Index);
                    
                    FormatText(tag, ExtractText(), form);
                    if (tag.StartsWith("<table>"))
                    {
                        while (!tag.Contains("</table>"))
                        {
                            if (tag.Contains("<tr>"))
                            {
                                form.newline();
                            }
                            else if (tag.Contains("<td>"))
                            {
                                form.tab();
                            }
                            else if (tag.Contains("</td>"))
                            {
                                form.write(tag.Substring(0, tag.Length - 5));
                            }
                            Index = endIndex;
                            endIndex = Source.IndexOf(">", Index) + 1;

                            tag = Source.Substring(Index, endIndex - Index);


                        }
                    }
                    Index = endIndex;

                }
            }
        }
        protected void FormatText(string tag, string text, Form1 form)
        {
            if (tag.StartsWith("<b>"))
            {
                var bold = new Bold();
                bold.Format(text, form);
            }
            else if (tag.StartsWith("<i>"))
            {
                var italic = new Italic();
                italic.Format(text, form);
            }
            else if (tag.StartsWith("<h1>"))
            {
                var header = new Header();
                header.Format(text, form);
            }
            else if (tag.StartsWith("<p>"))
            {
                var plain = new Text();
                plain.Format(text, form);
            }

        }

    }
}

