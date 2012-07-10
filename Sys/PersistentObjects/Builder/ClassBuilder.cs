using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace Sys.Builder
{
    class ClassBuilder
    {
        List<string> usings = new List<string>();

        List<Constructor> constructors = new List<Constructor>();
        List<Field> fields = new List<Field>();
        List<Method> methods = new List<Method>();
        List<Property> properties = new List<Property>();

        private string nameSpace;
        private Modifier classModifier;
        private string className;
        private Type[] inherits;

        public ClassBuilder(string nameSpace, ModifierType modifer, string className)
            :this(nameSpace, modifer, className, new Type[]{})
        { 
        }

        public ClassBuilder(string nameSpace, ModifierType modifer, string className, Type[] inherits)
        {
            this.nameSpace = nameSpace;
            this.classModifier = new Modifier(modifer);
            this.className = className;
            this.inherits = inherits;
        }

        public ClassBuilder AddUsing(string name)
        {
            this.usings.Add(name);
            return this;
        }

        public ClassBuilder AddConstructor(Constructor constructor)
        {
            this.constructors.Add(constructor);
            return this;
        }
  
        public ClassBuilder AddField(Field field)
        {
            this.fields.Add(field);
            return this;
        }

        public ClassBuilder AddMethod(Method method)
        {
            this.methods.Add(method);
            return this;
        }

        public ClassBuilder AddProperty(Property property)
        {
            this.properties.Add(property);
            return this;
        }

        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            
            s.Append(string.Join("", usings.Select(name =>string.Format("using {0};\r\n",name))));
            s.AppendLine();

            s.AppendFormat("namespace {0}", this.nameSpace).AppendLine();
            s.AppendLine("{");

            s.AppendFormat("\t{0}class {1}", classModifier, className);
            if(inherits.Length >0)
                s.AppendFormat(" : {0}", string.Join(", ", inherits.Select(inherit => new TypeInfo(inherit).Text)));
            
            s.AppendLine();
            s.AppendLine("\t{");

            foreach (Field field in fields)
                s.Append("\t\t").AppendLine(field.ToString());

            s.AppendLine();

            foreach (Constructor constructor in constructors)
                s.AppendLine(constructor.ToString());

            foreach (Property property in properties)
                s.AppendLine(property.ToString());

            foreach (Method method in methods)
                s.AppendLine(method.ToString());


            s.AppendLine("\t}");
            s.AppendLine("}");


            return s.ToString();
        }

    }
}
