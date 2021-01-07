using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Builder
{

    public class CodeElement
    {
        public string Name, Type;
        public string className;
        public List<CodeElement> Fields = new List<CodeElement>();

        private string ToStringImpl()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"public class {className}");
            sb.AppendLine("{");
            foreach (var f in Fields)
            {
                sb.AppendLine($"    public {f.Type} {f.Name};");
            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        public override string ToString()
        {
            return ToStringImpl();
        }

        public CodeElement(string name, string type)
        {
            if (name == null)
            {
                throw new ArgumentNullException(paramName: nameof(name));
            }
            if (type == null)
            {
                throw new ArgumentNullException(paramName: nameof(type));
            }
            Name = name;
            Type = type;
        }

        public CodeElement()
        {     
        }
    }
    public class CodeBuilder
    {
        private readonly string ClassName;
        CodeElement name = new CodeElement();
        public CodeBuilder(string className)
        {
            if (className == null)
            {
                throw new ArgumentNullException(paramName: nameof(className));
            }
            ClassName = className;
            name.className = className;
        }

        public CodeBuilder AddField(string fieldName, string fieldType)
        {
            var e = new CodeElement(fieldName, fieldType);
            name.Fields.Add(e);
            return this;
        }
        public override string ToString()
        {
            return name.ToString();
        }
    }


    class Exercise
    {

    }
}
