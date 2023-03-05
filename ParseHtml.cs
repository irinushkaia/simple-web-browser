using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProiectOOP
{
    public class ParseHtml
    {
        private string _html;
        private int _index;
        

        public string Source
        {
            get { return _html; }
            set 
            { 
                string path = value;
                _html = File.ReadAllText(value);
            }
        }
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        
       
        public bool Eof
        {
            get { return _index >= _html.Length; }
        }
       
        //returneaza caracterul la pozitia specificata
        //(nr de caractere incepand de la pozitia curenta)
        //returneaza un caracter null daca pozitia se afla la finalul documentului
        public char Peek(int ahead)
        {
            int pos = (_index + ahead);
            if (pos < _html.Length)
            {
                return _html[pos];
            }
            return (char)0;
        }

        //pozitia curenta
        public char Peek()
        {
            return Peek(0);
        }
        protected void Move(int ahead)
        {
            //_index = Math.Min(ahead + _index, _html.Length);
            _index += ahead;
        }
        
        //avanseaza cu o pozitie(cu un indice)
        protected void Move()
        {
            Move(1);
        }

        protected bool MoveToNextTag()
        {
            _index = _html.IndexOf('<', _index);
            return !Eof;
        }
        protected string ParseTagName()
        {
            int start = _index;
            while (!Eof && Peek() != '>')
            {
                Move();
            }
            return _html.Substring(start, _index - start).ToLower();
        }

        public string ExtractText()
        {

            ParseTagName();
            int start = _index;
            while (!Eof && Peek() != '>' && Peek(1) != '/')
            {
                Move();
            }
            return _html.Substring(start, _index - start);

            
        }
        
        
    }
}

