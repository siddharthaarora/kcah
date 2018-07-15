//<JSON>     ::= <value>
//<value>    ::= <object> | <array> | <boolean> | <string> | <number> | <null>
//<array>    ::= "[" [<value>] {"," <value>}* "]"
//<object>   ::= "{" [<property>] {"," <property>}* "}"
//<property> ::= <string> ":" <value>
//https://wesleytsai.io/2015/06/13/a-json-parser/

using System;
using System.Collections.Generic;
using System.Text;

namespace Challenge
{
    public class JSONParser
    {
        private string JsonText = "";
        private char CurrentCharacter;
        private int CurrentIndex = 0;

        private char Next()
        {
            CurrentIndex++;
            CurrentCharacter = JsonText[CurrentIndex];
            return CurrentCharacter;
        }
/*
        private Json Value()
        {
            Json json = new Json();

            switch (CurrentCharacter)
            {
                case '{':
                    return ObjectValue();
                case '[':
                    return ArrayValue();
                case 't':
                case 'f':
                case 'T':
                case 'F':
                    return BooleanValue();
                case 'n':
                    return NullValue();
                case '\"':
                    return StringValue();
                default:
                    if (CurrentCharacter == '-' || (CurrentCharacter >=0 && CurrentCharacter <= 9))
                    {
                        return NumberValue();
                    }
                    else
                    {
                        throw new Exception("Bad JSON");
                    }
            }
        }

        private string ObjectValue()
        {
            JsonObject jobj = new JsonObject();
            jobj.Properties = new List<JsonProperty>();

            do
            {
                var key = StringValue();
                jobj.k
                Next();
                sb.Append(CurrentCharacter);
                var value = Value();
                if (CurrentCharacter == '}')
                {
                    Next();
                    sb.Append(value);
                    return sb.ToString();
                }
            }
            while (CurrentCharacter == ',' && Next() != '}');

            throw new Exception("Bad JSON");
        }

        private string ArrayValue()
        {
            StringBuilder sb = new StringBuilder();
            Next();

            do
            {
                sb.Append(Value());
                if (CurrentCharacter == ']')
                {
                    Next();
                    return sb.ToString();
                }
            }
            while (CurrentCharacter == ',' && Next() != ']');

            throw new Exception("Bad JSON");
        }

        private string NumberValue()
        {
            StringBuilder sb = new StringBuilder();

            while (CurrentCharacter >= 0 && CurrentCharacter <= 9)
            {
                sb.Append(Next());

            }
            return sb.ToString();
        }

        private string BooleanValue()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < 4; i++)
            {
                sb.Append(Next());

            }
            return sb.ToString();
        }

        private string NullValue()
        {
            StringBuilder sb = new StringBuilder();

            for(int i=0;i<4;i++)
            {
                sb.Append(Next());
                    
            }
            return sb.ToString();
        }

        private string StringValue()
        {
            StringBuilder sb = new StringBuilder();

            Next();

            while (CurrentCharacter != '\"')
            {
                sb.Append(Next());
            }
            return sb.ToString();
        }

        public JSONParser(string jsonText)
        {
            this.JsonText = jsonText;
            CurrentIndex = 0;
            CurrentCharacter = jsonText[CurrentIndex];
        }

        public string Parse()
        {
            return this.Value();
        }
        */
    }
    
}
