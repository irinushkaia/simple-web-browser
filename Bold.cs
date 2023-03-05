using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectOOP
{
    public class Bold:TagFormatter
    {
        public override void Format(string text, Form1 form)
        {
          
            form.bold(text);
               
        }
    }
}
